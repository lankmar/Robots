using Profile;
using Profile.Analytic;
using Services.Ads.UnityAds;
using Services.Analytics;
using UnityEngine;

namespace Robots
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private float _speedRobot = 5;
        [SerializeField] private GameState _initialState = GameState.Start;
        [SerializeField] private UnityAdsService _adsService;
        [SerializeField] private AnalyticsManager  _analyticsManager;

        [Header("Scene Objects")]
        [SerializeField] private Transform _placeForUi;

        [SerializeField] private MainController _mainController;

        void Awake()
        {
            _analyticsManager ??= GameObject.FindObjectOfType<AnalyticsManager>();
            var profilePlayer = new ProfilePlayer(_speedRobot, _initialState, _analyticsManager);
           
            _mainController = new MainController(_placeForUi, profilePlayer);

            _adsService ??= GameObject.FindObjectOfType <UnityAdsService>();

            if (_adsService.IsInitialized) OnAdsInitialised();
            else _adsService.Initialized.AddListener(OnAdsInitialised);
        }

        private void OnAdsInitialised()
        {
            _adsService.InterstitialPlayer.Play();
        }

        private void OnDestroy()
        {
            _adsService.Initialized.RemoveListener(OnAdsInitialised);
            _mainController.Dispose();
        }
    }
}