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



    // long ass name
    public GameObject current_speed_x_object;
    public GameObject current_speed_y_object;
    TMP_Text current_speed_x_text;
    TMP_Text current_speed_y_text;

    public add_set_select add_set_state = add_set_select.Add;
    // Start is called before the first frame update
    void Start()
    {
        speed_x = speed_x_object.GetComponent<TMP_InputField>();
        speed_y = speed_y_object.GetComponent<TMP_InputField>();
        current_speed_x_text = current_speed_x_object.GetComponent<TMP_Text>();
        current_speed_y_text = current_speed_y_object.GetComponent<TMP_Text>();
        ball_rb = ball.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        current_speed_x_text.text = "hız x: " + ball_rb.velocity.x;
        current_speed_y_text.text = "hız y: " + ball_rb.velocity.y;
    }



    public void SubmitSpeed()
    {
        if (!float.TryParse(speed_x.text.Replace(",", "."), out float new_speed_x))
        {
            new_speed_x = 0f;
        }
        if (!float.TryParse(speed_y.text.Replace(",", "."), out float new_speed_y))
        {
            new_speed_y = 0f;
        }

        if (add_set_state == add_set_select.Set)
        {
            ball_rb.velocity = new Vector2(new_speed_x, new_speed_y);
        } else if (add_set_state == add_set_select.Add)
        {

            Vector2 current_speed = ball_rb.velocity;
            ball_rb.velocity = current_speed + new Vector2(new_speed_x, new_speed_y);
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
