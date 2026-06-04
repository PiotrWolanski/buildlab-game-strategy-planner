import { Component } from '@angular/core';
import { BuildListComponent } from './components/build-list/build-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BuildListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}