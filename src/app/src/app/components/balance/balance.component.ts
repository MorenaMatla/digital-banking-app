import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-balance',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './balance.component.html',
  styleUrl: './balance.component.css',
})
export class BalanceComponent {
  accountNumber: string = '';
  balance: number | null = null;

  constructor(private accountService: AccountService) {}

  onSubmit() {
    this.accountService.getBalance(this.accountNumber).subscribe(
      (data) => {
        this.balance = data;
      },
      (error) => {
        console.error('Error fetching balance', error);
      }
    );
  }
}
