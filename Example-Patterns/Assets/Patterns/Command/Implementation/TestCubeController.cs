using UnityEngine;

namespace Patterns.Command.Implementation {
    public class TestCubeController : MonoBehaviour{
        private CommandInvoker _invoker;
        private ICommand _moveCommand;

        private void Start() {
            _invoker = new CommandInvoker();
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                var position = transform.position;
                _moveCommand = new MoveCommand(gameObject, position, Direction.Up);
                _invoker.AddCommand(_moveCommand);
            }
            
            if (Input.GetKeyUp(KeyCode.Z)) {
                _invoker.Undo();                
            }
        }
    }
}