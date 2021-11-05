using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotate around "up" axis at given speed
        //the deltaTime is the amount of seconds from the previous frame.
        //Using deltaTime will create smooth movement regardless of frame rate
        transform.Rotate(Vector3.left * Time.deltaTime * speed);
    }
}
