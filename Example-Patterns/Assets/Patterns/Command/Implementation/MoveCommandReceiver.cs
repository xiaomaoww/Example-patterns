using System;
using UnityEngine;

namespace Patterns.Command.Implementation {
    public class MoveCommandReceiver {
        public Vector3 MoveOperation(Vector3 position, Direction direction) {
            var updatedPosition = position;

            updatedPosition += direction switch {
                Direction.Up => Vector3.up,
                Direction.Down => Vector3.down,
                Direction.Left => Vector3.left,
                Direction.Right => Vector3.right,
                _ => throw new ArgumentOutOfRangeException($"Unknown direction: {direction}")
            };

            return updatedPosition;
        }
    }
}