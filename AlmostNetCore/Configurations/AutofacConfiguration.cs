using AlmostNetCore.Controllers;
using AlmostNetCore.Data.Interfaces;
using AlmostNetCore.Services.Services;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlmostNetCore.Configurations
{
    public class AutofacConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<FileExecutorFactory>().As<IFileExecutorFactory>().SingleInstance();
            builder.RegisterType<MatrixService>().As<IMatrixService>().SingleInstance();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}