using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    GameObject obj;
    public Slider Fever_Bar;
    int Fever = 0;
    int idx = 1;
    bool Fever_state = false;

    void Start()
    {
        obj = GameObject.Find("GameManager");
    }

    // 일반 상태 광질 시 10원, 피버 상태 시 50원(피버 타임은 50번 클릭 시 발생, 10초간)
    public void Mining(){
        obj.GetComponent<GameState>().money += 10 * idx;
        
        if(!Fever_state){
            Fever++;
        }
        if(Fever >= 50){
            Fever_Start();
            obj.GetComponent<GameState>().Message_Update("피버 타임!", 10);
        }
        Fever_Update();
    }
    void Fever_Update(){
        Fever_Bar.value = Fever;
    }
    void Fever_Start(){
        Fever_state = true;
        Fever = 0;
        idx = 5;
        Invoke("Fever_End", 10.0f);
    }
    void Fever_End(){
        Fever_state = false;
        idx = 1;
    }
}
