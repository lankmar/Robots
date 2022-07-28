using Game.Robot;
using Game.InputLogic;
using Profile;
using Tool;
using Services.Analytics;

namespace Game
{
    internal class GameController : BaseController
    {
        private AnalyticsManager _analyticsManager;
        public GameController(ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var upMoveDiff = new SubscriptionProperty<float>();
            var downMoveDiff = new SubscriptionProperty<float>();

            //var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            //AddController(tapeBackgroundController);


            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, upMoveDiff, downMoveDiff, profilePlayer.currentRobot.Speed);
            AddController(inputGameController);

            var robotController = new RobotController(leftMoveDiff, rightMoveDiff);
            AddController(robotController);

            profilePlayer.AnalyticsManager.SendGameOpened();
        }
    }
}
