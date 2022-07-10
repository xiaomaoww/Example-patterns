using System;
using UnityEngine;

namespace Patterns.Command.Implementation {
    public sealed class MoveCommand : Command {
        private readonly Vector3 _initialPosition;
        private readonly Direction _direction;
        private readonly MoveCommandReceiver _receiver;
        private readonly GameObject _gameObjectToMove;

        private Vector3 _lastPosition;

        public MoveCommand(GameObject gameObjectToMove, Vector3 initialPosition, Direction direction) {
            _receiver = new MoveCommandReceiver();

            _gameObjectToMove = gameObjectToMove;
            _initialPosition = initialPosition;
            _lastPosition = initialPosition;
            _direction = direction;
        }

        public override void Execute() {
            var newPos = _receiver.MoveOperation(_gameObjectToMove, _initialPosition, _direction);
            _lastPosition = newPos;
        }

        public override void Undo() {
            _receiver.MoveOperation(_gameObjectToMove, _lastPosition, InverseDirection(_direction));
        }

        private static Direction InverseDirection(Direction direction) {
            var inversedDirection = direction switch {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.None => direction,
                _ => throw new ArgumentOutOfRangeException($"Unknown direction: {direction}")
            };

            return inversedDirection;
        }
    }
}