using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public bool GameOver = false;
    public int HP = 30;
    public GameObject PlayerUI;
    public Rigidbody2D rb;
    [SerializeField] float moveSpeed = 7f;
    Vector2 rawInput;
    public int level = 0;
    //level -1,0,1 층
    public int Score = 0;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        PlayerPrefs.SetInt("CS",0);
    }

    void Update()
    {
        Move();
    }


    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) && level < 1)
        {
            level += 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && level > -1f)
        {
            level -= 1;
        }

        switch (level)
        {
            case -1:
                gameObject.transform.position = new Vector3(-35f, -6, 1);
                break;
            case 0:
                gameObject.transform.position = new Vector3(-35f, 0, 1);
                break;
            case 1:
                gameObject.transform.position = new Vector3(-35f, 6, 1);
                break;
        }

    }

    void gameEnd(){
        if(HP <= 0){
            Debug.Log("gameOver");
            GameOver = true;
            if(Score > PlayerPrefs.GetInt("HS"))
            {
                PlayerPrefs.SetInt("HS", Score);
            }
            PlayerPrefs.SetInt("CS",Score);
        }
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
    void OnTriggerEnter2D(Collider2D other)
    {
        //장애물과 부딪혔을 때 점프 및 아파하는 모습 구현
        if (other.tag == "Can" || other.tag == "TrashCan" || other.tag == "Ggogal")
        {
            Debug.Log("아파!");
            StartCoroutine("Attacked");

        }
        if (other.tag == "TrashCan")
        {
            HP -= 10;
            // Debug.Log(HP);
        }
        if (other.tag == "")
        {
            HP -= 10;
            // Debug.Log(HP);
        }
    }

}