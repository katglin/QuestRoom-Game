using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public const float MaxTime = 600;
    public float TimeGone;  // = MaxTime;
    public static bool timeEnd;  // = false;
    float startTime;  // = Time.time;
                      // Use this for initialization
    void Start () {

        startTime = Time.time;
        TimeGone = MaxTime;
        timeEnd = false;
    }

    // Update is called once per frame
    void Update () {

        TimerStart();
    }

    void TimerStart()
    {
        if (!timeEnd)
        {
            TimeGone = Time.time - startTime;

            if (TimeGone >= MaxTime)
            {
                timeEnd = true;
            }
        }
    }

    void OnGUI()
    {
        GUI.color = Color.yellow;
        if (!timeEnd)
        {
            float time = MaxTime - TimeGone;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - 60 * minutes);
            GUILayout.Label("TimeLeft = " + minutes + ":" + seconds);
        }
    }

}


