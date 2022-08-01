using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Robot.Animation
{
    public enum AnimState
    {
        Idle,
        Walk,
        Jump
    }

    [CreateAssetMenu(fileName = "SpriteAnimatorConfig", menuName = "Configs/ Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Header("AnimationList")]
        public List<SpriteSequence> Sequences;
        
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

    }
}