using JoostenProductions;
using System;
using UnityEngine;

namespace Game.TapeBackground
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class Background : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _relativeSpeedRate = 500;

        private Vector2 _size;
        private Vector3 _cachedPosition;

        private float LeftBorder => _cachedPosition.x - _size.x / 2;
        private float RightBorder => _cachedPosition.x + _size.x / 2;

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

            if (position.x <= LeftBorder)
            {
                position = transform.position;
                return;
            }
            if (position.x >= RightBorder)
            {
                position = transform.position;
                return;
            }
            transform.position = position;
        }
    }
}
