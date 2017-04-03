using UnityEngine;

namespace _03_FramesPerSecond
{
    [RequireComponent(typeof(Rigidbody))]
    public class Nucleon : MonoBehaviour
    {

        public float attractionForce;

        Rigidbody _rigidBody;

        // Use this for initialization
        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidBody.AddForce(transform.localPosition * -attractionForce);
        }
    }
}