using UnityEngine;
using JoostenProductions;
using System;
using UnityEngine.EventSystems;

namespace Game.InputLogic
{
    [RequireComponent(typeof(InputScreenButtonView))]
    internal class InputScreenButton : BaseInputView,  IPointerExitHandler// IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _inputMultiplier = 0.2f;
        [SerializeField] InputScreenButtonView _inputScreenButtonView;

        private void Start()
        {
            InputScreenButton inputScreenButton = gameObject.GetComponent<InputScreenButton>();
            _inputScreenButtonView ??= gameObject.GetComponent<InputScreenButtonView>();
            _inputScreenButtonView.Init(MoveRight, MoveLeft, Jump, ShildActivation);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void ShildActivation()
        {
            Debug.Log("Ùèò ");
        }

        private void MoveRight()
        {
            _isButtonSelected = true;
            _curentButton = "Right";
            OnRightMove(_inputMultiplier * Time.deltaTime);

        }

        private void MoveLeft()
        {
            _isButtonSelected = true;
            _curentButton = "Left";
            OnLeftMove(-_inputMultiplier * Time.deltaTime);
        }

        private void Jump()
        {
            OnUpMove(_inputMultiplier * Time.deltaTime);
        }


        protected override void Move()
        {

            if (!_isButtonSelected) return;

            if (_curentButton == "Left")
            {
                MoveLeft();
            }
            if (_curentButton == "Right")
            {
                MoveRight();
            }

            }

      
        public void OnPointerExit(PointerEventData eventData)
        {
            _isButtonSelected = false;
            _curentButton = " _ ";
            Move();
        }

        bool _isButtonSelected = false;
        string _curentButton = " _ ";
    }
}
