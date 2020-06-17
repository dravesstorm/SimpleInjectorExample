using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Services.PL.Commands;

namespace DI.App.Services.PL
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>();
        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();

        public CommandProcessor(IEnumerable<ICommand> commands)
        {
            foreach (var item in commands)
            {
                this.commands.Add(item.Number, item);
            }
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        
    }
}