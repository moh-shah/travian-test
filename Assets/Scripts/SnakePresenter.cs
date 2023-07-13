using System;
using System.Collections.Generic;
using TravianTest.Snake.Logic;
using TravianTest.Snake.Models;
using UnityEngine;

namespace TravianTest.Snake.Presenters
{
    public class SnakePresenter : MonoBehaviour
    {
        private SnakeLogic _snakeHeadLogic;
        private GameConfig _gameConfig;
        private int _frameCounter;
        
        private Direction _lastChosenDirection;
        private List<GameObject> _otherCells = new List<GameObject>();
        
        private void Start()
        {
            _snakeHeadLogic = DependencyManager.Instance.SnakeHeadLogic;
            _gameConfig = DependencyManager.Instance.gameConfig;
            UpdateView();
        }

        private void Update()
        {
            _frameCounter++;
            if (_frameCounter < _gameConfig.gameUpdateRate)
                return;
            
            _frameCounter = 0;
            ActualUpdate();
        }

        private void ActualUpdate()
        {
            ProcessInputs();
            UpdateView();
        }

        private void ProcessInputs()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) _lastChosenDirection = Direction.Up;
            if (Input.GetKeyDown(KeyCode.DownArrow)) _lastChosenDirection = Direction.Down;
            if (Input.GetKeyDown(KeyCode.RightArrow)) _lastChosenDirection = Direction.Right;
            if (Input.GetKeyDown(KeyCode.LeftArrow)) _lastChosenDirection = Direction.Left;
            
            _snakeHeadLogic.Move(_lastChosenDirection);
        }

        private void UpdateView()
        {
            transform.position = _snakeHeadLogic.HeadPosition();
            var othersPositions = _snakeHeadLogic.OtherCellsPositions();
            for (var i = 0; i < othersPositions.Count; i++)
            {
                if (i >= _otherCells.Count)
                {
                    _otherCells.Add(Instantiate(_gameConfig.snakeCellPresenterPrefab, othersPositions[i],Quaternion.identity));
                }
                else
                {
                    _otherCells[i].transform.position = othersPositions[i];
                }
            }
        }
    }
}