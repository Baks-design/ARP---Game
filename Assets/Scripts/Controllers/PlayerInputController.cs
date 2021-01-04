using UnityEngine.InputSystem;
using Baks.Core.Singletons;

namespace Baks.Core.Controllers
{
    public class PlayerInputController : Singleton<PlayerInputController>
    {
        private bool _turnLeft, _turnRight, _reverse, _accelerate;

        private CarController _carController;

        public void Bind(CarController carController)
        {
            this._carController = carController;
        }

        private void FixedUpdate()
        {
            if (_accelerate)
                _carController.Accelerate();

            if (_reverse)
                _carController.Reverse();

            if (_turnLeft)
                _carController.TurnLeft();

            if (_turnRight)
                _carController.TurnRight();
        }
        
        public void OnAccelerate(InputValue inputValue) => _accelerate = inputValue.isPressed;
        
        public void OnReverse(InputValue inputValue) => _reverse = inputValue.isPressed;

        public void OnTurnLeft(InputValue inputValue) => _turnLeft = inputValue.isPressed;
        
        public void OnTurnRight(InputValue inputValue) => _turnRight = inputValue.isPressed;
    }
}