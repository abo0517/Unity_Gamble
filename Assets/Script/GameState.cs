using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public int hp = 100;
    public int money = 1000000;
    public int debt = -100000000;
    public int bankAccount = 0;
    public Text HpText;
    public Text MoneyText;
    public Text Message;
    public Canvas Canvas;

    void Start()
    {
        
    }

    void Update()
    {
        StateTextUpdate();
    }

    public void StateTextUpdate()
    {
        HpText.text = "체력 : " + hp + " / 100";
        MoneyText.text = string.Format("돈 : {0:N0} 원", money);
    }
    
    public void Message_Update(string msg, int time){
        Canvas.transform.Find("상단").gameObject.SetActive(true);
        Message.text = "" + msg;
        CancelInvoke("Message_cancle");
        Invoke("Message_cancle", time);
    }
    void Message_cancle(){
        Canvas.transform.Find("상단").gameObject.SetActive(false);
    }
}