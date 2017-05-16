using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _07_RoundedCube
{
	public class RoundedCubeGenerator : MonoBehaviour {

		public GameObject roundedCube;
		public int maxXYZValue;
		public int minRoundessValue;
		public int maxRoundessValue;
		public float spawnWaitTime;
		public float minScale;
		public float maxScale;

		float _radiusSpawning;
		
		void Awake()
		{
			StartCoroutine(Generate());
		}

		IEnumerator Generate()
		{
			while(true)
			{
				//Create a new rounded cube
				GameObject newObject = Instantiate<GameObject>(roundedCube);
				RoundedCube rCube = newObject.GetComponent<RoundedCube>();

				//Set its transform
				float randomScale = Random.Range(minScale, maxScale);
				newObject.transform.position = transform.position;
				newObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

				//Set the value for the x, y, z and roundness
				rCube.xSize = Random.Range(2, maxXYZValue);
				rCube.ySize = Random.Range(2, maxXYZValue);
				rCube.zSize = Random.Range(2, maxXYZValue);
				rCube.roundness = Random.Range(minRoundessValue, maxRoundessValue);

				//Generate the mesh
				rCube.Generate();

				//Wait a random time before the next spawn
				yield return new WaitForSeconds(Random.Range(spawnWaitTime, spawnWaitTime * 2));
			}
		}
	}
	
}