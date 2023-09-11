using Application.Handlers.Account.Command.Login;
using Application.Handlers.Account.Command.Register;
using Application.Mediator;
using Microsoft.AspNetCore.Builder;

namespace Application.Endpoints;
public static class AccountEndpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        const string ENDPOINT = "Account";

        app.MediatorPost<RegisterCommand, RegisterResponse>("Register", ENDPOINT);
        app.MediatorPost<LoginCommand, LoginResponse>("Login", ENDPOINT);
    }
}

