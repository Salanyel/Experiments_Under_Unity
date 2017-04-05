using UnityEngine;

namespace _04_ObjectsPool
{

    [System.Serializable]
    public struct FloatRange
    {
        public float min, max;

        public float RandomInRange
        {
            get
            {
                return Random.Range(min, max);
            }
        }
    }

    public class StuffSpawner : MonoBehaviour
    {
        public Stuff[] stuffPrefabs;

        public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
        public float velocity;
        public Material stuffMaterial;

        float _timeSinceLastSpawn = 0f;
        float _currentSpawnDelay;

        private void FixedUpdate()
        {
            _timeSinceLastSpawn += Time.deltaTime;
            if (_timeSinceLastSpawn >= _currentSpawnDelay)
            {
                _timeSinceLastSpawn -= _currentSpawnDelay;
                _currentSpawnDelay = timeBetweenSpawns.RandomInRange;
                SpawnStuff();
            }
        }

        /// <summary>
        /// Spawn a random element from the stuffs list
        /// </summary>
        void SpawnStuff()
        {
            Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
            Stuff spawn = prefab.GetPooledInstance<Stuff>();

            spawn.transform.localPosition = transform.position;
            spawn.transform.localScale = Vector3.one * scale.RandomInRange;
            spawn.transform.localRotation = Random.rotation;

            spawn._body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
            spawn._body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;
            spawn.SetMaterial(stuffMaterial);
        }
    }
}