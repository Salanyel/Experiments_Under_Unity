using System.Collections;
using UnityEngine;

namespace _03_FramesPerSecond
{
    public class NucleonSpawner : MonoBehaviour
    {
        public float timeBetweenSpawns;
        public float spawnDistance;
        public Nucleon[] nucleonPrefabs;

        float _timeSinceLastSpawn;

        private void Start()
        {
            StartCoroutine(InfiniteSpawn());
        }

        private void FixedUpdate()
        {
            _timeSinceLastSpawn += Time.deltaTime;

            if (_timeSinceLastSpawn >= timeBetweenSpawns)
            {
                _timeSinceLastSpawn -= timeBetweenSpawns;
                SpawnNucleon();
            }
        }

        /// <summary>
        /// Spawn a random nucleon from the array and instantiate it at a precise position
        /// </summary>
        void SpawnNucleon()
        {
            Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
            Nucleon spawn = Instantiate<Nucleon>(prefab);
            spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
        }

        IEnumerator InfiniteSpawn()
        {
            while(true)
            {
                yield return new WaitForSeconds(0.01f);
                SpawnNucleon();
            }
        }

    }
}