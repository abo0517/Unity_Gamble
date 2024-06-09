using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ladder_ball : MonoBehaviour
{
    GameObject obj;
    bool istrigger = false;
    int x = 0;
    int y = -1;
    void Start()
    {
        obj = GameObject.Find("GameCanvas");
        move();
    }
    void move(){
        transform.Translate(new Vector3(x, y, 0));
        if(transform.localPosition.y <= -350){
            if(transform.localPosition.x < 0){
                obj.GetComponent<Ladder>().finish_game("left");
            }
            else if(transform.localPosition.x > 0){
                obj.GetComponent<Ladder>().finish_game("right");
            }
            return;
        }
        Invoke("move",0.01f);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(!istrigger){
            if (other.tag == "left"){
                x = 1;
                y = 0;
                
            }
            else if(other.tag == "right"){
                x = -1;
                y = 0;
            }
            istrigger = true;
        }
        else{
            if (other.gameObject.CompareTag("left")){
                x = 0;
                y = -1;
            }
            else if(other.gameObject.CompareTag("right")){
                x = 0;
                y = -1;
            }
            istrigger = false;
        }
    }
}
