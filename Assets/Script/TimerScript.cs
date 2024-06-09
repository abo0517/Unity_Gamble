using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    GameObject obj;
    public Text Time_Text;
    public Text Interest_Text;
    public int day = 0;
    public int hour = 0;
    public int min = 0;
    public int left_day = 7;

    //외부 스크립트에서 수정 못하게할때
    //[SerializeField]

    void Start()
    {
        obj = GameObject.Find("GameManager");
        // 게임의 하루 = 현실의 6분,     게임의 1시간 = 현실의 15초,        min += 4
        InvokeRepeating("RunTime", 1.25f, 1.25f);
    }

    void RunTime()
    {
        min += 5;
        if (min >= 60)
        {
            min -= 60;
            hour++;
            // 1시간마다 체력 -1
            obj.GetComponent<GameState>().hp--;
            obj.GetComponent<Bank>().RandomPrice();
            if (obj.GetComponent<GameState>().hp <= 0){
                Game_Over();
            }
        }
        if (hour >= 24){
            hour -= 24;
            day++;
            left_day--;
            
        }
        // 이자 발생
        if (left_day <= 0){
            left_day = 7;
            obj.GetComponent<Bank>().Interest();
        }

        Time_Text.text = string.Format("{0}일 {1:D2}:{2:D2}", day, hour, min);
        Interest_Text.text = string.Format("이자까지 남은 일 : {0}일", left_day);
    }
    
    void Game_Over(){
        Debug.Log("Game Over");
    }
}
