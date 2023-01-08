using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float image_width;

    private void Awake() {
        
        BoxCollider2D bgCollider = GetComponent<BoxCollider2D>();
        image_width = bgCollider.size.x * 2.21f;  // Get the image width from the BoxCollider variable
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Reposition the image by translating width*2 to right
        if(transform.position.x <= - image_width) {
            Vector2 offset = new Vector2(280.73f, 55.25737f);
            transform.position = offset;
        }
    }
}
