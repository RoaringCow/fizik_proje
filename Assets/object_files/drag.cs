using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{


    private GameObject mode;
    private object_mode mode_script;
    public bool dragging = false;
    private Vector3 offset;
    public Rigidbody2D rb;

    void Start()
    {
        mode = GameObject.Find("object_mode");
        mode_script = mode.GetComponent<object_mode>();
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (dragging && mode_script.current_mode == object_mode.Modes.MoveObject)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            
        }
        if (dragging)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;

    }

    private void OnMouseUp()
    {
        dragging = false;
    }

}