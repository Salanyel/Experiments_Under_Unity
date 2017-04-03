using UnityEngine;

namespace _03_FramesPerSecond
{
    public class FPSCounter : MonoBehaviour
    {
        public int averageFPS { get; private set; }
        public int highestFPS { get; private set; }
        public int lowestFPS { get; private set; }

        public int frameRange = 60;

        int[] _fpsBuffer;
        int _fpsBufferIndex;

        private void Awake()
        {
            InitializeBuffer();
        }

        private void Update()
        {
            if (frameRange <= 0)
            {
                InitializeBuffer();
            }

            UpdateBuffer();
            CalculateFPS();
            
        }

        /// <summary>
        /// Initialize the FPS Buffer
        /// </summary>
        void InitializeBuffer()
        {
            if (frameRange <= 0)
            {
                frameRange = 1;
            }

            _fpsBuffer = new int[frameRange];
            _fpsBufferIndex = 0;
        }

        /// <summary>
        /// Update the FPS buffer
        /// </summary>
        void UpdateBuffer()
        {
            _fpsBuffer[_fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);

            if (_fpsBufferIndex >= frameRange)
            {
                _fpsBufferIndex = 0;
            }
        }

        /// <summary>
        /// Calculate the current FPS by summing and dividing all values stored for a while
        /// </summary>
        void CalculateFPS()
        {
            int v_sum = 0;
            int v_highest = 0;
            int v_lowest = int.MaxValue;

            for (int i = 0; i < frameRange; ++i)
            {
                int fps = _fpsBuffer[i];
                v_sum += fps;

                if (fps < v_lowest)
                {
                    v_lowest = fps;
                }

                if (fps > v_highest)
                {
                    v_highest = fps;
                }

            }
            averageFPS = v_sum / frameRange;
            highestFPS = v_highest;
            lowestFPS = v_lowest;
        }
    }
}