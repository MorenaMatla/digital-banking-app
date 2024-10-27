import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-transaction-history',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './transaction-history.component.html',
  styleUrl: './transaction-history.component.css',
})
export class TransactionHistoryComponent {
  accountNumber: string = '';

  transactionList: any = {};

  constructor(private accountService: AccountService) {}

  onSubmit() {
    this.accountService.getTransferHistory(this.accountNumber).subscribe(
      (data) => {
        this.transactionList = data;
      },
      (error) => {
        console.error('Error fetching transaction history', error);
      }
    );
  }
}
