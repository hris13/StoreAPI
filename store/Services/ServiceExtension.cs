using store.Models;
using store.Repo;
using store.Repo.Interfaces;
using store.Services.Interfaces;

namespace store.Services
{
    public static class ServiceExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IAdressRepository, AddressRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddDbContext<StoreContext>();
        }
    }
}
