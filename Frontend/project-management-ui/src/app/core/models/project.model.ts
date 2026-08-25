export interface Project {
  id: number;
  name: string;
  description?: string | null;
  statusId: number;
  statusName: string;
  startDate?: string | null;
  endDate?: string | null;
  createdAt: string;
  tasksCount: number;
}

export interface CreateProjectRequest {
  name: string;
  description?: string | null;
  statusId: number;
  startDate?: string | null;
  endDate?: string | null;
}

export type UpdateProjectRequest = CreateProjectRequest;

export interface LookupOption {
  id: number;
  name: string;
  nameAr: string;
}
