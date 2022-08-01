
using Features.Factory.Upgrade;

namespace Game.Robot
{
    //internal class RobotModel 
    //{
    //    private readonly float _defaultSpeed = 10;

    //    public readonly RobotType Type;

    //    public float Speed { get; set; }


    //    public RobotModel(float speed, RobotType type)
    //    {
    //        _defaultSpeed = speed;
    //        Speed = speed;
    //        Type = type;
    //    }

    //    public RobotModel(float speed)
    //    {
    //        _defaultSpeed = speed;
    //    }

    //    public void Restore() =>
    //        Speed = _defaultSpeed;
    //}

    internal class RobotModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;
        private readonly float _defaultArmory;

        public readonly RobotType Type;

        public float Speed { get; set; }
        public float JumpHeight { get; set; }
        public float Armory { get; set; }


        public RobotModel(float speed, float jumpHeight, float armory, RobotType type)
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