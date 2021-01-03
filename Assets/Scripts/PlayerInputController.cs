using UnityEngine;
using UnityEngine.InputSystem;

namespace Baks.Core.Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        bool _turnLeft, _turnRight, _reverse, _accelerate;

        void FixedUpdate()
        {
            if (_accelerate)
                CarController.Instance.Accelerate();
            if (_reverse)
                CarController.Instance.Reverse();
            if (_turnLeft)
                CarController.Instance.TurnLeft();
            if (_turnRight)
                CarController.Instance.TurnRight();
        }
        
        public void OnAccelerate(InputValue inputValue) => _accelerate = inputValue.isPressed;
        
        public void OnReverse(InputValue inputValue) => _reverse = inputValue.isPressed;

        public void OnTurnLeft(InputValue inputValue) => _turnLeft = inputValue.isPressed;
        
        public void OnTurnRight(InputValue inputValue) => _turnRight = inputValue.isPressed;
    }
}