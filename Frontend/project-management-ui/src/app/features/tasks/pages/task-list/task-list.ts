import { ChangeDetectionStrategy, Component, OnInit, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
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
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzTooltipModule } from 'ng-zorro-antd/tooltip';
import { NzMessageService } from 'ng-zorro-antd/message';
import { TaskService } from '../../../../core/services/task.service';
import { ProjectService } from '../../../../core/services/project.service';
import { Project } from '../../../../core/models/project.model';
import { Task } from '../../../../core/models/task.model';
import { TASK_PRIORITIES, TASK_STATUSES } from '../../../../core/constants/lookups';
import { LanguageService } from '../../../../core/services/language';

@Component({
  selector: 'app-task-list',
  imports: [
    RouterLink, DatePipe, FormsModule, ReactiveFormsModule, TranslatePipe, NzButtonModule, NzTableModule,
    NzModalModule, NzFormModule, NzInputModule, NzSelectModule, NzDatePickerModule,
    NzPopconfirmModule, NzTagModule, NzIconModule, NzPaginationModule, NzTooltipModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})
export class TaskList implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly tasksService = inject(TaskService);
  private readonly projectsService = inject(ProjectService);
  private readonly message = inject(NzMessageService);
  private readonly translate = inject(TranslateService);
  readonly languageService = inject(LanguageService);

  readonly tasks = signal<Task[]>([]);
  readonly projects = signal<Project[]>([]);
  readonly loading = signal(false);
  readonly error = signal(false);
  statuses = TASK_STATUSES;
  priorities = TASK_PRIORITIES;
  modalVisible = false;
  readonly saving = signal(false);
  editingId: number | null = null;
  pageNumber = 1;
  pageSize = 10;
  total = 0;
  search = '';
  statusFilter: number | null = null;
  projectFilter: number | null = null;
  sortBy: 'title' | 'priority' | 'duedate' = 'duedate';
  sortOrder: 'asc' | 'desc' = 'asc';

  readonly form = this.fb.nonNullable.group({
    projectId: [null as number | null, Validators.required],
    title: ['', [Validators.required, Validators.maxLength(300)]],
    description: ['', Validators.maxLength(1000)],
    statusId: [1, Validators.required],
    priorityId: [2, Validators.required],
    dueDate: [null as Date | null],
  });

  ngOnInit(): void {
    this.loadProjects();
    this.load();
  }

  loadProjects(): void {
    this.projectsService.getAll().subscribe({
      next: data => this.projects.set(data),
      error: () => this.message.error(this.t('COMMON.LOAD_PROJECTS_ERROR'))
    });
  }

  load(): void {
    this.loading.set(true);
    this.error.set(false);
    this.tasksService.getAll({
      statusId: this.statusFilter ?? undefined,
      projectId: this.projectFilter ?? undefined,
      search: this.search,
      sortBy: this.sortBy,
      sortOrder: this.sortOrder,
      pageNumber: this.pageNumber,
      pageSize: this.pageSize
    }).subscribe({
      next: response => { this.tasks.set(response.items); this.total = response.totalCount; this.loading.set(false); },
      error: () => { this.loading.set(false); this.error.set(true); this.message.error(this.t('COMMON.LOAD_TASKS_ERROR')); }
    });
  }

  applyFilters(): void { this.pageNumber = 1; this.load(); }
  changePage(page: number): void { this.pageNumber = page; this.load(); }
  clearFilters(): void { this.search = ''; this.statusFilter = null; this.projectFilter = null; this.sortBy = 'duedate'; this.sortOrder = 'asc'; this.applyFilters(); }

  openCreate(): void {
    this.editingId = null;
    this.form.reset({ projectId: this.projects()[0]?.id ?? null, title: '', description: '', statusId: 1, priorityId: 2, dueDate: null });
    this.modalVisible = true;
  }

  openEdit(task: Task): void {
    this.editingId = task.id;
    this.form.patchValue({ projectId: task.projectId, title: task.title, description: task.description ?? '', statusId: task.statusId, priorityId: task.priorityId, dueDate: task.dueDate ? new Date(task.dueDate) : null });
    this.modalVisible = true;
  }

  save(): void {
    if (this.form.invalid) { Object.values(this.form.controls).forEach(control => control.markAsDirty()); return; }
    const raw = this.form.getRawValue();
    this.saving.set(true);
    const createRequest = { projectId: raw.projectId!, title: raw.title.trim(), description: raw.description.trim() || null, statusId: raw.statusId, priorityId: raw.priorityId, dueDate: raw.dueDate?.toISOString() ?? null };
    const updateRequest = { title: createRequest.title, description: createRequest.description, statusId: createRequest.statusId, priorityId: createRequest.priorityId, dueDate: createRequest.dueDate };
    const editingId = this.editingId;
    const operation: Observable<unknown> = editingId === null ? this.tasksService.create(createRequest) : this.tasksService.update(editingId, updateRequest);
    operation.subscribe({
      next: () => { this.saving.set(false); this.message.success(this.t(editingId === null ? 'TASKS.CREATED' : 'TASKS.UPDATED')); this.modalVisible = false; this.load(); },
      error: () => { this.saving.set(false); this.message.error(this.t('TASKS.SAVE_ERROR')); }
    });
  }

  delete(id: number): void {
    this.tasksService.delete(id).subscribe({
      next: () => { this.message.success(this.t('TASKS.DELETED')); this.load(); },
      error: () => this.message.error(this.t('TASKS.DELETE_ERROR'))
    });
  }

  statusLabel(id: number): string {
    const item = this.statuses.find(x => x.id === id);
    return this.languageService.language === 'ar' ? (item?.nameAr ?? '') : (item?.name ?? '');
  }
  priorityLabel(id: number): string {
    const item = this.priorities.find(x => x.id === id);
    return this.languageService.language === 'ar' ? (item?.nameAr ?? '') : (item?.name ?? '');
  }
  statusColor(id: number): string { return id === 3 ? 'green' : id === 2 ? 'blue' : 'gold'; }
  priorityColor(id: number): string { return id === 3 ? 'red' : id === 2 ? 'orange' : 'green'; }
  isOverdue(task: Task): boolean {
    if (!task.dueDate || task.statusId === 3) return false;
    const due = new Date(task.dueDate);
    const today = new Date();
    today.setHours(0, 0, 0, 0);
    return due < today;
  }

  private t(key: string): string { return this.translate.instant(key); }
}
