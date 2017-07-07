using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _12_Combining_Textures {
	public class SliderScript : MonoBehaviour {

		public GameObject _target;

		Slider _slider;

		void Awake() {
			_slider = GetComponent<Slider> ();
		}

		public void OnChange() {
			float value = _slider.value;

			if (_target.name == "Plane") {
				_target.GetComponent<Renderer> ().material.SetFloat ("_Repetition", value);
			} else {
				_target.GetComponent<Renderer> ().material.mainTextureScale = new Vector2 (value, value);
			}
		}
	}
}