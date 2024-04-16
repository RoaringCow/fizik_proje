using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_mode : MonoBehaviour
{
    public Modes current_mode = Modes.MoveObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    public void Change_to_MoveObject()
    {
        current_mode = Modes.MoveObject;
    }
    public void Change_to_MoveCamera()
    {
        current_mode = Modes.MoveCamera;
    }


    public enum Modes
    {
        MoveObject,
        MoveCamera,
    }
}
