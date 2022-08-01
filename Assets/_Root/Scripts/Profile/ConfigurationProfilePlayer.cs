using Game;
using System;
using UnityEngine;

namespace Profile
{
    [CreateAssetMenu(fileName = nameof(ConfigurationProfilePlayer), menuName = "Configs/" + nameof(ConfigurationProfilePlayer))]
    internal class ConfigurationProfilePlayer : ScriptableObject
    {
        [field: SerializeField] public GameState State { get; private set; }
        [field: SerializeField] public InitialProfileRobot Robot { get; private set; }
    }

    [Serializable]
    internal class InitialProfileRobot
    {
        [field: SerializeField] public RobotType Type { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }
        [field: SerializeField] public float Armory { get; private set; }
    }
}

