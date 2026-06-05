import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BuildPlan } from '../models/build-plan';

@Injectable({
  providedIn: 'root'
})
export class BuildPlanService {
  private readonly apiUrl = 'http://localhost:5153/api/buildplans';

  constructor(private http: HttpClient) {}

  getBuildPlans(): Observable<BuildPlan[]> {
    return this.http.get<BuildPlan[]>(this.apiUrl);
  }

  getBuildPlanById(id: number): Observable<BuildPlan> {
    return this.http.get<BuildPlan>(`${this.apiUrl}/${id}`);
  }

  createBuildPlan(buildPlan: Omit<BuildPlan, 'id' | 'createdAt'>): Observable<BuildPlan> {
    return this.http.post<BuildPlan>(this.apiUrl, buildPlan);
  }

  updateBuildPlan(id: number, buildPlan: BuildPlan): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, buildPlan);
  }

  deleteBuildPlan(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}