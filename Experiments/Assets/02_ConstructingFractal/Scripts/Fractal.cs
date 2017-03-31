using System.Collections;
using UnityEngine;

namespace _02_ConstructingFractal
{
    public class Fractal : MonoBehaviour
    {
        public Mesh[] meshes;
        public Material material;
        public int maxDepth;
        public float childScale;                
        public float spawnProbability;
        public float maxRotationSpeed;
        public float maxTwist;

        private int _depth;
        private bool isRootCube = true;
        private float _rotationSpeed;

        private static Vector3[] _childDirections =
        {
            Vector3.up,
            Vector3.right,
            Vector3.left,
            Vector3.forward,
            Vector3.back,
            Vector3.down
        };

        private static Quaternion[] _childOrientations =
        {
            Quaternion.identity,
            Quaternion.Euler(0f, 0f, -90f),
            Quaternion.Euler(0f, 0f, 90f),
            Quaternion.Euler(90f, 0f, 0f),
            Quaternion.Euler(-90f, 0f, 0f),
            Quaternion.Euler(0f, -90f, 0)
        };

        private Material[,] _materials;

        private void Start()
        {
            Generate();
        }

        private void Update()
        {
            transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);   
        }

        /// <summary>
        /// Function called to generate the fractal
        /// </summary>
        public void Generate()
        {
            if (_materials == null)
            {
                InitializeMaterials();
            }

            gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
            gameObject.AddComponent<MeshRenderer>().material = _materials[_depth, Random.Range(0, 2)];

            //Rotate the gameObject
            _rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
            transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);

            GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.yellow, (float)_depth / maxDepth);

            if (_depth < maxDepth)
            {
                StartCoroutine(createChildren());
            }
        }

        /// <summary>
        /// Initialize the materials list by lerping the color (to do dynamic batching)
        /// </summary>
        private void InitializeMaterials()
        {
            _materials = new Material[maxDepth + 1, 2];

            for (int i = 0; i <= maxDepth; ++i)
            {
                float t = i / (maxDepth - 1f);
                t *= t;
                _materials[i, 0] = new Material(material);
                _materials[i, 0].color = Color.Lerp(Color.white, Color.yellow, t);
                _materials[i, 1] = new Material(material);
                _materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
            }

            _materials[maxDepth, 0].color = Color.magenta;
            _materials[maxDepth, 1].color = Color.red;
        }

        /// <summary>
        /// Initialize the fractal with its parent values
        /// </summary>
        /// <param name="p_parent">Parent fractal</param>
        /// <param name="p_direction">Direction to initialize the current fractal</param>
        private void Initialize(Fractal p_parent, int p_childIndex)
        {
            //Disabling the root cube vector
            isRootCube = false;

            //Configuration of the fractal behavior
            meshes = p_parent.meshes;
            material = p_parent.material;
            maxDepth = p_parent.maxDepth;
            _depth = p_parent._depth + 1;
            childScale = p_parent.childScale;
            spawnProbability = p_parent.spawnProbability;
            maxRotationSpeed = p_parent.maxRotationSpeed;
            maxTwist = p_parent.maxTwist;

            //Configuration of the fractal transform            
            transform.SetParent(p_parent.transform);
            transform.localScale = Vector3.one * childScale; 
            transform.localPosition = _childDirections[p_childIndex] * (0.5f + 0.5f * childScale);
            transform.localRotation = _childOrientations[p_childIndex];
        }

        /// <summary>
        /// Create the fractal after time
        /// </summary>
        /// <returns></returns>
        private IEnumerator createChildren()
        {
            for (int i = 0; i < _childDirections.Length - 1; ++i)
            {
                if (Random.value < spawnProbability)
                {
                    yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                    new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
                }
            }       
            
            if (isRootCube)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, _childDirections.Length - 1);
            }     
        }
    }

}