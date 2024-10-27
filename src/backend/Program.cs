using financial_banking.Application.DTOs.Validators;
using financial_banking.Application.Interfaces;
using financial_banking.Application.Services;
using financial_banking.Infra.Data;
using financial_banking.Infra.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() 
                    .AllowAnyMethod() 
                    .AllowAnyHeader(); 
        });
});


builder.Services.AddSingleton<MongoContext>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAccountDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TransferDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DepositAccountDtoValidator>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("AllowAll");


app.Run();
