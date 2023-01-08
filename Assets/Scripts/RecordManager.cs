using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordManager : MonoBehaviour
{
    public TextMeshProUGUI HsTxt;
    int HS = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HS = PlayerPrefs.GetInt("HS");
        HsTxt.text = $"HIGH SCORE  {HS}";
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.SetInt("HS", 0);
        }
    }
}
