using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dot_line : MonoBehaviour
{
    LineRenderer lr;
    GameObject ball_object;
    public GameObject length_text_object;
    TMP_Text length_text;
    void Start()
    {
        length_text = length_text_object.GetComponent<TMP_Text>();
        ball_object = GameObject.Find("Object");
        lr = GetComponent<LineRenderer>();
        float x = ball_object.transform.position.x;
        Debug.Log("sex");
        length_text_object.transform.position = new Vector3(x , (transform.position.y - 15) / 2, 0);
        length_text.text = transform.position.y + 15 + " birim";
        lr.SetPosition(0, new Vector3(x, transform.position.y, 0));
        lr.SetPosition(1, new Vector3(x, -15, 0));
    }

}
