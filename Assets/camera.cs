using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private GameObject mode;
    private object_mode mode_script;
    [SerializeField] private bool dragging = false;
    [SerializeField] private Vector3 drag_start;

    private Camera cam;

    void Start()
    {
        mode = GameObject.Find("object_mode");
        mode_script = mode.GetComponent<object_mode>();
        cam = this.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            drag_start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        if (dragging && mode_script.current_mode == object_mode.Modes.MoveCamera)
        {
            Vector3 current_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.Translate(new Vector3((current_pos.x - drag_start.x) * -1, (current_pos.y - drag_start.y) * -1, (current_pos.z - drag_start.z) * -1));
        }
    }

    public void ZoomIn()
    {
        cam.orthographicSize -= 0.5f;
    }

    public void ZoomOut()
    {
        cam.orthographicSize += 0.5f;
    }
}
