import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Account {
  accountNumber: string;
  name: string;
}

export interface TransactionList {
  transactions: Transaction[];
}

export interface Transaction {
  description: string;
  amount: number;
  previousBalance: number;
  newBalance: number;
  date: Date;
}

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private apiUrl = 'http://localhost:5249/api/Account';

  constructor(private http: HttpClient) {}

  createAccount(account: Account): Observable<any> {
    return this.http.post(`${this.apiUrl}`, account);
  }

  getBalance(accountNumber: string): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/${accountNumber}/balance`);
  }

  getTransferHistory(accountNumber: string): Observable<TransactionList> {
    return this.http.get<TransactionList>(
      `${this.apiUrl}/${accountNumber}/trnHist`
    );
  }
}
