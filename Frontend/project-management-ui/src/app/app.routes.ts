import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./layout/main-layout/main-layout')
        .then(m => m.MainLayout),

    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },

      {
        path: 'dashboard',
        loadComponent: () =>
          import('./features/dashboard/pages/dashboard/dashboard')
            .then(m => m.Dashboard)
      },

      {
        path: 'projects',
        loadComponent: () =>
          import('./features/projects/pages/project-list/project-list')
            .then(m => m.ProjectList)
      },

      {
        path: 'tasks',
        loadComponent: () =>
          import('./features/tasks/pages/task-list/task-list')
            .then(m => m.TaskList)
      },

      {
        path: 'settings',
        loadComponent: () =>
          import('./features/settings/pages/settings/settings')
            .then(m => m.Settings)
      }
    ]
  },

  {
    path: '**',
    redirectTo: 'dashboard'
  }
];
