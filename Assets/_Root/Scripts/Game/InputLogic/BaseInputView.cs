using Tool;
using UnityEngine;

namespace Game.InputLogic
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        private SubscriptionProperty<float> _upMove;
        private SubscriptionProperty<float> _downMove;
        protected float _speed = 5;


        public virtual void Init(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            SubscriptionProperty<float> upMove,
            SubscriptionProperty<float> downMove,
            float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _upMove = upMove;
            _downMove = downMove;
            _speed = speed;
        }

        protected void OnLeftMove(float value) =>
            _leftMove.Value = -value;

        protected void OnRightMove(float value) =>
            _rightMove.Value = value;

        protected virtual void OnUpMove(float value) =>
            _upMove.Value = -value;

        protected virtual void OnDownMove(float value) =>
            _downMove.Value = value;
    }
}
