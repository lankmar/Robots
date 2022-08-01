using Features.AbilitySystem;
using Tool;
using UnityEngine;

namespace Game.Robot
{
    internal class RobotController : BaseController, IAbilityActivator
    {

        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Robot");
        private readonly RobotView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public float JumpHeight => throw new System.NotImplementedException();

        public RobotController(SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            
            var robotMoveController = new RobotMoveController(leftMove, rightMove, _view);
            AddController(robotMoveController);
        }

        private RobotView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<RobotView>();
        }
    }
}
