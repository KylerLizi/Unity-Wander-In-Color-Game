using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {
    int hour;
    int minute;
    int second;
    int millisecond;
    static public Text textTime;
    // 花费时间
    static public float time_by = 0.0f;
    void Start () {
        textTime = GetComponent<Text>();
	}
	
	void Update () {
        if (GameManager.getInstance().GAMESTATE == GameManager.getInstance().PLAYING)
            StartTimer();
    }

    void StartTimer()
    {
        time_by += Time.deltaTime;
        //hour = (int)time_by / 3600;
        minute = ((int)time_by - hour * 3600) / 60;
        second = (int)time_by - hour * 3600 - minute * 60;
        millisecond = (int)((time_by - (int)time_by) * 1000);
        textTime.text = string.Format("{0:D2}:{1:D2}.{2:D3}", minute, second, millisecond);
    }

    public void reTimer()
    {
        time_by = 0;
        minute = second = millisecond = 0;
        textTime = GetComponent<Text>();
        textTime.text = string.Format("{0:D2}:{1:D2}.{2:D3}", minute, second, millisecond);
    }
}
