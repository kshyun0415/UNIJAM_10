using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    
bool onSelected;
Camera mainCamera;
RectTransform rectTransform;
Vector2 targetPosition;
RaycastHit2D hit;
public int clickNum = 0;
public Player player;
public AudioClip dosound;

private SpriteRenderer render;

Collider2D col;
    void MouseClickDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            Attack();
        }
    }
    void Attack()
    {   
        if (hit.transform.GetComponent<Collider2D>() == col)
        {   
            if(clickNum >= 40)
            {   
                player.DoBelieve = false;
                clickNum = 0;
                return;      
            }
            clickNum += 1;
            player.Sounds(dosound);
            StartCoroutine("Attacked");    
        }
    
    }
    IEnumerator Attacked()
    {    
        transform.position = new Vector2(-12,-0.65f);
        render.color = new Color(1, 170f / 255f, 170f / 255f, 1);
        yield return new WaitForSeconds(0.3f);
        render.color = Color.white;
        yield break;

    }
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickDown();
    }
}
