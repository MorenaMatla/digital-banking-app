import { Component } from '@angular/core';
import { TransactionService } from '../../services/transaction.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-transfer',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './transfer.component.html',
  styleUrl: './transfer.component.css',
})
export class TransferComponent {
  fromAccountNumber: string = '';
  toAccountNumber: string = '';
  amount: number = 0;
  constructor(private transactionService: TransactionService) {}

  onSubmit() {
    this.transactionService
      .transfer(this.fromAccountNumber, this.toAccountNumber, this.amount)
      .subscribe((response) => {
        console.log('Transfer successful!', response);
      });
  }
}
