using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject _object;
    public Rigidbody2D rb;
    private Vector2 old_pos,new_pos;
    public TMP_Text timer_text;
    public bool timer_enabled,dragging;
    public float timer;
    void Start()
    {
        timer_enabled = false;
        old_pos = Vector2.zero;
        new_pos = Vector2.zero;
    }


    void Update()
    {
        dragging = _object.GetComponent<drag>().dragging;
        old_pos = _object.transform.position;

        if(!timer_enabled && !dragging && rb.velocity.magnitude != 0)
        {
            timer_enabled = true;
            timer = 0;
        }
        else if(rb.velocity.magnitude == 0)
        {
            timer_enabled = false;
        }
        new_pos = _object.transform.position;
        if (timer_enabled )
        {
            timer += Time.deltaTime;
            timer_text.text = "Havada Kalma Süresi:" + (Mathf.Round(timer * 100f) * 0.01f) + "sn";
        }
    }
}
