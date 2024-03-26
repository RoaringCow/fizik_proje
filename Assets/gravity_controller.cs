using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGravity(Vector3 new_gravity)
    {
        Physics.gravity = new_gravity;
    }
}
