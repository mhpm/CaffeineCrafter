import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './services/api.service';
import { Category } from './models/category.model';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
})
export class App implements OnInit {
  protected readonly title = signal('CaffeineCrafter Client');
  categories = signal<Category[]>([]);

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.apiService.getCategories().subscribe({
      next: (data) => {
        this.categories.set(data);
        console.log('Categories loaded:', data);
      },
      error: (err) => console.error('Error loading categories:', err),
    });
  }
}
