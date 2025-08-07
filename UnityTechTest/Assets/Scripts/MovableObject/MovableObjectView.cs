using TMPro;
using UnityEngine;

namespace MovableObject
{
    public class MovableObjectView : MonoBehaviour
    {
        // set‑only properties for position and score
        [field: SerializeField] private TextMeshProUGUI scoreTMP;
        [field: SerializeField] private Rigidbody movableRb;

        private float _maxDistance;
        private bool _isInitialized;
        
        public void Initialize()
        {
            if (Camera.main == null)
            {
                Debug.LogError("Camera missing");
                return;
            }

            if (movableRb == null)
            {
                Debug.LogError("Rigidbody missing");
                return;
            }

            _maxDistance = Camera.main.transform.position.y;
            _isInitialized = true;
        }

        public bool IsMovableObjectClicked()
        {
            if (!_isInitialized) return false;
            
            if (!Input.GetMouseButtonUp(0)) return false;
        
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var direction = ray.direction * _maxDistance;
            var value = Physics.Raycast(ray.origin, direction, out var hit, _maxDistance,LayersGuide.MovableObjectLayer);
        
            if (value)
            {
                if (hit.collider == null) return false;

                var movableObject = hit.collider.gameObject;
                var rb = movableObject.GetComponent<Rigidbody>();
            
                if (rb != movableRb) return false;

                return true;
            }

            return false;
        }
    
        public void UpdateObjectPosition(Vector3 newPosition)
        {
            movableRb.MovePosition(newPosition);
        }
    
        public void UpdateScoreUI(int score)
        {
            scoreTMP.SetText($"{score}");
        
            // if (ServiceLocator.Instance.TryGetService<ILoggerService>(out var loggerService))
            //     loggerService.LogMessage($"Score Updated! {score}");

            ServiceLocator.Instance.GetService<ILoggerService>().LogMessage($"Score Updated! {score}");
        }
    }
}

