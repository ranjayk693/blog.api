using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Blog.DAL.Data;
using Blog.DAL.Interface;
using Blog.DAL.Services;

namespace Blog.DAL.Helper
{
    public static class ConfigurationDAL
    {
        public static void RegisterDALInit(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ContextDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUserServiceDAL, UserServiceDAL>();
            services.AddScoped<ICommonServiceDAL, CommonServiceDAL>();
            services.AddScoped<IBlogServiceDAL, BlogServiceDAL>();
            services.AddScoped<IReviewServiceDAL, ReviewServiceDAL>();
            services.AddScoped(typeof(IGenericServiceDAL<>), typeof(GenericServiceDAL<>));
        }
    }
}
