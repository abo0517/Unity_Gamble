using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    public GameObject GameManager;
    public Text Result_1_text, Result_2_text;
    public Image Line_width, Ball;
    public GameObject Line_Field;
    public Button A_Btn, B_Btn;
    public InputField Betting_money;
    public Text Betting_Text;
    public Canvas Betting_Canvas;
    public void start_game(){
        DestroyClone("Clone");
        create_line();
        A_Btn.GetComponent<Button>().interactable = true;
        B_Btn.GetComponent<Button>().interactable = true;
        Result_1_text.text = string.Format("?");
        Result_2_text.text = string.Format("?");
        
    }
    void create_line(){
        int idx = Random.Range(0, 6);
        for (int i = 0; i < idx; i++){
            int height = Random.Range(-300, 300);
            transform.localPosition = new Vector3(0, height, 0);
            Image new_line = Instantiate(Line_width, transform.localPosition, Quaternion.identity);
            new_line.transform.parent = Line_Field.transform;
            new_line.transform.localPosition = transform.localPosition;
            new_line.tag = "Clone";
        }
        
        
    }
    void create_result(){
        int idx = Random.Range(0, 2);
        switch(idx)
        {
            case 0:
                Result_1_text.text = "성공";
                Result_2_text.text = "실패";
                break;
            case 1:
                Result_1_text.text = "실패";
                Result_2_text.text = "성공";
                break;
        }
    }
    public void click_btn(string selection){
        int x = 0;
        switch(selection)
        {
            case "A":
                x = -100;
                break;

            case "B":
                x = 100;
                break;
        }
        Image new_ball = Instantiate(Ball);
        new_ball.transform.parent = Line_Field.transform;
        new_ball.transform.localPosition = new Vector3(x, 350, 0);
        A_Btn.GetComponent<Button>().interactable = false;
        B_Btn.GetComponent<Button>().interactable = false;
        create_result();
    }

    public void finish_game(string rest){
        A_Btn.GetComponent<Button>().interactable = true;
        B_Btn.GetComponent<Button>().interactable = true;
        string result_value = "";
        if(rest == "left"){
            result_value = Result_1_text.text;
        }
        else if(rest == "right"){
            result_value = Result_2_text.text;
        }
        if(result_value == "성공"){
            GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) * 2;
            string result = string.Format("승리하여 배팅금의 2배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 2);
            GameManager.GetComponent<GameState>().Message_Update(result, 5);
            Invoke("restart_game", 3.0f);
        }
        else if(result_value == "실패"){
            GameManager.GetComponent<GameState>().money += int.Parse(Betting_money.text) / 2;
            string result = string.Format("패배하여 배팅금의 0.5배인 {0}원을 돌려드립니다.", int.Parse(Betting_money.text) * 0.5);
            GameManager.GetComponent<GameState>().Message_Update(result, 5);
            Invoke("restart_game", 3.0f);
        }
    }
    public void restart_game(){
        Betting_Canvas.gameObject.SetActive(true);
        start_game();
        DestroyClone("Clone");
    }

    public void DestroyClone(string str){
     GameObject[] clone = GameObject.FindGameObjectsWithTag(str);

     for (int i = 0; i < clone.Length; i++)
     {
          Destroy(clone[i]);
     }
    }
}
