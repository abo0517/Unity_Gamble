using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing : MonoBehaviour
{

    public List<int> Rank = new List<int>();

    void Start()
    {

    }

    void Update()
    {
        RankList();
    }

    public void RankList()
    {
        foreach (int rank in Rank)
        {
            Debug.Log(rank);
        }
    }
}
