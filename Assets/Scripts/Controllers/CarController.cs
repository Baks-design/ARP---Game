using UnityEngine;

namespace Baks.Core.Controllers
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] 
        private float m_speed = 1.0f;

        [SerializeField] 
        private float m_torque = 1.0f;

        [SerializeField] 
        private float m_minSpeedBeforeTorque = 0.3f;

        [SerializeField] 
        private float m_minSpeedBeforeIdle = 0.2f;

        [SerializeField] 
        private Rigidbody m_carRigidBody = default;

        private CarWheel[] _wheels;

        public enum Direction
        {
            Idle,
            MoveForward,
            MoveBackward,
            TurnLeft,
            TurnRight
        }

        private void Awake() => _wheels = GetComponentsInChildren<CarWheel>();

        private void Update() 
        {
            if (m_carRigidBody.velocity.magnitude <= m_minSpeedBeforeIdle)
                AddWheelsSpeed(0f);
        }

        public void Accelerate()
        {
            m_carRigidBody.AddForce(transform.forward * m_speed, ForceMode.Acceleration);
            AddWheelsSpeed(m_speed);
        }

        public void Reverse()
        {
            m_carRigidBody.AddForce(-transform.forward * m_speed, ForceMode.Acceleration);
            AddWheelsSpeed(-m_speed);
        }

        public void TurnLeft()
        {
            if (CanApplyTorque())
                m_carRigidBody.AddTorque(transform.up * -m_torque);
        }

        public void TurnRight()
        {
            if (CanApplyTorque())
                m_carRigidBody.AddTorque(transform.up * m_torque);
        }

        private void AddWheelsSpeed(float speed)
        {

        }

        private bool CanApplyTorque()
        {
            return true;
        }
    }
}