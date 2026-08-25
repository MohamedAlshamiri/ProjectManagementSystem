import { ChangeDetectionStrategy, Component, OnInit, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslatePipe } from '@ngx-translate/core';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzStatisticModule } from 'ng-zorro-antd/statistic';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { forkJoin } from 'rxjs';
import { ProjectService } from '../../../../core/services/project.service';
import { TaskService } from '../../../../core/services/task.service';
import { Project } from '../../../../core/models/project.model';
import { Task } from '../../../../core/models/task.model';
import { PROJECT_STATUSES, TASK_STATUSES } from '../../../../core/constants/lookups';
import { LanguageService } from '../../../../core/services/language';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink, TranslatePipe, NzCardModule, NzStatisticModule, NzIconModule, NzSpinModule, NzTagModule, NzButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard implements OnInit {
  private readonly projectsService = inject(ProjectService);
  private readonly tasksService = inject(TaskService);
  readonly languageService = inject(LanguageService);

  readonly loading = signal(true);
  readonly apiError = signal(false);
  readonly projects = signal(0);
  readonly tasks = signal(0);
  readonly completedProjects = signal(0);
  readonly completedTasks = signal(0);
  readonly projectList = signal<Project[]>([]);
  readonly recentTasks = signal<Task[]>([]);

  readonly projectStatuses = PROJECT_STATUSES;
  readonly taskStatuses = TASK_STATUSES;

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.loading.set(true);
    this.apiError.set(false);
    forkJoin({
      projects: this.projectsService.getAll(),
      tasks: this.tasksService.getAll({ pageNumber: 1, pageSize: 5, sortBy: 'duedate', sortOrder: 'asc' }),
      completedTasks: this.tasksService.getAll({ statusId: 3, pageNumber: 1, pageSize: 1 })
    }).subscribe({
      next: ({ projects, tasks, completedTasks }) => {
        this.projects.set(projects.length);
        this.tasks.set(tasks.totalCount);
        this.completedProjects.set(projects.filter(x => x.statusId === 3).length);
        this.completedTasks.set(completedTasks.totalCount);
        this.projectList.set(projects.slice(0, 5));
        this.recentTasks.set(tasks.items);
        this.loading.set(false);
      },
      error: () => {
        this.apiError.set(true);
        this.loading.set(false);
      }
    });
  }

  projectStatusLabel(id: number): string {
    const item = this.projectStatuses.find(x => x.id === id);
    return this.languageService.language === 'ar' ? (item?.nameAr ?? '') : (item?.name ?? '');
  }

  taskStatusLabel(id: number): string {
    const item = this.taskStatuses.find(x => x.id === id);
    return this.languageService.language === 'ar' ? (item?.nameAr ?? '') : (item?.name ?? '');
  }

  statusColor(id: number): string { return id === 3 ? 'green' : id === 2 ? 'blue' : 'gold'; }
}
