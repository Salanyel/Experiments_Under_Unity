using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  _10_Rendering
{
	public class TransformationGrid : MonoBehaviour {
		public Transform _prefab;
		public int _gridResolution = 10;

		Transform[] _grid;
		List<Transformation> _transformations;

		void Awake()
		{
			_grid = new Transform[_gridResolution * _gridResolution * _gridResolution];
			for (int i = 0, z = 0; z < _gridResolution; z++) {
				for (int y = 0; y < _gridResolution; y++) {
					for (int x = 0; x < _gridResolution; x++, i++) {
						_grid[i] = CreateGridPoint(x, y, z);
					}
				}
			}

			_transformations = new List<Transformation>();
		}

		Transform CreateGridPoint(int x, int y, int z)
		{
			Transform point = Instantiate<Transform>(_prefab);
			point.localPosition = GetCoordinates(x, y, z);
			point.GetComponent<MeshRenderer>().material.color = new Color(
				(float) x / _gridResolution,
				(float) y / _gridResolution,
				(float) z / _gridResolution
			);

			return point;
		}

		Vector3 GetCoordinates(int x, int y, int z)
		{
			return new Vector3(
				x - (_gridResolution - 1) * 0.5f,
				y - (_gridResolution - 1) * 0.5f,
				z - (_gridResolution - 1) * 0.5f
			);
		}

		void Update()
		{
			GetComponents<Transformation>(_transformations);
			for (int i = 0, z = 0; z < _gridResolution; z++) 
			{
				for (int y = 0; y < _gridResolution; y++) 
				{
					for (int x = 0; x < _gridResolution; x++, i++) 
					{
						_grid[i].localPosition = TransformPoint(x, y, z);
					}
				}
			}
		}

		Vector3 TransformPoint(int x, int y, int z)
		{
			Vector3 coordinates = GetCoordinates(x, y, z);
			for (int i = 0; i < _transformations.Count; ++i)
			{
				coordinates = _transformations[i].Apply(coordinates);	
			}
			return coordinates;
		}

	}
}