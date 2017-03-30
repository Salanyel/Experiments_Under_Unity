using System;
using UnityEngine;

namespace _01_Clock
{
    public class ClockAnimator : MonoBehaviour
    {
        public Transform hours, minutes, seconds;
        public bool isAnalog;

        private const float
            _hoursToDegrees = 360f / 12f,
            _minutesToDegrees = 360f / 60f,
            _secondsToDegrees = 360f / 60f;

        private void Update()
        {
            if (isAnalog)
            {
                TimeSpan v_timeSpan = DateTime.Now.TimeOfDay;

                modifyHand((float) v_timeSpan.TotalHours, hours, _hoursToDegrees);
                modifyHand((float) v_timeSpan.TotalMinutes, minutes, _minutesToDegrees);
                modifyHand((float) v_timeSpan.TotalSeconds, seconds, _secondsToDegrees);
            }
            else
            {
                DateTime v_time = DateTime.Now;

                modifyHand(v_time.Hour, hours, _hoursToDegrees);
                modifyHand(v_time.Minute, minutes, _minutesToDegrees);
                modifyHand(v_time.Second, seconds, _secondsToDegrees);
            }            
        }

        /// <summary>
        /// Modify the local rotation of the transform while converting value into degrees
        /// </summary>
        /// /// <param name="p_time">Value of the time to convert into degrees</param>
        /// <param name="p_hand">Object to rotate</param>
        /// <param name="p_convertToDegrees">Value to convert the float</param>
        private void modifyHand(float p_time, Transform p_hand, float p_convertToDegrees)
        {
            p_hand.localRotation = Quaternion.Euler(0f, 0f, p_time * -p_convertToDegrees);
        }
    }    
}