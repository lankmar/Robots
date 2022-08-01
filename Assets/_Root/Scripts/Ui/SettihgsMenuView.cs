using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class SettihgsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonSound;
        [SerializeField] private Button _buttonLanguege;
        [SerializeField] private Button _buttonExit;


        public void Init(UnityAction exittGame) =>
            _buttonExit.onClick.AddListener(exittGame);

        public void OnDestroy() =>
            _buttonExit.onClick.RemoveAllListeners();
    }
}