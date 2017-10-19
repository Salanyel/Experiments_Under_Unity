using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _10_Rendering
{
	public class PositionTransformation : Transformation {
		
		public Vector3 _position;

		public override Vector3 Apply(Vector3 point)
		{
			return point + _position;
		}
	}
}