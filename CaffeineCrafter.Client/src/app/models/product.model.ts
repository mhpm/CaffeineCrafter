import { Category } from './category.model';

export interface Product {
  id: number;
  name: string;
  description: string;
  imageUrl: string;
  price: number;
  isActive: boolean;
  createdAt: string;
  updatedAt: string;
  categoriesId: number;
  category?: Category;
}
