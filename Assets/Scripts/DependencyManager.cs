using TravianTest.Snake.Models;
using TravianTest.Snake.Presenters;

namespace TravianTest.Snake.Logic
{
    //just a simple singleton for now 
    public class DependencyManager // maybe an abstraction level like : IDependency manager for later...
    {
        public static DependencyManager Instance;

        public IFieldLogic fieldLogic;
        public GameConfig gameConfig;
        public SnakeLogic SnakeHeadLogic;
        
        public DependencyManager Init(GameConfig gameConfig)
        {
            Instance = this;
            this.gameConfig = gameConfig;
            fieldLogic = new FieldLogic();
            SnakeHeadLogic = new SnakeLogic().Init(gameConfig);
            return this;
        }
    }
}