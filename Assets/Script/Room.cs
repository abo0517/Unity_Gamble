using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    GameObject obj;
    void Start()
    {
        obj = GameObject.Find("GameManager");
    }

    // 잠자기 버튼 누르면 8시간 후로 이동 및 체력 20 회복
    public void sleep_button(){
        obj.GetComponent<TimerScript>().hour += 8;
        obj.GetComponent<GameState>().hp += 20;
        if(obj.GetComponent<GameState>().hp >= 100){
            obj.GetComponent<GameState>().hp = 100;
        }
        obj.GetComponent<GameState>().Message_Update("8시간동안 잠을 자서 체력 20 회복", 2);
    }

    // 음식 먹기 버튼 누르면 10만원 써서 체력 5 회복
    public void Food_button(){
        obj.GetComponent<GameState>().money -= 100000;
        obj.GetComponent<GameState>().hp += 5;
        if(obj.GetComponent<GameState>().hp >= 100){
            obj.GetComponent<GameState>().hp = 100;
        }
        obj.GetComponent<GameState>().Message_Update("10만원을 사용하여 체력 5 회복", 2);
    }
}
