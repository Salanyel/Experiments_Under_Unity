using UnityEngine;
using System.Collections;

namespace _07_RoundedCube
{

	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class Cube : MonoBehaviour {

		public int xSize, ySize, zSize;
		public float waitTime;

		private Mesh _mesh;
		private Vector3[] _vertices;

		private void Awake () {
			StartCoroutine(Generate());
		}

		private IEnumerator Generate () {
			GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
			_mesh.name = "Procedural Cube";
			WaitForSeconds wait = new WaitForSeconds(waitTime);

			int cornerVertices = 8;
			int edgeVertices = (xSize + ySize + zSize - 3) * 4;
			int faceVertices = (
				(xSize - 1) * (ySize - 1) +
				(xSize - 1) * (ySize - 1) +
				(xSize - 1) * (ySize - 1)) * 2;
			_vertices = new Vector3[cornerVertices + edgeVertices + faceVertices];

			int v = 0;
			for (int x = 0; x <= xSize; x++)
			{
				_vertices[v++] = new Vector3(x, 0, 0);
				yield return wait;
			}
			for (int z = 1; z <= zSize; z++) {
				_vertices[v++] = new Vector3(xSize, 0, z);
				yield return wait;
			}
			for (int x = xSize - 1; x >= 0; x--) {
				_vertices[v++] = new Vector3(x, 0, zSize);
				yield return wait;
			}
			for (int z = zSize - 1; z > 0; z--) {
				_vertices[v++] = new Vector3(0, 0, z);
				yield return wait;
			}
		}

		private void OnDrawGizmos () {
			if (_vertices == null) {
				return;
			}
			Gizmos.color = Color.black;
			for (int i = 0; i < _vertices.Length; i++) {
				Gizmos.DrawSphere(_vertices[i], 0.1f);
			}
		}
	}
}