using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Racing : MonoBehaviour
{
    public GameObject Cat1;
    public GameObject Cat2;
    public GameObject Cat3;
    public GameObject Betting_Btn;
    public List<int> Rank = new List<int>();
    int select_cat;
    public Canvas Betting_Canvas;
    public InputField Betting_money;
    public GameObject GameManager;

    public void start_game(int cat_num)
    {
        select_cat = cat_num;
        move_cat();
    }
    void move_cat(){
        Betting_Btn.gameObject.SetActive(false);
        Cat1.GetComponent<Racing_1>().moveSpeed = 30f;
        Cat2.GetComponent<Racing_2>().moveSpeed = 30f;
        Cat3.GetComponent<Racing_3>().moveSpeed = 30f;
    }

    void Update()
    {
        RankList();
    }

    public void RankList()
    {
        if(Rank.Count == 3){
            if(Rank[0] == select_cat){
                GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) * 3;
                string result = string.Format("1등하여 배팅금의 3배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 3);
                GameManager.GetComponent<GameState>().Message_Update(result, 5);
                Invoke("restart_game", 3.0f);
            }
            else if(Rank[1] == select_cat){
                GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) * 3 / 2;
                string result = string.Format("2등하여 배팅금의 1.5배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 3 / 2);
                GameManager.GetComponent<GameState>().Message_Update(result, 5);
                Invoke("restart_game", 3.0f);
            }
            else if(Rank[2] == select_cat){
                GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) * 0;
                string result = string.Format("3등하여 배팅금의 0배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 0);
                GameManager.GetComponent<GameState>().Message_Update(result, 5);
                Invoke("restart_game", 3.0f);
            }
            Rank = new List<int>();
        }
    }
    public void restart_game(){
        Betting_Btn.gameObject.SetActive(true);
        Cat1.GetComponent<Racing_1>().moveSpeed = 0f;
        Cat2.GetComponent<Racing_2>().moveSpeed = 0f;
        Cat3.GetComponent<Racing_3>().moveSpeed = 0f;
        Cat1.transform.localPosition = new Vector3(-968, -538, 0);
        Cat2.transform.localPosition = new Vector3(-968, -540, 0);
        Cat3.transform.localPosition = new Vector3(-968, -542, 0);
        Betting_Canvas.gameObject.SetActive(true);
    }
}

