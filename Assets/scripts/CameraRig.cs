using UnityEngine;

namespace PlatformerCookbook.Scripts
{
    public class CameraRig : MonoBehaviour
    {
        public Transform ObjectToFollow;
        public float Speed1;

        private Transform _transform;
        private bool _valid;

        private void FixedUpdate()
        {
            if (!_valid)
            {
                return;
            }
            _transform.position =Vector3.Lerp(_transform.position, ObjectToFollow.position, Time.fixedDeltaTime * Speed1);
                
        }

        private void Awake()
        {
            _valid = ObjectToFollow;
            if (!_valid)
            {
                Debug.LogError("There is no Object To Follow in CameraRig. Please set it.");
                return;
            }

            _transform = transform; 
            _transform.position = ObjectToFollow.position;
        }
    }
}