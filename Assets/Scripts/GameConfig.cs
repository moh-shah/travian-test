using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace TravianTest.Snake.Models
{
    [CreateAssetMenu(menuName = "Snake/Configs", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [FormerlySerializedAs("snakePresenterPrefab")] 
        public GameObject snakeHeadPresenterPrefab;
        public GameObject snakeCellPresenterPrefab;

        public int currentLevel;

        public int gameUpdateRate = 2;
        
        [SerializeField] private LevelConfig[] levelConfigs;

        public LevelConfig CurrentLevelConfig()
        {
            return levelConfigs.First(l => l.levelIndex == currentLevel);
        }
    }

    [Serializable]
    public class LevelConfig
    {
        public int levelIndex;
        public int appleTarget;
        public float enemySpawnRate;
        [Tooltip("Per Second")]
        public float shootingRate;
        public int snakeInitialLenght;
        public int increaseLengthPerAppleConsumed;
        public float snakeSpeed;
        public float bulletSpeed;
    }
}