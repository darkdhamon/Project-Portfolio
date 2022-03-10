import { ApiResponse } from '../view-models/ApiResponse';

export interface PagedApiResponse<T> extends ApiResponse<T> {
  page: number;
  numPerPage: number;
  totalPages: number;
}
