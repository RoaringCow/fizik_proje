using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Author : Demirdt >:)
public class Arrows : MonoBehaviour
{
    public GameObject arrow_x,arrow_tip_x,arrow_tip_y, arrow_y,_object;
    TMP_InputField input_speed_x, input_speed_y;
    public GameObject input_speed_x_object, input_speed_y_object;
    public SpriteRenderer arrowX_renderer,arrowHeadX_renderer, arrowHeadY_renderer,arrowY_renderer;
    public Rigidbody2D speed;
    void Start()
    {
        input_speed_x = input_speed_x_object.GetComponent<TMP_InputField>();
        input_speed_y = input_speed_y_object.GetComponent<TMP_InputField>();
    }


    void Update()
    {

        if (!float.TryParse(input_speed_x.text.Replace(",", "."), out float new_speed_x))
        {
            new_speed_x = speed.velocity.x;
        }
        if (!float.TryParse(input_speed_y.text.Replace(",", "."), out float new_speed_y))
        {
            new_speed_y = speed.velocity.y;
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
    }

}