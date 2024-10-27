import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService, Account } from '../../services/account.service';

@Component({
  selector: 'app-account-create',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './account-create.component.html',
  styleUrl: './account-create.component.css',
})
export class AccountCreateComponent {
  account: Account = { accountNumber: '', name: '' };

  constructor(private accountService: AccountService) {}

  onSubmit() {
    this.accountService.createAccount(this.account).subscribe((response) => {
      console.log('Account created successfully!', response);
    });
  }
}
