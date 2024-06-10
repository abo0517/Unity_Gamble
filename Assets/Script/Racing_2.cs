using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing_2 : MonoBehaviour
{
    public Animator animator2;
    private bool contactBool = true;

    public float moveSpeed = 0f;

    public float moveMin = 0f;
    public float moveMax = 1f;

    private GameObject cat2;
    public GameObject GameCanvas;
    GameObject goal;

    void Start()
    {
        animator2 = GameObject.Find("Cat2").GetComponent<Animator>();
        cat2 = GameObject.Find("Cat2");
        goal = GameObject.Find("Goal");
        InvokeRepeating("Move", 0f, 0.01f);
    }
    void Move()
    {
        Vector3 dir = Vector3.right;

        float speed2 = Random.Range(moveMin, moveMax);

        if (contactBool == true)
        {
            animator2.SetBool("walk", true);
            cat2.transform.Translate(dir * moveSpeed * speed2 * Time.deltaTime);
        }
        else
        {
            animator2.SetBool("walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Goal2")
        {
            GameCanvas.GetComponent<Racing>().Rank.Add(2);
        }
    }
}
