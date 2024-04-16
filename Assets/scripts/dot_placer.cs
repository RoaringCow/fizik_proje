using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot_placer : MonoBehaviour
{

    bool going_up = false;
    Rigidbody2D rb;
    public GameObject dot_prefab;
    List<GameObject> dot_list;
    Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        dot_list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 0)
        {
            going_up = true;
        }
        else
        {
            if (going_up)
            {
                PlaceDot();
            }
            going_up = false;
        }
    }

    void PlaceDot()
    {
        // place the dot
        GameObject dot = Instantiate(dot_prefab, transform.position, Quaternion.identity);
        dot_list.Add(dot);   
    }

    public void FixDotPlacement()
    {
        foreach (GameObject dot in dot_list)
        {
            GameObject text_object = dot.transform.GetChild(0).GetChild(0).gameObject;
            text_object.transform.position = cam.WorldToScreenPoint(new Vector3(dot.transform.position.x, Mathf.Round((dot.transform.position.y - 0.5f) * 100f) / 100f / 2, 0));
            Debug.Log("tried to fix");
        }
    }

    public void DestroyDots()
    {
        foreach (GameObject dot in dot_list)
        {
            GameObject.Destroy(dot, 0.0f);
        }
        dot_list.Clear();
    }
}
