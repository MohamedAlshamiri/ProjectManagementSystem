export interface Task {
  id: number;
  projectId: number;
  projectName: string;
  title: string;
  description?: string | null;
  statusId: number;
  statusName: string;
  priorityId: number;
  priorityName: string;
  dueDate?: string | null;
  createdAt: string;
}

export interface CreateTaskRequest {
  projectId: number;
  title: string;
  description?: string | null;
  statusId: number;
  priorityId: number;
  dueDate?: string | null;
}

export interface UpdateTaskRequest {
  title: string;
  description?: string | null;
  statusId: number;
  priorityId: number;
  dueDate?: string | null;
}

export interface PagedResponse<T> {
  items: T[];
  pageNumber: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasPrevious: boolean;
  hasNext: boolean;
}
