using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    GameObject obj;
    public InputField MoneyInput_Field;
    public InputField CoinCount_Field;
    public Text Debt_text;
    public Text Account_text;
    public Text Error_text;
    public Text Coin1_price;
    public Text Coin2_price;

    public Text CoinCount1;
    public Text CoinCount2;
    public Text CoinPosition1;
    public Text CoinPosition2;

    int coin1 = 10000000;
    int coin2 = 100000;
    int coinPosition1 = 0;
    int coinPosition2 = 0;
    int Countcoin1 = 0;
    int Countcoin2 = 0;

    void Start()
    {
        obj = GameObject.Find("GameManager");
        Error_text.gameObject.SetActive(false);
    }

    void Update()
    {
        Coin1TextUpdate();
        Coin2TextUpdate();
    }

    public void Coin1TextUpdate()
    {
        if(Countcoin1 != 0)
        {
            CoinCount1.text = "염소코인 : " + this.Countcoin1;
            CoinPosition1.text = string.Format("KRW : {0:N0}", this.coinPosition1);
        }

        else
        {
            CoinCount1.text = "염소코인 : " + this.Countcoin1;
            coinPosition1 = 0;
            CoinPosition1.text = string.Format("KRW : {0:N0}", this.coinPosition1);
        }
    }
    public void Coin2TextUpdate()
    {
        if (Countcoin2 != 0)
        {
            CoinCount2.text = "샤카밤바코인 : " + this.Countcoin2;
            CoinPosition2.text = string.Format("KRW : {0:N0}", this.coinPosition2);
        }

        else
        {
            CoinCount2.text = "샤카밤바코인 : " + this.Countcoin2;
            coinPosition2 = 0;
            CoinPosition2.text = string.Format("KRW : {0:N0}", this.coinPosition2);
        }
    }
    public void Interest()
    {
        int bankAccountBalance = obj.GetComponent<GameState>().bankAccount;

        double interest = bankAccountBalance * 0.02;

        int interestAsInt = (int)interest;

        int newBalance = bankAccountBalance + interestAsInt;

        obj.GetComponent<GameState>().bankAccount = newBalance;

        Account_text.text = string.Format("{0:N0}",
        obj.GetComponent<GameState>().bankAccount);
    }
    //코인 가격 변수
    public void RandomPrice()
    {
        float coin1Min = -0.02f;
        float coin1Max = 0.02f;
        float coin2Min = -0.1f;
        float coin2Max = 0.1f;

        float coin1Random = Random.Range(coin1Min, coin1Max);
        float coin2Random = Random.Range(coin2Min, coin2Max);

        float Floatcoin1Price = float.Parse(this.coin1.ToString());
        float Floatcoin2Price = float.Parse(this.coin2.ToString());

        Floatcoin1Price = Floatcoin1Price * coin1Random;
        int intcoin1Price = (int)Floatcoin1Price;

        Floatcoin2Price = Floatcoin2Price * coin2Random;
        int intcoin2Price = (int)Floatcoin2Price;

        this.coin1 += intcoin1Price;
        this.coinPosition1 += intcoin1Price;

        this.coin2 += intcoin2Price;
        this.coinPosition2 += intcoin2Price;

        Coin1_price.text = string.Format("KRW {0:N0}", this.coin1);
        Coin2_price.text = string.Format("KRW {0:N0}", this.coin2);
    }
    //코인1 구매 함수
    public void Coin1BuyButton()
    {
        int coinCount;
        int.TryParse(CoinCount_Field.text, out coinCount);
        Countcoin1+=coinCount;

        float floatBuyPrice = coinCount * this.coin1;
        int intBuyPrice = (int)floatBuyPrice;

        if (obj.GetComponent<GameState>().money >= intBuyPrice)
        {
            obj.GetComponent<GameState>().money -= intBuyPrice;
            this.coinPosition1 += intBuyPrice;
            CoinCount_Field.text = "구매 수량을 입력해주세요.";
        }

        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }
    //코인2 구매 함수
    public void Coin2BuyButton()
    {
        int coinCount;
        int.TryParse(CoinCount_Field.text, out coinCount);
        Countcoin2 += coinCount;

        float floatBuyPrice = coinCount * this.coin2;
        int intBuyPrice = (int)floatBuyPrice;

        if (obj.GetComponent<GameState>().money >= intBuyPrice)
        {
            obj.GetComponent<GameState>().money -= intBuyPrice;
            this.coinPosition2 += intBuyPrice;
            CoinCount_Field.text = "구매 수량을 입력해주세요.";
        }

        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }
    //코인2 판매 함수
    public void Coin1SellButton()
    {
        int coinCount;
        int.TryParse(CoinCount_Field.text, out coinCount);
        Countcoin1 -= coinCount;

        float floatSellPrice = coinCount * this.coin1;
        int intSellPrice = (int)floatSellPrice;

        if (this.coinPosition1 >= intSellPrice)
        {
            obj.GetComponent<GameState>().money += intSellPrice;
            this.coinPosition1 -= intSellPrice;
            CoinCount_Field.text = "구매 수량을 입력해주세요.";
        }

        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }
    //코인2 판매 함수
    public void Coin2SellButton()
    {
        int coinCount;
        int.TryParse(CoinCount_Field.text, out coinCount);
        Countcoin2 -= coinCount;

        float floatSellPrice = coinCount * this.coin2;
        int intSellPrice = (int)floatSellPrice;

        if (this.coinPosition2 >= intSellPrice)
        {
            obj.GetComponent<GameState>().money += intSellPrice;
            this.coinPosition2 -= intSellPrice;
            CoinCount_Field.text = "구매 수량을 입력해주세요.";
        }

        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }
    //은행 입금 함수
    public void InputAccount()
    {
        int inputMoney;
        int.TryParse(MoneyInput_Field.text, out inputMoney);

        //정상 작동 코드
        if (obj.GetComponent<GameState>().money >= inputMoney)
        {
            obj.GetComponent<GameState>().bankAccount += inputMoney;
            obj.GetComponent<GameState>().money -= inputMoney;

            Account_text.text = string.Format("{0:N0}",
            obj.GetComponent<GameState>().bankAccount);
            MoneyInput_Field.text = "금액을 입력해 주세요.";
        }
        //입력값(MoneyInput_Field)가 돈(money)보다 클 때
        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }
    //은행 출금 함수
    public void OutputAccount()
    {
        int inputMoney;
        int.TryParse(MoneyInput_Field.text, out inputMoney);

        //정상 작동 코드
        if (obj.GetComponent<GameState>().bankAccount >= inputMoney)
        {
            obj.GetComponent<GameState>().bankAccount -= inputMoney;
            obj.GetComponent<GameState>().money += inputMoney;

            Account_text.text = string.Format("{0:N0}",
            obj.GetComponent<GameState>().bankAccount);
            MoneyInput_Field.text = "금액을 입력해 주세요.";
        }
        //입력값(MoneyInput_Field)가 돈(money)보다 클 때
        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }
    //빚 상환 함수
    public void PayDebtButton()
    {
        int inputMoney;
        int.TryParse(MoneyInput_Field.text, out inputMoney);

        //정상 작동 코드
        if(obj.GetComponent<GameState>().money >= inputMoney)
        {
            obj.GetComponent<GameState>().debt += inputMoney;
            obj.GetComponent<GameState>().money -= inputMoney;

            Debt_text.text = string.Format("{0:N0}", 
            obj.GetComponent<GameState>().debt);
            MoneyInput_Field.text = "금액을 입력해 주세요.";
        }
        //입력값(MoneyInput_Field)가 돈(money)보다 클 때
        else
        {
            Error_text.gameObject.SetActive(true);
            StartCoroutine(ErrorDelay());
        }
    }

    //딜레이 후 Error_text 상태를 false로 변환
    IEnumerator ErrorDelay()
    {
        yield return new WaitForSeconds(2.0f);
        // 딜레이 뒤로 원하는 기능을 작성
        Error_text.gameObject.SetActive(false);
    }
}