using Microsoft.Extensions.DependencyInjection;
using TUUBIB.Repositories;

namespace TUUBIB
{
    public class DependacyInjection
    {
        public static void Inject(ref IServiceCollection services)
        {
            services.AddScoped<BookRepository, BookRepository>();
        }
    }
}