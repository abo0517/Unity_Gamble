using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racing_3 : MonoBehaviour
{
    public Animator animator3;
    private bool contactBool = true;

    public float moveSpeed = 5f;

    public float moveMin = -0.5f;
    public float moveMax = 2f;

    private GameObject cat3;
    GameObject goal;

    void Start()
    {
        animator3 = GameObject.Find("Cat3").GetComponent<Animator>();
        cat3 = GameObject.Find("Cat3");
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

        float speed3 = Random.Range(moveMin, moveMax);

        if (contactBool == true)
        {
            animator3.SetBool("walk", true);

            cat3.transform.Translate(dir * moveSpeed * speed3 * Time.deltaTime);
        }
        else
        {
            animator3.SetBool("walk", false);
            goal.GetComponent<Racing>().Rank.Add(3);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Goal3")
        {
            contactBool = false;
        }
    }
}
