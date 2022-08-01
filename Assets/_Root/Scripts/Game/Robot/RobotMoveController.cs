using Tool;
using UnityEngine;

namespace Game.Robot
{
    internal class RobotMoveController : BaseController
    {
        private readonly SubscriptionProperty<float> _diff;
        private readonly ISubscriptionProperty<float> _leftMove;
        private readonly ISubscriptionProperty<float> _rightMove;

        private RobotView _view;


        public RobotMoveController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove, RobotView view)
        {
            _view = view;
            _diff = new SubscriptionProperty<float>();

            _leftMove = leftMove;
            _rightMove = rightMove;

            _view.Init(_diff);

            _leftMove.SubscribeOnChange(MoveLeft);
            _rightMove.SubscribeOnChange(MoveRight);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscribeOnChange(MoveLeft);
            _rightMove.UnSubscribeOnChange(MoveRight);
        }

        private void MoveLeft(float value)
        {
            _diff.Value = -value;
        }
         //private void MoveLeft(float value) =>
         //   _diff.Value = -value;

        private void MoveRight(float value) =>
            _diff.Value = value;
    }
}