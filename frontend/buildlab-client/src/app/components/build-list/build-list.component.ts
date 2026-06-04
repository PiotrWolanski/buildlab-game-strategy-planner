import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BuildPlan } from '../../models/build-plan';
import { BuildPlanService } from '../../services/build-plan.service';

@Component({
  selector: 'app-build-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './build-list.component.html',
  styleUrl: './build-list.component.css'
})
export class BuildListComponent implements OnInit {
  buildPlans: BuildPlan[] = [];
  isLoading = false;
  errorMessage = '';

  constructor(private buildPlanService: BuildPlanService) {}

  ngOnInit(): void {
    this.loadBuildPlans();
  }

  loadBuildPlans(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.buildPlanService.getBuildPlans().subscribe({
      next: (buildPlans) => {
        this.buildPlans = buildPlans;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Could not load build plans. Please check if the backend API is running.';
        this.isLoading = false;
      }
    });
  }
}