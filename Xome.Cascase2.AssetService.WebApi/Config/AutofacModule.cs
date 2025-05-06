using Autofac;
using LazyProxy.Autofac;
using Xome.Cascase2.AssetService.Application.Services;
using Xome.Cascase2.AssetService.Domain.Interfaces;
using Xome.Cascase2.AssetService.Infrastructure.Repositories;
using Xome.Cascase2.AssetService.Infrastructure.UnitOfWork;

namespace Xome.Cascase2.AssetService.WebApi.Config
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLazy<IAssetRepository, AssetRepository>().InstancePerLifetimeScope();
            builder.RegisterLazy<IUnitOfWork, UnitOfWork>().InstancePerLifetimeScope();
            // builder.RegisterLazy<IUserService, UserService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
