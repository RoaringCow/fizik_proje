using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speed_controller : MonoBehaviour
{

    // XY input
    public GameObject speed_x_object, speed_y_object;
    TMP_InputField speed_x, speed_y;
    // long ass name
    public GameObject current_speed_x_object, current_speed_y_object;
    TMP_Text current_speed_x_text, current_speed_y_text;
    //----------------------------


    // Angle input
    public GameObject angle_inputfield_object, force_inputfield_object;
    TMP_InputField angle_inputfield, force_inputfield;
    //-------------------------------------------------------


    public GameObject ball;
    Rigidbody2D ball_rb;


    public GameObject ParentXY;
    public GameObject ParentAngle;

    public add_set_select add_set_state = add_set_select.Add;
    public speed_control_select speed_control_state = speed_control_select.XY_Values;
    // Start is called before the first frame update
    void Start()
    {
        speed_x = speed_x_object.GetComponent<TMP_InputField>();
        speed_y = speed_y_object.GetComponent<TMP_InputField>();
        current_speed_x_text = current_speed_x_object.GetComponent<TMP_Text>();
        current_speed_y_text = current_speed_y_object.GetComponent<TMP_Text>();
        ball_rb = ball.GetComponent<Rigidbody2D>();

        angle_inputfield = angle_inputfield_object.GetComponent<TMP_InputField>();
        force_inputfield = force_inputfield_object.GetComponent<TMP_InputField>();


    }

    private void Update()
    {
        current_speed_x_text.text = "hız x: " + ball_rb.velocity.x;
        current_speed_y_text.text = "hız y: " + ball_rb.velocity.y;
    }


    public void SubmitSpeed()
    {
        switch (speed_control_state)
        {
            case speed_control_select.XY_Values:
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

                break;

            case speed_control_select.Angle:
                if (!float.TryParse(angle_inputfield.text.Replace(",", "."), out float new_angle))
                {
                    new_angle = 0f;
                }
                if (!float.TryParse(force_inputfield.text.Replace(",", "."), out float new_force))
                {
                    new_force = 0f;
                }

                float new_x_speed = Mathf.Cos((new_angle % 360) * Mathf.Deg2Rad) * new_force;
                float new_y_speed = Mathf.Sin((new_angle % 360) * Mathf.Deg2Rad) * new_force;
                Debug.Log(Mathf.Cos((new_angle % 360) * Mathf.Deg2Rad));
                Debug.Log(Mathf.Sin((new_angle % 360) * Mathf.Deg2Rad));
                Debug.Log(new Vector2(new_x_speed, new_y_speed));
                switch (add_set_state)
                {
                    case add_set_select.Add:
                        ball_rb.velocity += new Vector2(new_x_speed, new_y_speed);

                        break;
                    case add_set_select.Set:
                        ball_rb.velocity = new Vector2(new_x_speed, new_y_speed);

                        break;

                }

                angle_inputfield.text = "";
                force_inputfield.text = "";
                break;
        }
    }

    public void Switch_to_Angle()
    {
        ParentAngle.SetActive(true);
        ParentXY.SetActive(false);
        speed_control_state = speed_control_select.Angle;
    }
    public void Switch_to_XY()
    {
        ParentAngle.SetActive(false);
        ParentXY.SetActive(true);
        speed_control_state = speed_control_select.XY_Values;
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
    public enum speed_control_select
    {
        Angle,
        XY_Values,
    }

}
