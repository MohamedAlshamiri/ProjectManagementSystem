import { ChangeDetectionStrategy, Component, OnInit, inject, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzTooltipModule } from 'ng-zorro-antd/tooltip';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ProjectService } from '../../../../core/services/project.service';
import { Project } from '../../../../core/models/project.model';
import { PROJECT_STATUSES } from '../../../../core/constants/lookups';
import { LanguageService } from '../../../../core/services/language';

@Component({
  selector: 'app-project-list',
  imports: [
    DatePipe, FormsModule, ReactiveFormsModule, TranslatePipe, NzButtonModule, NzTableModule,
    NzModalModule, NzFormModule, NzInputModule, NzSelectModule, NzDatePickerModule,
    NzPopconfirmModule, NzTagModule, NzIconModule, NzTooltipModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './project-list.html',
  styleUrl: './project-list.css',
})
export class ProjectList implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ProjectService);
  private readonly message = inject(NzMessageService);
  private readonly translate = inject(TranslateService);
  readonly languageService = inject(LanguageService);

  readonly projects = signal<Project[]>([]);
  readonly loading = signal(false);
  readonly error = signal(false);
  statuses = PROJECT_STATUSES;
  modalVisible = false;
  readonly saving = signal(false);
  editingId: number | null = null;
  search = '';
  statusFilter: number | null = null;

  readonly form = this.fb.nonNullable.group({
    name: ['', [Validators.required, Validators.maxLength(200)]],
    description: ['', Validators.maxLength(1000)],
    statusId: [1, Validators.required],
    startDate: [null as Date | null],
    endDate: [null as Date | null],
  });

  get activeCount(): number { return this.projects().filter(x => x.statusId !== 3).length; }
  get completedCount(): number { return this.projects().filter(x => x.statusId === 3).length; }

  get filteredProjects(): Project[] {
    const query = this.search.trim().toLowerCase();
    return this.projects().filter(project => {
      const matchesSearch = !query || project.name.toLowerCase().includes(query) || (project.description ?? '').toLowerCase().includes(query);
      const matchesStatus = this.statusFilter === null || project.statusId === this.statusFilter;
      return matchesSearch && matchesStatus;
    });
  }

  ngOnInit(): void { this.load(); }

  load(): void {
    this.loading.set(true);
    this.error.set(false);
    this.service.getAll().subscribe({
      next: data => { this.projects.set(data); this.loading.set(false); },
      error: () => { this.loading.set(false); this.error.set(true); this.message.error(this.t('COMMON.LOAD_PROJECTS_ERROR')); }
    });
  }

  openCreate(): void {
    this.editingId = null;
    this.form.reset({ name: '', description: '', statusId: 1, startDate: null, endDate: null });
    this.modalVisible = true;
  }

  openEdit(project: Project): void {
    this.editingId = project.id;
    this.form.patchValue({
      name: project.name,
      description: project.description ?? '',
      statusId: project.statusId,
      startDate: project.startDate ? new Date(project.startDate) : null,
      endDate: project.endDate ? new Date(project.endDate) : null,
    });
    this.modalVisible = true;
  }

  save(): void {
    if (this.form.invalid) {
      Object.values(this.form.controls).forEach(control => control.markAsDirty());
      return;
    }
    const raw = this.form.getRawValue();
    if (raw.endDate && raw.startDate && raw.endDate < raw.startDate) {
      this.message.warning(this.t('PROJECTS.DATE_ORDER_ERROR'));
      return;
    }

    this.saving.set(true);
    const request = {
      name: raw.name.trim(),
      description: raw.description.trim() || null,
      statusId: raw.statusId,
      startDate: raw.startDate?.toISOString() ?? null,
      endDate: raw.endDate?.toISOString() ?? null,
    };
    const editingId = this.editingId;

    const operation: Observable<unknown> = editingId === null ? this.service.create(request) : this.service.update(editingId, request);
    operation.subscribe({
      next: () => {
        this.saving.set(false);
        this.message.success(this.t(editingId === null ? 'PROJECTS.CREATED' : 'PROJECTS.UPDATED'));
        this.modalVisible = false;
        this.load();
      },
      error: () => {
        this.saving.set(false);
        this.message.error(this.t('PROJECTS.SAVE_ERROR'));
      }
    });
  }

  delete(id: number): void {
    this.service.delete(id).subscribe({
      next: () => { this.message.success(this.t('PROJECTS.DELETED')); this.load(); },
      error: () => this.message.error(this.t('PROJECTS.DELETE_ERROR'))
    });
  }

  statusLabel(id: number): string {
    const item = this.statuses.find(x => x.id === id);
    return this.languageService.language === 'ar' ? (item?.nameAr ?? '') : (item?.name ?? '');
  }

  statusColor(id: number): string { return id === 3 ? 'green' : id === 2 ? 'blue' : 'gold'; }
  private t(key: string): string { return this.translate.instant(key); }
}
