using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform_Controller : MonoBehaviour
{
    public GameObject platform,Label;
    TMP_Text label_text;
    public Transform ray_origin;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    private bool platform_moving = false;
    private Vector3 offset;
    public float platform_height;
<<<<<<< HEAD:Assets/Platform_Controller.cs
    private Vector3 mouse_pos;
=======
    Vector3 start_pos;
>>>>>>> 48291d6a0e5ff9db4f74c431b5cecf018ec5fbc5:Assets/scripts/Platform_Controller.cs
    void Start()
    {
        label_text = Label.GetComponent<TMP_Text>();
        PlatformModeChange(false);
        start_pos = transform.position;
    }

    void Update()
    {
        
        if(platform_moving)
        {
            mouse_pos = new (Mathf.Round(Input.mousePosition.x * 10) * 0.1f, Input.mousePosition.y,Input.mousePosition.z);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        label_text.text = "Platform Yüksekliği:" + (Mathf.Floor(ray_origin.position.y));
    }
    public void PlatformModeChange(bool tog)
    {
        if (tog)
        {
            PlatformOn();
        }
        else
        {
            PlatformOff();
        }
    }
    public void ResetPosition()
    {
        transform.position = start_pos;
        label_text.text = "Platform Yüksekliği:" + (Mathf.Floor(ray_origin.position.y));
    }
    void PlatformOn()
    {
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
    }
    void PlatformOff()
    {
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        platform_moving = true;
    }
    private void OnMouseUp()
    {
        platform_moving = false;
        transform.position = new Vector3(transform.position.x, Mathf.Floor(ray_origin.position.y), 0);
        label_text.text = "Platform Yüksekliği:" + (Mathf.Floor(ray_origin.position.y));
    }
}
