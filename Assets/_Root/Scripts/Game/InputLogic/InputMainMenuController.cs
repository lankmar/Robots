using Tool;
using UnityEngine;
namespace Game.InputLogic
{
    internal class InputMainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/EndlessMove");
        private BaseInputView _view;


        public InputMainMenuController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            SubscriptionProperty<float> upMove,
            SubscriptionProperty<float> downtMove,
            float speed)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, upMove, downtMove, speed);
        }

        private BaseInputView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            BaseInputView view = objectView.GetComponent<BaseInputView>();
            return view;
        }
    }
}