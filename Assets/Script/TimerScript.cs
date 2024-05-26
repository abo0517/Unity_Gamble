using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text TimeText;
    float sec;
    int min;

    //외부 스크립트에서 수정 못하게할때
    //[SerializeField]

    void Start()
    {
        //시간 조절
        Time.timeScale = 0.05f;
    }

    void Update()
    {
        RunTime();
    }

    void RunTime()
    {
        sec += Time.time;
        TimeText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);

        if ((int)sec > 59)
        {
            sec = 0;
            min++;
        }
    }
}