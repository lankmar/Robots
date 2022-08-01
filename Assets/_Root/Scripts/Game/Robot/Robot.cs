using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Robot
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class Robot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _relativeSpeedRate;

        private Vector2 _size;
        private Vector3 _cachedPosition;

        private void Awake()
        {
            _cachedPosition = transform.position;
            _size = _spriteRenderer.size;
        }

        private void OnValidate() =>
            _spriteRenderer ??= GetComponent<SpriteRenderer>();

        public void Move(float value)
        {
            Vector3 position = transform.position;

            position += Vector3.right * value * _relativeSpeedRate;

            transform.position = position;

            
        }
    }
}