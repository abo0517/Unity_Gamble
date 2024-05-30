using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankScript : MonoBehaviour
{
    GameObject obj;

    public InputField IOInput;

    void Start()
    {
        obj = GameObject.Find("GameManager");
        //objGetComponent<GameState>().money;
    }

    void Update()
    {
        
    }
}