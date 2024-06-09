using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing_1 : MonoBehaviour
{
    public Animator animator1;
    private bool contactBool = true;

    public float moveSpeed = 5f;

    public float moveMin = -0.5f;
    public float moveMax = 2f;

    private GameObject cat1;
    GameObject goal;

    void Start()
    {
        animator1 = GameObject.Find("Cat1").GetComponent<Animator>();
        cat1 = GameObject.Find("Cat1");

        goal = GameObject.Find("Goal");
    }

    void Update()
    {
        Move();
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
            contactBool = false;
            goal.GetComponent<Racing>().Rank.Add(1);
        }
    }
}