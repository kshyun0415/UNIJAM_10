using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coonya : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(-10 + (30 - player.HP)/3f);
        transform.position = new Vector3 ( player.transform.position.x - 10 + (30 - player.HP)/3f, player.transform.position.y , player.transform.position.z);
    }
}
