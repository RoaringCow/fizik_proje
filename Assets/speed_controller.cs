using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speed_controller : MonoBehaviour
{

    TMP_InputField speed_x;
    TMP_InputField speed_y;

    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Object");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
