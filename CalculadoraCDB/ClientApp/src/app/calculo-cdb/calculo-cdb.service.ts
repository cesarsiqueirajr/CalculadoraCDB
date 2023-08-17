import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalculoCdbService {
  private apiUrl = 'https://localhost:44404'; 

  constructor(private http: HttpClient) { }

  calcularInvestimento(valor: number, prazo: number): Observable<any> {
    const data = { valorInicial: valor, prazoEmMeses: prazo }; 
    return this.http.post(`${this.apiUrl}/calculocdb`, data);
  }
}
