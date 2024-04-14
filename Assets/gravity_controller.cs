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

    Vector2 start_gravity;
    void Start()
    {
        gravity_input = gravity_input_object.GetComponent<TMP_InputField>();
        gravity_text = gravity_text_object.GetComponent<TMP_Text>();
        start_gravity = Physics2D.gravity;
        UpdateGravityText();
    }

    public void SetGravity()
    {
        float new_value = float.Parse(gravity_input.text.Replace(",", "."));
        Physics2D.gravity = new Vector2(0, -1 * new_value);
        UpdateGravityText();
    }

    public void ResetGravity()
    {
        Physics2D.gravity = start_gravity;
        gravity_input.text = "";
        UpdateGravityText();
    }

    public void UpdateGravityText()
    {
        gravity_text.text = "Yerçekimi ivmesi: \n" + Physics2D.gravity.y * -1 + "m/s^2";
    }
}