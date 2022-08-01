using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class SettingsMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/SettingsMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly SettihgsMenuView _view;


        public SettingsMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(ExitGame);

            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var upMoveDiff = new SubscriptionProperty<float>();
            var downMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
            var inputMainMenuController = new InputMainMenuController(leftMoveDiff, rightMoveDiff, upMoveDiff, downMoveDiff);
            AddController(inputMainMenuController);
        }

        private SettihgsMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettihgsMenuView>();
        }

        private void ExitGame() =>
            _profilePlayer.CurrentState.Value = GameState.Start;

        private void SettingsGame() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;
    }
}