using Microsoft.Extensions.DependencyInjection;
using ZemApp.Application.GenerateSampleData;
using ZemApp.Application.PostService;
using ZemApp.Application.UserService;
using ZemApp.Domain.Repository;
using ZemApp.Domain.Services;
using ZemApp.Infrastructure.MongoRepository.Repositories;

namespace ZemApp.Application
{
    public static class IocContainer
    {
        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddSingleton<ISampleDataUtil, SampleDataUtil>();
            services.AddSingleton<IPostRepository, PostRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IPostStatusRepository, PostStatusRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IBlogPostAppService, BlogPostAppService>();
            services.AddSingleton<IUserAppService, UserAppService>();
        }
    }
}