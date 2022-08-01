using Tool;
using UnityEngine;

namespace Game.Robot
{
    internal class RobotView : MonoBehaviour
    {
        [SerializeField] private Robot _robot;

        private ISubscriptionProperty<float> _diff;


        public void Init(ISubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }

        private void OnDestroy()
        {
            _diff?.UnSubscribeOnChange(Move);
        }


        private void Move(float value)
        {
            _robot.Move(value);

        }
    }
}
