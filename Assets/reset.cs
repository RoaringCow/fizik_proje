using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{

    GameObject ball;
    Rigidbody2D rb;
    dot_placer dot_script;
    TrailRenderer ball_trail;

    GameObject cam;

    GameObject time_control_object;
    time_controller time_control_script;

    GameObject gravity_control_object;
    gravity_controller gravity_control_script;

    // Start positions of the ball and the camera
    Vector3 object_start;
    Vector3 camera_start;

    void Start()
    {
        ball = GameObject.Find("Object");
        cam = GameObject.Find("Main Camera");
        time_control_object = GameObject.Find("time_control");
        gravity_control_object = GameObject.Find("gravity_contol_ui");

        time_control_script = time_control_object.GetComponent<time_controller>();
        rb = ball.GetComponent<Rigidbody2D>();
        ball_trail = ball.GetComponent<TrailRenderer>();
        gravity_control_script = gravity_control_object.GetComponent<gravity_controller>();

        // dot_script contains "DestroyDots" function
        dot_script = ball.GetComponent<dot_placer>();


        // Save the start position
        object_start = ball.transform.position;
        camera_start = cam.transform.position;
    }

    public void GameReset()
    {
        // Destroy all max height dots and lines;
        dot_script.DestroyDots();

        // Move them to the start position
        ball.transform.position = object_start;
        cam.transform.position = camera_start;

        // Reset the velocity of the object
        rb.velocity = Vector3.zero;

        // Reset the trail
        ball_trail.Clear();

        time_control_script.ResetTime();

        gravity_control_script.ResetGravity();

    }
}
