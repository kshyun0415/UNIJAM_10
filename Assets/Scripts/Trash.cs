using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class Trash : MonoBehaviour
{
    Random random = new Random();
    int num1, num2;

    void Start()
    {
    Random random = new Random();
    num1= random.Next(-1,2);
    num2= random.Next(-12, -6);
        // Debug.Log(num1);
        // Debug.Log(num2);
    }


    void Update()
    {
        Move();

        if(transform.position.x <-40){
            Destroy(gameObject);
        }
    }

    void Move(){
        int moveSpeed=num1;
        int trash_Level=num2;

        Vector2 newPos=new Vector2();

        newPos.x=transform.position.x + num2 * Time.deltaTime;
        newPos.y=num1 * 7;
        transform.position=newPos;
    }
}
