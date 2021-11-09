using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LapTimeManagement : MonoBehaviour
    {
        public static int MinuteCount;
        public static int SecondCount;
        public static float MilliCount;
        public static string MilliDisplay;

        public GameObject MinTime;
        public GameObject SecTime;
        public GameObject MilliTime;

        // Update is called once per frame
        void Update()
        {
            // Update milliseconds
            MilliCount += Time.deltaTime * 10;
            MilliDisplay = MilliCount.ToString("F0");
            MilliTime.GetComponent<Text>().text = "" + MilliDisplay;

            // Check for 10ms to increment Seconds.
            if(MilliCount >= 10)
            {
                MilliCount = 0;
                SecondCount += 1;
            }

            // single digits else 10 for double digits
            if(SecondCount <= 9)
            {
                SecTime.GetComponent<Text>().text = "0" + SecondCount + ".";
            } else
            {
                SecTime.GetComponent<Text>().text = "" + SecondCount + ".";
            }

            // Update minute count every 60s
            if(SecondCount >= 60)
            {
                SecondCount = 0;
                MinuteCount += 1;
            }

            // single digits else 10 for double digits
            if (MinuteCount <= 9)
            {
                MinTime.GetComponent<Text>().text = "0" + MinuteCount + "."; 
            }
            else
            {
                MinTime.GetComponent<Text>().text = "" + MinuteCount + ".";
            }
        }
    }
}