using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speed_controller : MonoBehaviour
{
    public GameObject speed_x_object;
    public GameObject speed_y_object;
    TMP_InputField speed_x;
    TMP_InputField speed_y;

    public GameObject ball;
    Rigidbody2D ball_rb;

    public add_set_select add_set_state = add_set_select.Add;
    // Start is called before the first frame update
    void Start()
    {
        speed_x = speed_x_object.GetComponent<TMP_InputField>();
        speed_y = speed_y_object.GetComponent<TMP_InputField>();
        ball_rb = ball.GetComponent<Rigidbody2D>();
    }



    public void SubmitSpeed()
    {
        if (add_set_state == add_set_select.Set)
        {
            ball_rb.velocity = new Vector2(int.Parse(speed_x.text), int.Parse(speed_y.text));
        } else if (add_set_state == add_set_select.Add)
        {
            Vector2 current_speed = ball_rb.velocity;
            ball_rb.velocity = current_speed + new Vector2(int.Parse(speed_x.text), int.Parse(speed_y.text));
        }
        speed_x.text = "";
        speed_y.text = "";
    }

    public void Switch_to_set()
    {
        add_set_state = add_set_select.Set;
    }
    public void Switch_to_add()
    {
        add_set_state = add_set_select.Add;
    }


    public enum add_set_select {
        Add,
        Set,
    };
}
