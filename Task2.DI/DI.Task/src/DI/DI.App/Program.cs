using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Models;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using SimpleInjector;
using System.Collections.Generic;

namespace DI.App
{
    internal class Program
    {

        private static readonly Container container;

        static Program()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            container.Register<IDatabaseService, InMemoryDatabaseService>(Lifestyle.Singleton);
            container.Register<IUserStore, UserStore>();
            container.Register<IUser, User>();
            container.Register<ICommandProcessor, CommandProcessor>();
            container.Collection.Register<ICommand>(typeof(AddUserCommand), typeof(ListUsersCommand));
            container.Register<CommandManager>();


            // 3. Verify your configuration
            container.Verify();
        }

        private static void Main()
        {
            // Inversion of Control
            var manager = container.GetInstance<CommandManager>();

            manager.Start();
        }
    }
}
