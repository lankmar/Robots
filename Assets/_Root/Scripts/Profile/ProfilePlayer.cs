using Features.Inventory;
using Game;
using Game.Robot;
using Profile.Analytic;
using Services.Analytics;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly RobotModel currentRobot;
        public readonly InventoryModel Inventory;
        public AnalyticsManager AnalyticsManager { get;}


        //public ProfilePlayer(float speedRobot, GameState initialState, AnalyticsManager analiticsMamager) : this(speedRobot)
        //{
        //    CurrentState.Value = initialState;
        //    AnalyticsManager = analiticsMamager;
        //    Inventory = new InventoryModel();
        //}

        //public ProfilePlayer(float speedRobot)
        //{
        //    CurrentState = new SubscriptionProperty<GameState>();
        //    currentRobot = new RobotModel(speedRobot, 5, 10, Game.RobotType.Default);
        //    Inventory = new InventoryModel();
        //}

        public ProfilePlayer(float transportSpeed, float transportJumpHeight, RobotType robotType, float armory, GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>(initialState);
            currentRobot = new RobotModel(transportSpeed, transportJumpHeight, robotType, armory);
            Inventory = new InventoryModel();
        }
    }
}
