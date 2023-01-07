
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{   
    public int HP=30;
    public GameObject PlayerUI;
    [SerializeField] float moveSpeed = 7f;
    Vector2 rawInput;
    int level=0;

    // public Heresy heresy;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    
    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
        // hitHeresy();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime * 50;
        Vector2 newPos = new Vector2();
        // newPos.x = Mathf.Clamp(transform.position.x + moveSpeed * Time.deltaTime, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.x = 0;
        newPos.y = Mathf.Clamp(level*7, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        
        transform.position = newPos;
        
    }

    void OnMove(InputValue value)
    {   level+=(int)rawInput.y;
        rawInput = value.Get<Vector2>();

        
        // Debug.Log(rawInput);

    }
    IEnumerator Attacked()
    {       
            PlayerUI.transform.Find("Basic").gameObject.SetActive(false);
            PlayerUI.transform.Find("Attacked").gameObject.SetActive(true);
            yield return 0.2f;
            PlayerUI.transform.Find("Basic").gameObject.SetActive(true);
            PlayerUI.transform.Find("Attacked").gameObject.SetActive(false);
            yield break;
            
    }
    void OnTriggerEnter2D(Collider2D other){
        //장애물과 부딪혔을 때 점프 및 아파하는 모습 구현
        if(other.tag=="Can" || other.tag=="TrashCan" || other.tag=="Ggogal")
        {
            Debug.Log("아파!");
            StartCoroutine("Attacked");
            
        }
        if(other.tag=="TrashCan"){
            HP-=10;
            // Debug.Log(HP);
        }
        if(other.tag==""){
            HP-=10;
            // Debug.Log(HP);
        }
    }
    
}
