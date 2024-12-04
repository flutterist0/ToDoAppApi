using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;

using Core.Helpers.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependency.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
			builder.RegisterType<UserManager>().As<IUserService>().InstancePerDependency();
			builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerDependency();

			builder.RegisterType<EfToDoDal>().As<IToDoDal>().SingleInstance();
			builder.RegisterType<ToDoManager>().As<IToDoService>().SingleInstance();

			builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<AppDbContext>().As<AppDbContext>().SingleInstance();
		
		}
	}
}
