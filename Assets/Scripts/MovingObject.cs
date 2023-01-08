using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    float Ran;
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
        newPos.x = transform.position.x - PlayerPrefs.GetFloat("Speed") * Time.deltaTime;
        newPos.y = Ran * 6;
        transform.position = newPos;

    }
}
