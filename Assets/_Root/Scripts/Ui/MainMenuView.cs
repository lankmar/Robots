using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Tool.Tween;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _productId;


        [Header("Popup")]
        [SerializeField] private Button _buttonOpenPopup;
        [SerializeField] private PopupView _popupView;


        [Header("Buttons")]
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonFactory;
        [SerializeField] private Button _buttonAdsReward;
        [SerializeField] private Button _buttonBuyProduct;


        public void Init(UnityAction startGame, UnityAction settings, UnityAction factory,
            UnityAction adsReward, UnityAction<string> buyProduct)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(settings);
            _buttonFactory.onClick.AddListener(factory);
            _buttonAdsReward.onClick.AddListener(adsReward);
            _buttonBuyProduct.onClick.AddListener(() => buyProduct(_productId));
            _buttonOpenPopup.onClick.AddListener(_popupView.ShowPopup);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonFactory.onClick.RemoveAllListeners();
            _buttonAdsReward.onClick.RemoveAllListeners();
            _buttonBuyProduct.onClick.RemoveAllListeners();
            _buttonOpenPopup.onClick.RemoveAllListeners();
        }

        public void Init(UnityAction startGame, UnityAction settings)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(settings);

        }
    }
}
