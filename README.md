# Digital Banking Application

This is a digital banking application developed using Angular for the frontend and ASP.NET Core for the backend. The application allows users to create accounts, check balances, view transaction history, make deposits, and transfer money between accounts.

## Features

- Create user accounts with unique account numbers.
- View account balance.
- View transaction history.
- Make deposits to accounts.
- Transfer money between accounts.

## Technologies Used

- **Frontend:** Angular
- **Backend:** ASP.NET Core
- **Database:** MongoDB (Non-relational)
- **State Management:** Services in Angular
- **Routing:** Angular Router
- **HTTP Client:** Angular HttpClient for API calls

## API Endpoints

| Method | Endpoint                             | Description                     |
| ------ | ------------------------------------ | ------------------------------- |
| POST   | /api/Account                         | Create a new account            |
| PUT    | /api/Account/{accountNumber}         | Update an account               |
| DELETE | /api/Account/{accountNumber}         | Delete an account               |
| GET    | /api/Account/{accountNumber}         | Get an account details          |
| GET    | /api/Account/{accountNumber}/balance | Get account balance             |
| GET    | /api/Account/{accountNumber}/trnHist | Get transaction history         |
| POST   | /api/Transaction/deposit             | Deposit money into an account   |
| POST   | /api/Transaction/transfer            | Transfer money between accounts |

## Frontend Routing

The frontend uses Angular Router for navigation. Here are the key routes:

/account/create: Create a new account.
/account/balance: View account balance.
/account/history: View transaction history.
/account/deposit: Deposit money into an account.
/transfer: Transfer money between accounts.
