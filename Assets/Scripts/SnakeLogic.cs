using System;
using System.Collections.Generic;
using System.Linq;
using TravianTest.Snake.Models;
using UnityEngine;

namespace TravianTest.Snake.Logic
{
    public class SnakeLogic
    {
        public int CurrentLength => _otherCells.Capacity + 1;

        private GameConfig _gameConfig;
        private Vector2 _currentPosition;

        private SnakeCellLogic _head;
        private List<SnakeCellLogic> _otherCells = new List<SnakeCellLogic>();

        public SnakeLogic Init(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _head = new SnakeCellLogic().Init(gameConfig, new Vector3(0, 0));
            _head.Init(gameConfig, Vector3.zero);
            var currentLevel = _gameConfig.CurrentLevelConfig();
            for (var i = 0; i < currentLevel.snakeInitialLenght; i++)
                _otherCells.Add(new SnakeCellLogic().Init(gameConfig, new Vector3(0,-i)));
            
            return this;
        }


        public void EatApple()
        {
            var lastCell = _head;
            if (_otherCells.Count>0)
                lastCell = _otherCells.Last();
            
            _otherCells.Add(new SnakeCellLogic().Init(_gameConfig, lastCell.Position()));
        }


        public Vector3 HeadPosition() => _head.Position();
        public List<Vector3> OtherCellsPositions() => _otherCells.Select(c=>c.Position()).ToList();

        public void Move(Direction direction)
        {
            for (var i = _otherCells.Count - 1; i >= 0; i--)
            {
                var c = _otherCells[i];
                if (i==0)
                    c.Move(_head.LastDirection);
                else
                {
                    c.Move(_otherCells[i-1].LastDirection);
                }
            }
            _head.Move(direction);
        }
    }
}