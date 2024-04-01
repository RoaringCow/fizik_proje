using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Author : Demirdt >:)
public class Arrows : MonoBehaviour
{
    public GameObject arrow_x,arrow_tip_x,arrow_tip_y, arrow_y,_object;
    public TMP_InputField inpu_speed_x, input_speed_y;
    public SpriteRenderer arrowX_renderer,arrowHeadX_renderer, arrowHeadY_renderer,arrowY_renderer;
    public Rigidbody2D speed;
    void Start()
    {

    }


    void Update()
    {

        arrow_x.transform.localScale = new Vector2(Mathf.Abs(speed.velocity.x / 5), 0.2f);
        arrow_y.transform.localScale = new Vector2(0.2f, Mathf.Abs(speed.velocity.y / 5));
        if (speed.velocity.x > 0)
        {
            arrow_tip_x.transform.localScale = new Vector2(0.4f,0.4f);
            arrow_x.transform.localPosition = new Vector2(arrow_x.transform.localScale.x / 2 + 1, 0);
            arrow_tip_x.transform.localPosition = new Vector2(arrow_x.transform.localScale.x + 1, 0);
        }
        else if(speed.velocity.x < 0)
        {
            arrow_tip_x.transform.localScale = new Vector2(0.4f, -0.4f);
            arrow_x.transform.localPosition = new Vector2((arrow_x.transform.localScale.x * -1) / 2 - 1, 0);
            arrow_tip_x.transform.localPosition = new Vector2((arrow_x.transform.localScale.x * -1) - 1, 0);
        }
        else
        {
            arrow_tip_x.transform.localScale = Vector2.zero;
        }


        if (speed.velocity.y > 0)
        {
            arrow_tip_y.transform.localScale = new Vector2(0.4f, 0.4f);
            arrow_y.transform.localPosition = new Vector2(0, arrow_y.transform.localScale.y / 2 + 1);
            arrow_tip_y.transform.localPosition = new Vector2(0, arrow_y.transform.localScale.y + 1);
        }
        else if (speed.velocity.y < 0)
        {
            arrow_tip_y.transform.localScale = new Vector2(0.4f,- 0.4f);
            arrow_y.transform.localPosition = new Vector2(0,(arrow_y.transform.localScale.y * -1) / 2 - 1);
            arrow_tip_y.transform.localPosition = new Vector2(0, (arrow_y.transform.localScale.y * -1) - 1);
        }
        else
        {
            arrow_tip_y.transform.localScale = Vector2.zero;
        }
    }

}
//arrow_x.transform.localScale = new Vector2(float.Parse(speed_x.text) / 5,0.2f);
//arrow_x.transform.localPosition = new Vector2(arrow_x.transform.localScale.x / 2 + 1,0);
//arrow_tip_x.transform.localPosition = new Vector2(arrow_x.transform.localScale.x + 1 , 0);

//arrow_y.transform.localScale = new Vector2(0.2f, float.Parse(speed_y.text) / 5);
//arrow_y.transform.localPosition = new Vector2(0, arrow_y.transform.localScale.y / 2 + 1);
//arrow_tip_y.transform.localPosition = new Vector2(0, arrow_y.transform.localScale.y + 1);
