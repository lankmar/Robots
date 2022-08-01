
using Features.Factory.Upgrade;

namespace Game.Robot
{

    internal class RobotModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;
        private readonly float _defaultArmory;

        public readonly RobotType Type;

        public float Speed { get; set; }
        public float JumpHeight { get; set; }
        public float Armory { get; set; }


        public RobotModel(float speed, float jumpHeight, RobotType type, float armory)
        {
            _defaultSpeed = speed;
            _defaultJumpHeight = jumpHeight;
            _defaultArmory = armory;
           
            Speed = speed;
            JumpHeight = jumpHeight;
            Armory = armory;
            Type = type;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpHeight = _defaultJumpHeight;
        }
    }
}