using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gravity_controller : MonoBehaviour
{

    public GameObject gravity_input_object;
    TMP_InputField gravity_input;
    public GameObject gravity_text_object;
    TMP_Text gravity_text;
    void Start()
    {
        gravity_input = gravity_input_object.GetComponent<TMP_InputField>();
        gravity_text = gravity_text_object.GetComponent<TMP_Text>();
    }

    public void SetGravity()
    {
        float new_value = float.Parse(gravity_input.text.Replace(",", "."));
        Physics2D.gravity = new Vector2(0, -1 * new_value);
        gravity_text.text = "Yerçekimi ivmesi: \n" + new_value + "m/s^2";
    }
}