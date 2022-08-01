using Profile;
using Tool;
using Game.TapeBackground;
using UnityEngine;
using Object = UnityEngine.Object;
using Game.InputLogic;
using Services;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Ui/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, Settings, Factory, AdsReward, BuyProduct);

            SubscribeAds();
            SubscribeIAP();

            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var upMoveDiff = new SubscriptionProperty<float>();
            var downMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
            var inputMainMenuController = new InputMainMenuController(leftMoveDiff, rightMoveDiff, upMoveDiff, downMoveDiff);
            AddController(inputMainMenuController);
        }

        protected override void OnDispose()
        {
            //UnsubscribeAds();
            UnsubscribeIAP();
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;

        private void Settings() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

        private void Factory() =>
            _profilePlayer.CurrentState.Value = GameState.Factory;

        private void AdsReward() =>
            ServiceRoster.AdsService.RewardedPlayer.Play();

        private void BuyProduct(string productId) =>
            ServiceRoster.IAPService.Buy(productId);

        private void SubscribeAds()
        {
            //ServiceRoster.AdsService.RewardedPlayer.Finished += OnAdsFinished;
            //ServiceRoster.AdsService.RewardedPlayer.Failed += OnAdsCancelled;
            //ServiceRoster.AdsService.RewardedPlayer.Skipped += OnAdsCancelled;
        }

        private void UnsubscribeAds()
        {
            ServiceRoster.AdsService.RewardedPlayer.Finished -= OnAdsFinished;
            ServiceRoster.AdsService.RewardedPlayer.Failed -= OnAdsCancelled;
            ServiceRoster.AdsService.RewardedPlayer.Skipped -= OnAdsCancelled;
        }

        private void SubscribeIAP()
        {
            ServiceRoster.IAPService.PurchaseSucceed.AddListener(OnIAPSucceed);
            ServiceRoster.IAPService.PurchaseFailed.AddListener(OnIAPFailed);
        }

        private void UnsubscribeIAP()
        {
            ServiceRoster.IAPService.PurchaseSucceed.RemoveListener(OnIAPSucceed);
            ServiceRoster.IAPService.PurchaseFailed.RemoveListener(OnIAPFailed);
        }

        private void OnAdsFinished() => Debug.Log("You've received a reward for ads!");
        private void OnAdsCancelled() => Debug.Log("Receiving a reward for ads has been interrupted!");

        private void OnIAPSucceed() => Debug.Log("Purchase succeed");
        private void OnIAPFailed() => Debug.Log("Purchase failed");
       
        
       
    }
}
