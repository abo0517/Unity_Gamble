using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public int hp = 100;
    public int money = 0;

    public Text HpText;
    public Text MoneyText;

    void Start()
    {
        
    }

    void Update()
    {
        StateTextUpdate();
    }

    //광질 함수 -> 버튼에 연결 해놨음
    public void Mining()
    {
        money++;
        Debug.Log(money);
    }

    void StateTextUpdate()
    {
        HpText.text = "HP : " + hp;
        MoneyText.text = "Money : " + money;
    }
}