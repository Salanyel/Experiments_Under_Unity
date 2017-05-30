using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace _10_Rendering {
	public class UILibrary : MonoBehaviour {

		Slider _slider;
		ShowOff _show;

		void Start()
		{
			_slider = GetComponent<Slider>();
			_show = FindObjectOfType<ShowOff>();

			_slider.value = _show._delay / _show._maxDelay;
		}

		public void OnValueChange()
		{
			_show._delay = _show._maxDelay * _slider.value;
		}

	}
}