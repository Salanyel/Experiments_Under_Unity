using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _02_ConstructingFractal
{
    public class UILibrary : MonoBehaviour
    {

        public GameObject rootFractal;

        private Fractal _fractal;
        private Mesh[] _meshes;
        private Material _material;
        private int _maxDepth;
        private float _childScale;
        private float _spawnProbabilty;
        private float _maxRotationSpeed;
        private float _maxTwist;

        private void Start()
        {
            _fractal = rootFractal.GetComponent<Fractal>();
            _meshes = _fractal.meshes;
            _material = _fractal.material;
            _maxDepth = _fractal.maxDepth;
            _childScale = _fractal.childScale;
            _spawnProbabilty = _fractal.spawnProbability;
            _maxRotationSpeed = _fractal.maxRotationSpeed;
            _maxTwist = _fractal.maxTwist;
        }

        /// <summary>
        /// Regenerate the fractal
        /// </summary>
        public void RegenerateFractal()
        {
            foreach (Transform children in rootFractal.transform)
            {
                Destroy(children.gameObject);
            }

            Destroy(rootFractal.GetComponent<MeshRenderer>());
            Destroy(rootFractal.GetComponent<MeshFilter>());
            Destroy(rootFractal.GetComponent<Fractal>());
                      
            Fractal newFractal = rootFractal.AddComponent<Fractal>();

            newFractal.meshes = _meshes;
            newFractal.material = _material;
            newFractal.maxDepth = _maxDepth;
            newFractal.childScale = _childScale;
            newFractal.spawnProbability = _spawnProbabilty;
            newFractal.maxRotationSpeed = _maxRotationSpeed;
            newFractal.maxTwist = _maxTwist;
        }
    }

}