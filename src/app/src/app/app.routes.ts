import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountCreateComponent } from './components/account-create/account-create.component';
import { BalanceComponent } from './components/balance/balance.component';
import { DepositComponent } from './components/deposit/deposit.component';
import { TransactionHistoryComponent } from './components/transaction-history/transaction-history.component';
import { TransferComponent } from './components/transfer/transfer.component';

export const routes: Routes = [
  { path: 'account/create', component: AccountCreateComponent },
  { path: 'account/balance', component: BalanceComponent },
  { path: 'account/history', component: TransactionHistoryComponent },
  { path: 'account/deposit', component: DepositComponent },
  { path: 'transfer', component: TransferComponent },
  { path: '', redirectTo: '/account/create', pathMatch: 'full' }, // Redireciona para a página inicial se a rota for vazia
  { path: '**', redirectTo: '/account/create' }, // Redireciona para a página inicial em rotas desconhecidas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
