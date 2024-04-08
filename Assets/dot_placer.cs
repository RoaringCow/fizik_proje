using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot_placer : MonoBehaviour
{

    bool going_up = false;
    Rigidbody2D rb;
    public GameObject dot_prefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 0)
        {
            going_up = true;
        }
        else
        {
            if (going_up)
            {
                PlaceDot();
            }
            going_up = false;
        }
    }

    void PlaceDot()
    {
        // place the dot
        Instantiate(dot_prefab, transform.position, Quaternion.identity);
    }
}
