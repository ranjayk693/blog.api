using Blog.BAL.CustomExcption;
using Blog.BAL.Interface;
using Blog.BAL.Services;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Helper
{
    public static class ConfigurationBAL
    {
        public static void RegisterBALInit(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IUserServiceBAL, UserServiceBAL>();
            services.AddScoped<IBlogServiceBAL, BlogServiceBAL>();
            services.AddScoped<ICommonServiceBAL,CommonServiceBAL>();
            services.AddScoped<IReviewServiceBAL, ReviewServiceBAL>();
            services.AddSingleton<NotFoundException>();
            //services.AddScoped<Argon2>();
        }
    }
}
