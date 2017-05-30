using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _10_Rendering {
	public class ShowOff : MonoBehaviour {

		public float _maxDelay = 5;
		public float _delay = 5;
		public float _maxValueTransformation = 3;
		public float _maxValueRotation = 3;
		public float _maxValueScale = 3;

		PositionTransformation _positionT;
		ScaleTransformation _scaleT;
		RotationTransformation _rotationT;

		// Use this for initialization
		void Start () {
			_positionT = GetComponent<PositionTransformation>();
			_scaleT = GetComponent<ScaleTransformation>();
			_rotationT = GetComponent<RotationTransformation>();

			StartCoroutine(XCoroutine());
		}
		
		IEnumerator XCoroutine()
		{
			float time = Time.time;
			float delay = 0;
			while (Time.time < time + _delay)
			{
				Vector3 vectorTransformation = CreateVector(_maxValueTransformation * (delay / _delay), 0, 0);
				Vector3 vectorRotation = CreateVector(_maxValueRotation * (delay / _delay), 0, 0);
				Vector3 vectorScale = CreateVector(1 + (_maxValueScale * (delay / _delay)), 1, 1);

				_positionT._position = vectorTransformation;
				_rotationT._rotation = vectorRotation;
				_scaleT._scale = vectorScale;
				yield return new WaitForEndOfFrame();
				delay += Time.deltaTime;
			}

			delay = 0;
			time = Time.time;
			while (Time.time < time + _delay)
			{
				Vector3 vectorTransformation = CreateVector(_maxValueTransformation - (_maxValueTransformation * (delay / _delay)), 0, 0);
				Vector3 vectorRotation = CreateVector(_maxValueRotation - (_maxValueRotation * (delay / _delay)), 0, 0);
				Vector3 vectorScale = CreateVector(1 + (_maxValueScale - (_maxValueScale * (delay / _delay))), 1, 1);

				_positionT._position = vectorTransformation;
				_rotationT._rotation = vectorRotation;
				_scaleT._scale = vectorScale;
				yield return new WaitForEndOfFrame();
				delay += Time.deltaTime;
			}

			StartCoroutine(YCoroutine());
		}

		IEnumerator YCoroutine()
		{
			float time = Time.time;
			float delay = 0;
			while (Time.time < time + _delay)
			{
				Vector3 vectorTransformation = CreateVector(0, _maxValueTransformation * (delay / _delay), 0);
				Vector3 vectorRotation = CreateVector(0, _maxValueRotation * (delay / _delay), 0);
				Vector3 vectorScale = CreateVector(1, 1 + (_maxValueScale * (delay / _delay)), 1);

				_positionT._position = vectorTransformation;
				_rotationT._rotation = vectorRotation;
				_scaleT._scale = vectorScale;
				yield return new WaitForEndOfFrame();
				delay += Time.deltaTime;
			}
			
			time = Time.time;
			delay = 0;
			while (Time.time < time + _delay)
			{
				Vector3 vectorTransformation = CreateVector(0, _maxValueTransformation - (_maxValueTransformation * (delay / _delay)), 0);
				Vector3 vectorRotation = CreateVector(0, _maxValueRotation - (_maxValueRotation * (delay / _delay)), 0);
				Vector3 vectorScale = CreateVector(1, 1 + (_maxValueScale - (_maxValueScale * (delay / _delay))), 1);

				_positionT._position = vectorTransformation;
				_rotationT._rotation = vectorRotation;
				_scaleT._scale = vectorScale;
				yield return new WaitForEndOfFrame();
				delay += Time.deltaTime;
			}

			StartCoroutine(ZCoroutine());
		}

		IEnumerator ZCoroutine()
		{
			float time = Time.time;
			float delay = 0;
			while (Time.time < time + _delay)
			{
				Vector3 vectorTransformation = CreateVector(0, 0, _maxValueTransformation * (delay / _delay));
				Vector3 vectorRotation = CreateVector(0, 0, _maxValueRotation * (delay / _delay));
				Vector3 vectorScale = CreateVector(1, 1, 1 + (_maxValueScale * (delay / _delay)));

				_positionT._position = vectorTransformation;
				_rotationT._rotation = vectorRotation;
				_scaleT._scale = vectorScale;
				yield return new WaitForEndOfFrame();
				delay += Time.deltaTime;
			}
			
			time = Time.time;
			delay = 0;
			while (Time.time < time + _delay)
			{
				Vector3 vectorTransformation = CreateVector(0, 0, _maxValueTransformation - (_maxValueTransformation * (delay / _delay)));
				Vector3 vectorRotation = CreateVector(0, 0, _maxValueRotation - (_maxValueRotation * (delay / _delay)));
				Vector3 vectorScale = CreateVector(1, 1, 1 + (_maxValueScale - (_maxValueScale * (delay / _delay))));

				_positionT._position = vectorTransformation;
				_rotationT._rotation = vectorRotation;
				_scaleT._scale = vectorScale;
				yield return new WaitForEndOfFrame();
				delay += Time.deltaTime;
			}

			StartCoroutine(XCoroutine());
		}

		Vector3 CreateVector(float p_x, float p_y, float p_z)
		{
			return new Vector3(p_x, p_y, p_z);
		}
		
	}
}