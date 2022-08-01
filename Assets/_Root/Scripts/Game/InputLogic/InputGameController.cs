using Game.Robot;
using Tool;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputGameController : BaseController
    {
        //private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MobileSingleStickControl");
        //private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/KeyboardMove");
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/InputScreenButton");
        private BaseInputView _view;


        public InputGameController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            SubscriptionProperty<float> upMove,
            SubscriptionProperty<float> downtMove,
            Transform placeForUi)
        {
            _view = LoadView(placeForUi);
            _view.Init(leftMove, rightMove, upMove, downtMove);
        }

        private BaseInputView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            BaseInputView view = objectView.GetComponent<BaseInputView>();
            return view;
        }
    }
}
