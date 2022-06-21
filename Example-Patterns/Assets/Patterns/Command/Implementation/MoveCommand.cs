using System;
using UnityEngine;

namespace Patterns.Command.Implementation {
    public sealed class MoveCommand : Command {
        private readonly Vector3 _initialPosition;
        private readonly Direction _direction;
        private readonly MoveCommandReceiver _receiver;

        public MoveCommand(Vector3 initialPosition, Direction direction) {
            _receiver = new MoveCommandReceiver();

            _initialPosition = initialPosition;
            _direction = direction;
        }

        public override void Execute() {
            _receiver.MoveOperation(_initialPosition, _direction);
        }

        public override void Undo() {
            _receiver.MoveOperation(_initialPosition, InverseDirection(_direction));
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