import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  private apiUrl = 'http://localhost:5249/api/Transaction';

  constructor(private http: HttpClient) {}

  deposit(accountNumber: string, amount: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/deposit`, { accountNumber, amount });
  }

  transfer(
    fromAccountNumber: string,
    toAccountNumber: string,
    amount: number
  ): Observable<any> {
    return this.http.post(`${this.apiUrl}/transfer`, {
      fromAccountNumber,
      toAccountNumber,
      amount,
    });
  }
}
