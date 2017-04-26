using System.Collections;
using UnityEngine;

namespace _06_ProceduralGrid
{
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class Grid : MonoBehaviour {
		public int xSize;
		public int ySize;
		public float animationSpeed;
		public GameObject sphere;

		private Mesh _mesh;
		private Vector3[] _vertices;

		private void Awake()
		{
			StartCoroutine(Generate());
		}

		private IEnumerator Generate()
		{
			WaitForSeconds wait = new WaitForSeconds(animationSpeed);

			GameObject parent = new GameObject();
			parent.AddComponent<Transform>();

			GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
			_mesh.name = "Procedural Grid";

			_vertices = new Vector3[(xSize + 1) * (ySize + 1)];
			Vector2[] uv = new Vector2[_vertices.Length];
			Vector4[] tangents = new Vector4[_vertices.Length];
			Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

			for (int i = 0, y = 0; y <= ySize; ++y)
			{
				for (int x = 0; x <= xSize; ++x, ++i)
				{
					//Creating the vertice
					_vertices[i] = new Vector3(x, y);

					//Calculating its UV
					uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
					tangents[i] = tangent;

					//Display the sphere to see the vertices
					GameObject tmpSphere = Instantiate(sphere) as GameObject;
					tmpSphere.transform.position = new Vector3(x, y);
					tmpSphere.transform.SetParent(parent.GetComponent<Transform>());

					yield return wait;
				}
			}

			GameObject lastSPhere = Instantiate(sphere) as GameObject;
			lastSPhere.transform.position = new Vector3(xSize, ySize);
			lastSPhere.transform.SetParent(parent.GetComponent<Transform>());

			_mesh.vertices = _vertices;
			_mesh.uv = uv;
			_mesh.tangents = tangents;
			int [] triangles = new int[xSize * ySize * 6];
			for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) 
			{
				for (int x = 0; x < xSize; x++, ti += 6, vi++) 
				{
					triangles[ti] = vi;
					triangles[ti + 1] = vi + xSize + 1;
					triangles[ti + 2] = vi + 1;
					_mesh.triangles = triangles;
					yield return wait;

					triangles[ti + 3] = triangles[ti + 2];
					triangles[ti + 4] = triangles[ti + 1];
					triangles[ti + 5] = vi + xSize + 2;
					_mesh.triangles = triangles;
					yield return wait;
				}
			}

			Destroy(parent);

			_mesh.RecalculateNormals();

		}

		private void OnDrawGizmos()
		{
			//Avoid error while in editor
			if (_vertices == null)
			{
				return;
			}

			Gizmos.color = Color.black;
			for (int i = 0;i < _vertices.Length; ++i)
			{
				Gizmos.DrawSphere(_vertices[i], 0.1f);
			}
		}

	}
}