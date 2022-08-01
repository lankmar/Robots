using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.InputLogic
{
    public class InputScreenButtonView : MonoBehaviour
    {
        [SerializeField] public Button _moveRight;
        [SerializeField] public Button _moveLeft;
        [SerializeField] public Button _jump;
        [SerializeField] public Button _shild;


        public void Init(UnityAction moveRight, UnityAction moveLeft, UnityAction jump, UnityAction shild)
        {
            _moveRight.onClick.AddListener(moveRight);
            _moveLeft.onClick.AddListener(moveLeft);
            _jump.onClick.AddListener(jump);
            _shild.onClick.AddListener(shild);
        }

        public void OnDestroy()
        {
            _moveRight.onClick.RemoveAllListeners();
            _moveLeft.onClick.RemoveAllListeners();
            _jump.onClick.RemoveAllListeners();
            _shild.onClick.RemoveAllListeners();
        }
    }
}