import { LookupOption } from '../models/project.model';

export const PROJECT_STATUSES: LookupOption[] = [
  { id: 1, name: 'Planning', nameAr: 'قيد التخطيط' },
  { id: 2, name: 'In Progress', nameAr: 'قيد التنفيذ' },
  { id: 3, name: 'Completed', nameAr: 'مكتمل' },
];

export const TASK_STATUSES: LookupOption[] = [
  { id: 1, name: 'To Do', nameAr: 'جديدة' },
  { id: 2, name: 'In Progress', nameAr: 'قيد التنفيذ' },
  { id: 3, name: 'Completed', nameAr: 'مكتملة' },
];

export const TASK_PRIORITIES: LookupOption[] = [
  { id: 1, name: 'Low', nameAr: 'منخفضة' },
  { id: 2, name: 'Medium', nameAr: 'متوسطة' },
  { id: 3, name: 'High', nameAr: 'عالية' },
];
