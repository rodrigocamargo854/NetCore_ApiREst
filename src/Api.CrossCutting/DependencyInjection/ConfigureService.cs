using Api.Domain.Interfaces.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {


        public static void ConfigureDependencyService(IServiceCollection serviceCollection)
        {
            //?aceita atualização com f5
            // serviceCollection.AddScoped<IUserService, UserServices>();
            //?A injeção é feita somente uma vez
            // serviceCollection.AddSingleton<IUserService, UserServices>();
            serviceCollection.AddTransient<IUserService, UserServices>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }

    }
}
