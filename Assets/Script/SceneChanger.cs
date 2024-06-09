using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Text TimerText;

    public Canvas Canvas;
    public Canvas MainCanvas;
    public Canvas RoomCanvas;
    public Canvas CasinoCanvas;
    public Canvas BankCanvas;
    public Canvas MineCanvas;
    public Canvas StoryCanvas;

    public Canvas IOCanvas;
    public Canvas CoinCanvas;
    int idx = 1;

    //카지노 입장 상태 true = 입장 / false = 퇴장 -> Exit에 퇴장 묶었음 그냥
    bool casinoState = false;

    void Start()
    {
        MainCanvas.gameObject.SetActive(false);
        RoomCanvas.gameObject.SetActive(false);
        CasinoCanvas.gameObject.SetActive(false);
        BankCanvas.gameObject.SetActive(false);
        MineCanvas.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        StoryCanvas.gameObject.SetActive(true);
        IOCanvas.gameObject.SetActive(false);
        CoinCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        //카지노 입장시 시계 안보이게 함
        if (casinoState == true)
        {
            TimerText.gameObject.SetActive(false);
        }

        else {TimerText.gameObject.SetActive(true);}
    }

    //버튼 함수들
    public void RoomButton()
    {
        RoomCanvas.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
    }

    public void CasinoButton()
    {
        casinoState = true;
        CasinoCanvas.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
    }

    public void BankButton()
    {
        BankCanvas.gameObject.SetActive(true);
        IOCanvas.gameObject.SetActive(true);
        CoinCanvas.gameObject.SetActive(false);
        MainCanvas.gameObject.SetActive(false);
    }

    public void MineButton()
    {
        MineCanvas.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        MainCanvas.gameObject.SetActive(true);
        RoomCanvas.gameObject.SetActive(false);
        CasinoCanvas.gameObject.SetActive(false);
        BankCanvas.gameObject.SetActive(false);
        MineCanvas.gameObject.SetActive(false);

        casinoState = false;
    }

    public void Next_Btn(){
        if(idx == 1){
            StoryCanvas.transform.Find("image_1").gameObject.SetActive(false);
            StoryCanvas.transform.Find("image_2").gameObject.SetActive(true);
            idx++;
        }
        else if(idx == 2){
            StoryCanvas.transform.Find("image_2").gameObject.SetActive(false);
            StoryCanvas.transform.Find("image_3").gameObject.SetActive(true);
            idx++;
        }
        else if(idx == 3){
            StoryCanvas.transform.Find("image_3").gameObject.SetActive(false);
            RoomCanvas.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(true);
            StoryCanvas.gameObject.SetActive(false);
        }
    }

    public void CoinButton()
    {
        IOCanvas.gameObject.SetActive(false);
        CoinCanvas.gameObject.SetActive(true);
    }

    public void IOButton()
    {
        IOCanvas.gameObject.SetActive(true);
        CoinCanvas.gameObject.SetActive(false);
    }
}