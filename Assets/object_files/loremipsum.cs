using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loremipsum : MonoBehaviour
{

    private GameObject mode;
    private object_mode mode_script;

    void Start()
    {
        mode = GameObject.Find("object_mode");
        mode_script = mode.GetComponent<object_mode>();
    }

    // Update is called once per frame
    void Update()
    {
    }

}
