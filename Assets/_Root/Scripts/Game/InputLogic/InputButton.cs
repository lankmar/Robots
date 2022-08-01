using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputButton : BaseInputView
    {
        [SerializeField] private float _inputMultiplier = 0.05f;

        protected override void Move()
        {
            Vector3 direction = CalcDirection();
            
            float moveValue = _inputMultiplier * Time.deltaTime * direction.x;

            if (direction.x > 0)
            {
                OnRightMove(moveValue);
            }
            else if (direction.x<0)
            {
                OnLeftMove(moveValue);
            }

            if (direction.z > 0)
            {
                OnUpMove(moveValue);
            }
            else if (direction.z < 0)
            {
                OnDownMove(moveValue);
            }
        }

        private Vector3 CalcDirection()
        {
            const float normalizedMagnitude = 1;

            Vector3 direction = Vector3.zero;
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");

            if (direction.sqrMagnitude > normalizedMagnitude)
                direction.Normalize();

            return direction;
        }
    }
}