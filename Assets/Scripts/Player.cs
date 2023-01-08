using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public bool GameOver = false;
    public int HP = 30;
    public GameObject PlayerUI;
    public GameObject NM;
    public GameObject AT;
    public GameObject HPBar;
    public GameObject DoImg;

    public TextMeshProUGUI HPTxt;
    private Animator anime;
    [SerializeField] float moveSpeed = 7f;
    Vector2 rawInput;
    public int level = 0;
    //level -1,0,1 층
    public int Score = 0;
    public float timer = 0;
    public bool trashIgnore = false;
    public bool isHitted = false;
    private SpriteRenderer render;
    public bool DoBelieve = false;
    public AudioSource adsr;
    public AudioClip CanSound;
    public AudioClip SojuSound;
    public AudioClip Sound;
    // public AudioClip CanSound;
    // public AudioClip CanSound;
    // public AudioClip CanSound;


    // [SerializeField] float paddingLeft;
    // [SerializeField] float paddingRight;
    // [SerializeField] float paddingTop;
    // [SerializeField] float paddingBottom;

    // Vector2 minBounds;
    // Vector2 maxBounds;

    void Start()
    {
        PlayerPrefs.SetInt("CS", 0);
        anime = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        adsr = GetComponent<AudioSource>();

    }

    void Update()
    {
        Move();
        HPCheck();
        timer += 100 * Time.deltaTime;
        Score = (int)timer;
        if (DoBelieve) {DoActive(1);}
        else {DoActive(-1);}
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
                gameObject.transform.position = new Vector3(-33f, -6, 1);
                break;
            case 0:
                gameObject.transform.position = new Vector3(-33f, 0, 1);
                break;
            case 1:
                gameObject.transform.position = new Vector3(-33f, 6, 1);
                break;
        }

    }
    public void DoActive(int k)
    {
        if (k == 1)
        {
            DoImg.transform.position = Vector2.MoveTowards(DoImg.transform.position, new Vector2(-13.67f, -0.77f), 10f * Time.deltaTime);
            
        }
        else if (k == -1) {
            Debug.Log("제발");
            DoImg.transform.position = Vector2.MoveTowards(DoImg.transform.position, new Vector2(3.51001f, -0.77f), 10f * Time.deltaTime);
        }
        
    }

        void HPCheck()
        {
            HPTxt.text = $"{HP}/30";
            HPBar.transform.localScale = new Vector2(HP * 0.03133f, 1);
            if (HP <= 0)
            {
                HPBar.transform.localScale = new Vector2(0, 1);
                Debug.Log("gameOver");
                GameOver = true;
                if (Score > PlayerPrefs.GetInt("HS"))
                {
                    PlayerPrefs.SetInt("HS", Score);
                }
                PlayerPrefs.SetInt("CS", Score);
            }

        }
        IEnumerator Attacked()
        {
            NM.SetActive(false);
            AT.SetActive(true);
            anime.SetBool("IsHitted", true);
            render.color = new Color(1, 170f / 255f, 170f / 255f, 1);
            isHitted = true;
            yield return new WaitForSeconds(0.3f);
            NM.SetActive(true);
            AT.SetActive(false);
            anime.SetBool("IsHitted", false);
            render.color = Color.white;

            isHitted = false;

            yield break;

        }

        void Sounds(AudioClip k){
            adsr.clip = k;
            adsr.Play();
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (isHitted == false)
            {
                switch (other.tag)
                {
                    case "Can":
                        Sounds(CanSound);
                        if (trashIgnore == false)
                        {
                            HP -= 3;
                        }
                        break;
                    case "TrashCan":
                        if (trashIgnore == false)
                        {
                            HP -= 5;
                        }
                        break;
                    case "Ggogal":
                        if (trashIgnore == false)
                        {
                            HP -= 10;
                        }
                        break;
                    case "Feb":
                        Destroy(other.gameObject);
                        trashIgnore = true;
                        break;
                    case "Soju":
                        HP -= 3;
                        Destroy(other.gameObject);
                        break;
                    case "DoBeliever":
                        Destroy(other.gameObject);
                        DoBelieve = true;
                        break;
                    case "Energy":
                        Destroy(other.gameObject);
                        HP += 5;
                        break;
                }
            }



            //장애물과 부딪혔을 때 점프 및 아파하는 모습 구현
            if (other.tag == "Can" || other.tag == "TrashCan" || other.tag == "Ggogal")
            {

                StartCoroutine("Attacked");
                Destroy(other.gameObject);

            }


        }


    }