using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _01_Clock
{
    public class UILibrary : MonoBehaviour
    {
        ClockAnimator _clockAnimator;

        void Start()
        {
            _clockAnimator = FindObjectOfType<ClockAnimator>();

        }

        /// <summary>
        /// Switch the mode between analog and classic for the clock
        /// </summary>
        public void switchMode()
        {
            _clockAnimator.isAnalog = !_clockAnimator.isAnalog;
        }
    }
}