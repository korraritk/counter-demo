import { Component, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  // Backend API (รันใน Docker ที่ port 8080)
  apiBase = 'http://localhost:8080/api';
  count = signal(0);
  error = signal<string | null>(null);

  constructor(private http: HttpClient) {}

  click(op: 'count' | 'discount') {
    this.error.set(null);
    this.http.get<any>(`${this.apiBase}/${op}`).subscribe({
      next: (data) => this.count.set(data.count),
      error: (err) => this.error.set('เรียก API ไม่สำเร็จ: ' + (err.message ?? err.status))
    });
  }
}
