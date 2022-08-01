using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Features.Factory
{
    internal interface IFactoryView
    {
        void Init(UnityAction apply, UnityAction back);
        void Deinit();
    }

    internal class FactoryView : MonoBehaviour, IFactoryView
    {
        [SerializeField] private Button _buttonApply;
        [SerializeField] private Button _buttonBack;


        private void OnDestroy() => Deinit();

        public void Init(UnityAction apply, UnityAction back)
        {
            _buttonApply.onClick.AddListener(apply);
            _buttonBack.onClick.AddListener(back);
        }

        public void Deinit()
        {
            _buttonApply.onClick.RemoveAllListeners();
            _buttonBack.onClick.RemoveAllListeners();
        }
    }
}
