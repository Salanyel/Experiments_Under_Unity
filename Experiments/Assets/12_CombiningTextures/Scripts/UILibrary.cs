using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _12_Combining_Textures {
	
	public class UILibrary : MonoBehaviour {

		public GameObject _plane1;
		public GameObject _plane2;
		public GameObject _slider1;
		public GameObject _slider2;

		public void SwitchPlane() {
			_plane1.SetActive(!_plane1.activeSelf);
			_slider1.SetActive(!_slider1.activeSelf);
			_plane2.SetActive(!_plane2.activeSelf);
			_slider2.SetActive(!_slider2.activeSelf);
		}
	}
}