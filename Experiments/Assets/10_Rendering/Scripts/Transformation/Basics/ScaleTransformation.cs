using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _10_Rendering
{
	public class ScaleTransformation : Transformation {
		public Vector3 _scale;

		public override Vector3 Apply(Vector3 point)
		{
			point.x *= _scale.x;
			point.y *= _scale.y;
			point.z *= _scale.z;
			return point;
		}
	}	
}