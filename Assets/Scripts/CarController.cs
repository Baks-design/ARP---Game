using UnityEngine;
using Baks.Core.Singletons;

namespace Baks.Core.Controllers
{
    public class CarController : Singleton<CarController>
    {
        public enum Direction
        {
            Idle,
            MoveForward,
            MoveBackward,
            TurnLeft,
            TurnRight
        }

        [SerializeField] Rigidbody m_carRigidBody = default;
        [SerializeField] float m_speed = 1f;
        [SerializeField] float m_torque = 1f;
        [SerializeField] float m_minSpeedBeforeTorque = .3f;
        [SerializeField] float m_minSpeedBeforeIdle = .2f;
        CarWheel[] _wheels;

        void Awake() => _wheels = GetComponentsInChildren<CarWheel>();

        void Update() 
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

        void AddWheelsSpeed(float speed)
        {

        }

        bool CanApplyTorque()
        {
            return true;
        }
    }
}