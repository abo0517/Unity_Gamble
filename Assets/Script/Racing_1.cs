using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing_1 : MonoBehaviour
{
    public Animator animator1;
    private bool contactBool = true;

    public float moveSpeed = 0f;

    public float moveMin = 0f;
    public float moveMax = 1f;

    private GameObject cat1;
    public GameObject GameCanvas;
    GameObject goal;

    void Start()
    {
        animator1 = GameObject.Find("Cat1").GetComponent<Animator>();
        cat1 = GameObject.Find("Cat1");
        goal = GameObject.Find("Goal");
        InvokeRepeating("Move", 0f, 0.01f);
    }
    void Move()
    {
        Vector3 dir = Vector3.right;

        float speed1 = Random.Range(moveMin, moveMax);

        if (contactBool == true)
        {
            animator1.SetBool("walk", true);
            cat1.transform.Translate(dir * moveSpeed * speed1 * Time.deltaTime);
        }
        else
        {
            animator1.SetBool("walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Goal1")
        {
            GameCanvas.GetComponent<Racing>().Rank.Add(1);
        }
    }
}