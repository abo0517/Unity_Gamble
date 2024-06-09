using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Betting : MonoBehaviour
{
    public GameObject GameManager;
    public Canvas GameCanvas;
    public Canvas Betting_Canvas;
    public InputField Betting_money;
    public Text Betting_Text;
    public string game_name = "";
    public void setting_betting(){
        Betting_Canvas.gameObject.SetActive(true);
    }
    public void Betting_seed(){
        if(Betting_money.text == ""){
            Betting_Text.text = "정확한 금액을 입력하시오.";
        }
        else if(GameManager.GetComponent<GameState>().money < int.Parse(Betting_money.text)){
            Betting_Text.text = "소지금이 부족합니다.";
        }
        else{
            Betting_Text.text = string.Format("{0}원 만큼 배팅이 되었습니다.", Betting_money.text);
            GameManager.GetComponent<GameState>().money -= int.Parse(Betting_money.text);
            GameManager.GetComponent<GameState>().Message_Update(Betting_Text.text, 2);
            Betting_Canvas.gameObject.SetActive(false);
            start_game(game_name);
        }
    }
    void start_game(string game_name){
        switch(game_name)
        {
            case "BlackJack":
                GameCanvas.GetComponent<BlackJack>().start_game();
                break;
            
            case "Racing":

                break;
            
            case "Ladder":
                GameCanvas.GetComponent<Ladder>().start_game();
                break;
            
            case "Roullete":

                break;
        }
        
    }
}
