using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing_3 : MonoBehaviour
{
    public Animator animator3;
    private bool contactBool = true;

    public float moveSpeed = 0f;

    public float moveMin = 0f;
    public float moveMax = 1f;

    private GameObject cat3;
    public GameObject GameCanvas;
    GameObject goal;

    void Start()
    {
        animator3 = GameObject.Find("Cat3").GetComponent<Animator>();
        cat3 = GameObject.Find("Cat3");
        goal = GameObject.Find("Goal");
        InvokeRepeating("Move", 0f, 0.01f);
    }
    void Move()
    {
        Vector3 dir = Vector3.right;

        float speed3 = Random.Range(moveMin, moveMax);

        if (contactBool == true)
        {
            animator3.SetBool("walk", true);
            cat3.transform.Translate(dir * moveSpeed * speed3 * Time.deltaTime);
        }
        else
        {
            animator3.SetBool("walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Goal3")
        {
            GameCanvas.GetComponent<Racing>().Rank.Add(3);
        }
    }
}
