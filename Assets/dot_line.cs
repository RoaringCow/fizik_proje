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
    Camera cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        length_text = length_text_object.GetComponent<TMP_Text>();
        ball_object = GameObject.Find("Object");
        lr = GetComponent<LineRenderer>();
        float x = ball_object.transform.position.x;
        length_text_object.transform.position = cam.WorldToScreenPoint(new Vector3(x , (transform.position.y - 14.455f) / 2, 0));
        length_text.text = transform.position.y + 14.455f + " birim";
        lr.SetPosition(0, new Vector3(x, transform.position.y, 0));
        lr.SetPosition(1, new Vector3(x, -14.455f, 0));
    }

}
