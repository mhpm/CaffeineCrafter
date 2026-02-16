import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './services/api.service';
import { Category } from './models/category.model';
import { Product } from './models/product.model';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
})
export class App implements OnInit {
  protected readonly title = signal('CaffeineCrafter Client');
  categories = signal<Category[]>([]);
  products = signal<Product[]>([]);

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.loadCategories();
    this.loadProducts();
  }

  private loadCategories() {
    this.apiService.getCategories().subscribe({
      next: (data) => {
        this.categories.set(data);
        console.log('Categories loaded:', data);
      },
      error: (err) => console.error('Error loading categories:', err),
    });
  }

  private loadProducts() {
    this.apiService.getProducts().subscribe({
      next: (data) => {
        this.products.set(data.slice(0, 4)); // Get top 4 for the "Best Collection" section
        console.log('Products loaded:', data);
      },
      error: (err) => console.error('Error loading products:', err),
    });
  }
}
