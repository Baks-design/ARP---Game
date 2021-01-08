using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Baks.Core.Extensions;

namespace Baks.Core.Controllers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_prefab = default;

        [SerializeField]
        private Camera m_arCamera = default;

        [SerializeField]
        private LayerMask m_layerToInclude = default;

        private GameObject _carController;

        private void Awake() => EnhancedTouchSupport.Enable();

        private void Update() 
        {
            var activeTouches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;
            if (activeTouches.Count > 0)
            {
                var touch = activeTouches[0];
                bool isOverUI = touch.screenPosition.IsPointOverUIObject();
                if (isOverUI) 
                    return;

                if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    var ray = m_arCamera.ScreenPointToRay(touch.screenPosition);
                    var hasHit = Physics.Raycast(ray, out var hit, float.PositiveInfinity, m_layerToInclude);
                    if (hasHit && _carController == null)
                    {
                        _carController = Instantiate(m_prefab, hit.point, Quaternion.identity);
                        PlayerInputController.Instance.Bind(_carController.GetComponent<CarController>());
                    }
                }
            }
        }
    }
}