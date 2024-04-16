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
    Vector3 start_pos;
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
