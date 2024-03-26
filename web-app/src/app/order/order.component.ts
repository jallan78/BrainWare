import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  standalone: true,
  imports: [CommonModule, RouterModule],
  selector: 'order',
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss',
})
export class OrderComponent implements OnInit {
  orders: any[] = [];
  year = new Date().getFullYear();
  title = 'order';

  constructor(private apiService: ApiService) {}

  public ngOnInit() {
    this.apiService.sendQuery('1').subscribe((data) => {
      this.orders = data;
    });
  }
}
