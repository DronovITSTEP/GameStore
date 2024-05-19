using Domain.Abstract;
using Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        public void AddBindings() { 
            Mock<IGameRepository> mock = new Mock<IGameRepository> ();
            mock.Setup(m => m.Games).Returns(new List<Game>
            {
                new Game
                {
                    Name = "Assassin's",
                    Price = 4999
                },
                new Game
                {
                    Name = "Call of Duty",
                    Price = 5699
                },
                new Game
                {
                    Name = "The Last of Us 2",
                    Price = 4599
                }
            });

            kernel.Bind<IGameRepository>().ToConstant(mock.Object);
        }
    }
}