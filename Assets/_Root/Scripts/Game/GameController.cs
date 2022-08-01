using Game.Robot;
using Game.InputLogic;
using Profile;
using Tool;
using Services.Analytics;
using UnityEngine;
using Features.AbilitySystem;
using Services;
using Features.AbilitySystem.Abilities;
using System.Collections.Generic;

namespace Game
{
    internal class GameController : BaseController
    {
        //private AnalyticsManager _analyticsManager;

        private readonly ProfilePlayer _profilePlayer;
        Transform _placeForUi;
        private readonly SubscriptionProperty<float> _leftMoveDiff;
        private readonly SubscriptionProperty<float> _rightMoveDiff;
        private readonly SubscriptionProperty<float> _upMoveDiff;
        private readonly SubscriptionProperty<float> _downMoveDiff;


        private readonly InputGameController _inputGameController;
        private readonly IAbilitiesController _abilitiesController;
        private readonly RobotController _robotController;

        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            _leftMoveDiff = new SubscriptionProperty<float>();
            _rightMoveDiff = new SubscriptionProperty<float>();

            _inputGameController = CreateInputGameController();
            _robotController = CreateRobotController(profilePlayer.currentRobot);
            _abilitiesController = CreateAbilitiesController(placeForUi);

            ServiceRoster.Analytics.SendGameStarted();
        }


        private InputGameController CreateInputGameController()
        {
            var inputGameController = new InputGameController(_leftMoveDiff, _rightMoveDiff, _upMoveDiff, _downMoveDiff, _placeForUi);
            AddController(inputGameController);

            return inputGameController;
        }

        private IAbilitiesController CreateAbilitiesController(Transform placeForUi)
        {
            AbilityItemConfig[] abilityItemConfigs = LoadAbilityItemConfigs();
            AbilitiesRepository repository = CreateAbilitiesRepository(abilityItemConfigs);
            AbilitiesView view = LoadAbilitiesView(placeForUi);

            Debug.Log("_robotController " + _robotController);

            var abilitiesController = new AbilitiesController(view, repository, abilityItemConfigs, _robotController);
            AddController(abilitiesController);

            return abilitiesController;
        }

        private AbilityItemConfig[] LoadAbilityItemConfigs()
        {
            var path = new ResourcePath("Configs/Ability/AbilityItemConfigDataSource");
            return ContentDataSourceLoader.LoadAbilityItemConfigs(path);
        }

        private AbilitiesRepository CreateAbilitiesRepository(IEnumerable<IAbilityItem> abilityItemConfigs)
        {
            var repository = new AbilitiesRepository(abilityItemConfigs);
            AddRepository(repository);

            return repository;
        }

        private AbilitiesView LoadAbilitiesView(Transform placeForUi)
        {
            var path = new ResourcePath("Prefabs/Ability/AbilitiesView");

            GameObject prefab = ResourcesLoader.LoadPrefab(path);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }

        private RobotController CreateRobotController(RobotModel transportModel)
        {
            RobotController robotController =
                _profilePlayer.currentRobot.Type switch
                {
                    RobotType.Default => new RobotController(_leftMoveDiff, _rightMoveDiff),
                };

            AddController(robotController);

            return robotController;
        }


        //public GameController(ProfilePlayer profilePlayer, Transform placeForUi)
        //{
        //    var leftMoveDiff = new SubscriptionProperty<float>();
        //    var rightMoveDiff = new SubscriptionProperty<float>();
        //    var upMoveDiff = new SubscriptionProperty<float>();
        //    var downMoveDiff = new SubscriptionProperty<float>();

        //    //var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        //    //AddController(tapeBackgroundController);


        //    var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, upMoveDiff, downMoveDiff, profilePlayer.currentRobot.Speed, placeForUi);
        //    AddController(inputGameController);

        //    var robotController = new RobotController(leftMoveDiff, rightMoveDiff);
        //    AddController(robotController);

        //    profilePlayer.AnalyticsManager.SendGameOpened();
        //}
    }
}
