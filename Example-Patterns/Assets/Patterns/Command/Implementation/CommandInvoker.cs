using System.Collections.Generic;

namespace Patterns.Command.Implementation {
    public class CommandInvoker {
        private int _currentIndex;
        private readonly List<ICommand> _history = new List<ICommand>();

        public void AddCommand(ICommand command) {
            _history.Add(command);
            command.Execute();
            _currentIndex++;
        }

        public void Undo() {
            if (_history.Count == 0 || _history.Count > _currentIndex) {
                return;
            }
            
            var currentCommand = _history[_currentIndex - 1];
            currentCommand.Undo();
            _history.Remove(currentCommand);
            _currentIndex--;
        }
    }
}