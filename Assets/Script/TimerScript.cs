using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text TimeText;
    int day = 0;
    int hour = 0;
    int min = 0;

    //외부 스크립트에서 수정 못하게할때
    //[SerializeField]

    void Start()
    {
        // 게임의 하루 = 현실의 6분,     게임의 1시간 = 현실의 15초,        min += 4
        InvokeRepeating("RunTime", 1, 1);
    }

    void RunTime()
    {
        min += 4;
        if (min >= 60)
        {
            min = 0;
            hour++;
        }
        if (hour >= 24){
            hour = 0;
            day++;
        }

        TimeText.text = string.Format("{0}일 {1:D2}:{2:D2}", day, hour, min);
    }
}