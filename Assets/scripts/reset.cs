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
    camera cam_script;

    GameObject time_control_object;
    time_controller time_control_script;

    GameObject gravity_control_object;
    gravity_controller gravity_control_script;

    GameObject platform;
    Platform_Controller platform_script;

    // Start positions of the ball and the camera
    Vector3 object_start;
    Vector3 camera_start;

    void Start()
    {
        ball = GameObject.Find("Object");
        cam = GameObject.Find("Main Camera");
        time_control_object = GameObject.Find("time_control");
        gravity_control_object = GameObject.Find("gravity_contol_ui");
        platform = GameObject.Find("Platform");



        ball_trail = ball.GetComponent<TrailRenderer>();
        rb = ball.GetComponent<Rigidbody2D>();
        cam_script = cam.GetComponent<camera>();
        time_control_script = time_control_object.GetComponent<time_controller>();
        gravity_control_script = gravity_control_object.GetComponent<gravity_controller>();
        platform_script = platform.GetComponent<Platform_Controller>();

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

        cam_script.ResetZoom();

        // Reset the velocity of the object
        rb.velocity = Vector3.zero;

        // Reset the trail
        ball_trail.Clear();

        time_control_script.ResetTime();

        gravity_control_script.ResetGravity();

        platform_script.ResetPosition();
    }
}
