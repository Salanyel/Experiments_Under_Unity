using UnityEngine;

namespace _04_ObjectsPool
{

    [RequireComponent(typeof(Rigidbody))]
    public class Stuff : PooledObject
    {
        public Rigidbody _body { get; private set; }

        MeshRenderer[] _meshRenderers;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.killZone))
            {
                ReturnToPool();
            }
        }

        public void SetMaterial(Material p_mat)
        {
            for (int i = 0; i < _meshRenderers.Length; ++i)
            {
                _meshRenderers[i].material = p_mat;
            }
        }
    }
}