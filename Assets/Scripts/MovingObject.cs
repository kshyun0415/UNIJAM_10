using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    float Ran;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        Ran = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
         if (transform.position.x < -40)
        {
            Destroy(gameObject);
        }
    }
    void Move()
    {
        Debug.Log(Ran);
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x - GM.gameSpeed * Time.deltaTime;
        newPos.y = Ran * 6;
        Debug.Log(newPos.x);
        transform.position = newPos;

       
    }
}
