using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{
    public GameObject GameManager;
    public Canvas BlackJack_Canvas;
    public InputField Betting_money;
    public Text Betting_Text;
    public Canvas Betting_Canvas;
    public Image Dealer_card, Player_card;
    public GameObject Dealer_field, Player_field;
    public Image Dealer_1, Dealer_2, Player_1, Player_2;
    public Text Dealer_score, Player_score;
    public Text Result_field;
    public Sprite[] sprites;
    List<int> Dealer_list = new List<int>();
    List<int> Player_list = new List<int>();

    public void setting(){
        Betting_Canvas.gameObject.SetActive(true);
        if(GameManager.GetComponent<GameState>().money < int.Parse(Betting_money.text)){
            Betting_Text.text = "소지금이 부족합니다.";
        }
        else{
            Betting_Text.text = string.Format("{0}원 만큼 배팅이 되었습니다.", Betting_money.text);
            GameManager.GetComponent<GameState>().money -= int.Parse(Betting_money.text);
            GameManager.GetComponent<GameState>().Message_Update(Betting_Text.text, 2);
            Betting_Canvas.gameObject.SetActive(false);
            start_game();
        }
    }

    void start_game(){
        BlackJack_Canvas.transform.Find("Game_Btn").gameObject.SetActive(true);
        Defualt_Card_Set();
    }

    void Defualt_Card_Set(){
        int idx = Random.Range(0, 52);
        Dealer_1.sprite = sprites[idx];
        Dealer_list.Add(idx % 13 + 1);

        idx = Random.Range(0, 52);
        Dealer_2.sprite = sprites[idx];
        Dealer_list.Add(idx % 13 + 1);

        idx = Random.Range(0, 52);
        Player_1.sprite = sprites[idx];
        Player_list.Add(idx % 13 + 1);

        idx = Random.Range(0, 52);
        Player_2.sprite = sprites[idx];
        Player_list.Add(idx % 13 + 1);

        int Dealer_sum = sum_list(Dealer_list);
        Dealer_score.text = string.Format("딜러 합 : {0:D2}", Dealer_sum);
        int Player_sum = sum_list(Player_list);
        Player_score.text = string.Format("플레이어 합 : {0:D2}", Player_sum);
    }
    void Dealer_Card_plus(){
        Image new_card = Instantiate(Dealer_card, Dealer_field.transform);
        int idx = Random.Range(0, 52);
        new_card.sprite = sprites[idx];
        new_card.tag = "Clone";
        Dealer_list.Add(idx % 13 + 1);
    }
    void Player_card_plus(){
        Image new_card = Instantiate(Player_card, Player_field.transform);
        int idx = Random.Range(0, 52);
        new_card.sprite = sprites[idx];
        Player_list.Add(idx % 13 + 1);
    }
    int sum_list(List<int> list){
        int sum = 0;
        foreach (int i in list){
            if(i >= 10){
                sum += 10;
            }
            else{
                sum += i;
            }
        }
        return sum;
    }
    public void Hit_Btn(){
        Player_card_plus();
        int Player_sum = sum_list(Player_list);
        Player_score.text = string.Format("플레이어 합 : {0:D2}", Player_sum);
        if(Player_sum > 21){
            Dealer_win();
            Result_field.text = string.Format("플레이어 버스트!");
        }
    }
    public void Stand_Btn(){
        int Dealer_sum = sum_list(Dealer_list);
        Dealer_score.text = string.Format("딜러 합 : {0:D2}", Dealer_sum);
        int Player_sum = sum_list(Player_list);
        Player_score.text = string.Format("플레이어 합 : {0:D2}", Player_sum);
        // 딜러 카드 합 최소 17이상
        if(Dealer_sum < 17){
            Dealer_Card_plus();
            Stand_Btn();
            return;
        }
        // 딜러 버스트
        if(Dealer_sum > 21){
            Player_win();
            Result_field.text = string.Format("딜러 버스트!");
        }
        else if(Player_sum < 17){
            Dealer_win();
            Result_field.text = string.Format("패배!");
        }
        else if(Player_sum > Dealer_sum){
            Player_win();
            Result_field.text = string.Format("승리!");
        }
        else if(Player_sum < Dealer_sum){
            Dealer_win();
            Result_field.text = string.Format("패배!");
        }
        else{
            Draw();
            Result_field.text = string.Format("무승부");
        }
    }
    void Player_win(){
        GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) * 2;
        string result = string.Format("승리하여 배팅금의 2배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 2);
        GameManager.GetComponent<GameState>().Message_Update(result, 5);
        BlackJack_Canvas.transform.Find("Game_Btn").gameObject.SetActive(false);
        Invoke("restart_game", 3.0f);
    }
    void Dealer_win(){
        GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) / 2;
        string result = string.Format("패배하여 배팅금의 0.5배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 0.5);
        GameManager.GetComponent<GameState>().Message_Update(result, 5);
        BlackJack_Canvas.transform.Find("Game_Btn").gameObject.SetActive(false);
        Invoke("restart_game", 3.0f);
    }
    void Draw(){
        GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text);
        string result = string.Format("무승부하여 배팅금인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text));
        GameManager.GetComponent<GameState>().Message_Update(result, 5);
        BlackJack_Canvas.transform.Find("Game_Btn").gameObject.SetActive(false);
        Invoke("restart_game", 3.0f);
    }
    public void restart_game(){
        Betting_Canvas.gameObject.SetActive(true);
        Result_field.text = string.Format("");
        Dealer_list = new List<int>();
        Player_list = new List<int>();
        DestroyClone("Clone");
    }
    public void DestroyClone(string str)
{
     GameObject[] clone = GameObject.FindGameObjectsWithTag(str);

     for (int i = 0; i < clone.Length; i++)
     {
          Destroy(clone[i]);
     }
}
}

