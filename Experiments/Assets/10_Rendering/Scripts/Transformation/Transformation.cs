using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _10_Rendering
{
	public abstract class Transformation : MonoBehaviour {

		public abstract Vector3 Apply(Vector3 point);
	}	
}