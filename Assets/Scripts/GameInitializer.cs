using System;
using TravianTest.Snake.Models;
using UnityEngine;

namespace TravianTest.Snake.Logic
{
    //starting point of the app
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;
        private DependencyManager _dependencyManager;
        private void Awake()
        {
            _dependencyManager = new DependencyManager().Init(gameConfig);
        }
    }
}