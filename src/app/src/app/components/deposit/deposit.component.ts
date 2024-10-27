import { Component } from '@angular/core';
import { TransactionService } from '../../services/transaction.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-deposit',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './deposit.component.html',
  styleUrl: './deposit.component.css',
})
export class DepositComponent {
  accountNumber: string = '';
  amount: number = 0;
  balance: number = 0;

  constructor(private transactionService: TransactionService) {}

  onSubmit() {
    this.transactionService.deposit(this.accountNumber, this.amount).subscribe(
      (data) => {
        this.balance = data;
      },
      (error) => {
        console.error('Error depositing to balance', error);
      }
    );
  }
}
