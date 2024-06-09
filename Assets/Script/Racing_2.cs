using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing_2 : MonoBehaviour
{
    public Animator animator2;
    private bool contactBool = true;

    public float moveSpeed = 5f;

    public float moveMin = -0.5f;
    public float moveMax = 2f;

    private GameObject cat2;
    GameObject goal;

    void Start()
    {
        animator2 = GameObject.Find("Cat2").GetComponent<Animator>();
        cat2 = GameObject.Find("Cat2");
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            goal.GetComponent<Racing>().Rank.Add(2);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Goal2")
        {
            contactBool = false;
        }
    }
}
