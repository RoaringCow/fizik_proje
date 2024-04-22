using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Author : Demirdt >:)
public class Arrows : MonoBehaviour
{
    public GameObject arrow_x,arrow_tip_x,arrow_y, arrow_tip_y,arrow_vel,arrow_tip_vel, _object;
    TMP_InputField input_speed_x, input_speed_y;
    public GameObject input_speed_x_object, input_speed_y_object;
    public SpriteRenderer arrowX_renderer,arrowHeadX_renderer, arrowHeadY_renderer,arrowY_renderer;
    public Rigidbody2D rb;
    void Start()
    {

        input_speed_x = input_speed_x_object.GetComponent<TMP_InputField>();
        input_speed_y = input_speed_y_object.GetComponent<TMP_InputField>();

    }


    void Update()
    {

        if (!float.TryParse(input_speed_x.text.Replace(",", "."), out float new_speed_x))
        {
            new_speed_x = rb.velocity.x;
        }
        if (!float.TryParse(input_speed_y.text.Replace(",", "."), out float new_speed_y))
        {
            new_speed_y = rb.velocity.y;
        }
        arrow_x.transform.localScale = new Vector2(Mathf.Abs(new_speed_x / 5), 0.2f);
        arrow_y.transform.localScale = new Vector2(0.2f, Mathf.Abs(new_speed_y / 5));


        int x_direction = (new_speed_x > 0) ? 1 : -1;
        int y_direction = (new_speed_y > 0) ? 1 : -1;
        if (new_speed_x != 0)
        {
            arrow_tip_x.transform.localScale = new Vector2(0.4f, 0.4f * x_direction);
        }else {
            arrow_tip_x.transform.localScale = Vector2.zero;
        }

        if (new_speed_y != 0)
        {
            arrow_tip_y.transform.localScale = new Vector2(0.4f, 0.4f * y_direction);
        }else
        {
            arrow_tip_y.transform.localScale = Vector2.zero;
        }

        arrow_x.transform.localPosition = new Vector2(arrow_x.transform.localScale.x / 2 * x_direction, 0);
        arrow_tip_x.transform.localPosition = new Vector2(arrow_x.transform.localScale.x * x_direction, 0);

        arrow_y.transform.localPosition = new Vector2(0, arrow_y.transform.localScale.y / 2 * y_direction);
        arrow_tip_y.transform.localPosition = new Vector2(0, arrow_y.transform.localScale.y * y_direction);

        arrow_tip_vel.transform.localPosition = new Vector2(rb.velocity.x/5,rb.velocity.y/5);
        float vel_lenght = (arrow_tip_vel.transform.position - _object.transform.position).magnitude;
        arrow_vel.transform.localScale = new Vector2(vel_lenght,0.2f);
        arrow_vel.transform.rotation = Quaternion.Euler(0,0,(Mathf.Atan2(rb.velocity.y,rb.velocity.x))* Mathf.Rad2Deg);
        arrow_vel.transform.localPosition = new Vector2(arrow_tip_x.transform.localPosition.x/2, arrow_tip_y.transform.localPosition.y / 2);
        arrow_tip_vel.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(rb.velocity.y / 2, rb.velocity.x / 2)) * Mathf.Rad2Deg - 90);
    }

}