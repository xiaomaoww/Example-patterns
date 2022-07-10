using System;
using UnityEngine;

namespace Patterns.Command.Implementation {
    public class MoveCommandReceiver {
        public Vector3 MoveOperation(GameObject gameObjectToMove, Vector3 position, Direction direction) {
            var updatedPosition = position;

            updatedPosition += direction switch {
                Direction.Up => Vector3.up,
                Direction.Down => Vector3.down,
                Direction.Left => Vector3.left,
                Direction.Right => Vector3.right,
                Direction.None => Vector3.zero,
                _ => throw new ArgumentOutOfRangeException($"Unknown direction: {direction}")
            };

            gameObjectToMove.transform.position = updatedPosition;
            return updatedPosition;
        }
    }
}