using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _07_RoundedCube
{
	public class ObjectDestructor : MonoBehaviour {

		public void OnCollisionEnter(Collision other)
		{
			Destroy(other.gameObject);
		}
	}	
}