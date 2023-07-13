using TravianTest.Snake.Models;
using UnityEngine;

namespace TravianTest.Snake.Logic
{
    public class SnakeCellLogic
    {
        protected GameConfig gameConfig;
        protected Vector2 currentPosition;
        public Direction LastDirection { get; private set; }
        
        public SnakeCellLogic Init(GameConfig gameConfig, Vector3 initPosition)
        {
            this.gameConfig = gameConfig;
            currentPosition = initPosition;
            return this;
        }
        
        public void Move(Direction direction)
        {
            var speed = gameConfig.CurrentLevelConfig().snakeSpeed * Time.deltaTime;
            switch (direction)
            {
                case Direction.Up:
                    currentPosition += Vector2.up * speed;
                    break;
                case Direction.Down:
                    currentPosition += Vector2.down * speed;
                    break;
                case Direction.Left:
                    currentPosition += Vector2.left * speed;
                    break;
                case Direction.Right:
                    currentPosition += Vector2.right * speed;
                    break;
            }
            LastDirection = direction;
        }
        
        public Vector3 Position() => currentPosition;

    }
}