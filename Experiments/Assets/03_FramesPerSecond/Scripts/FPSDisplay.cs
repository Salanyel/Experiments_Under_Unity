using UnityEngine;
using UnityEngine.UI;

namespace _03_FramesPerSecond
{
    [RequireComponent(typeof(FPSCounter))]
    public class FPSDisplay : MonoBehaviour
    {

        //Array from 0 to 99 to avoid any dynamic creation while setting a new arary (avoid to create the string "84" each frame for example)
        static string[] stringsFromm00To99;

        public Text fpsLabel, highestFpsLabel, lowestFpsLabel;

        FPSCounter _fpsCounter;

        [System.Serializable]
        private struct FPSColor
        {
            public Color color;
            public int minimumFPS;
        }

        [SerializeField]
        private FPSColor[] _coloring;

        private void Awake()
        {
            _fpsCounter = GetComponent<FPSCounter>();
            stringsFromm00To99 = new string[100];

            stringsFromm00To99[0] = "00";
            stringsFromm00To99[1] = "01";
            stringsFromm00To99[2] = "02";
            stringsFromm00To99[3] = "03";
            stringsFromm00To99[4] = "04";
            stringsFromm00To99[5] = "05";
            stringsFromm00To99[6] = "06";
            stringsFromm00To99[7] = "07";
            stringsFromm00To99[8] = "08";
            stringsFromm00To99[9] = "09";

            for (int i = 10; i < stringsFromm00To99.Length; ++i)
            {
                stringsFromm00To99[i] = i.ToString();
            }
        }

        private void Update()
        {
            Display(fpsLabel, _fpsCounter.averageFPS);
            Display(highestFpsLabel, _fpsCounter.highestFPS);
            Display(lowestFpsLabel, _fpsCounter.lowestFPS);
        }

        /// <summary>
        /// Color a UI Text depending on the FPS number displayed
        /// </summary>
        /// <param name="p_label"></param>
        /// <param name="p_fps"></param>
        private void Display(Text p_label, int p_fps)
        {
            p_label.text = stringsFromm00To99[Mathf.Clamp(p_fps, 0, 99)];
            for (int i = 0; i < _coloring.Length; ++i)
            {
                if (p_fps >= _coloring[i].minimumFPS)
                {
                    p_label.color = _coloring[i].color;
                    break;
                }
            }
        }
    }
}