using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Character;
    Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Character.transform.position;
        transform.Translate(0, 0, -10);
        
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (camera.orthographicSize < 20)
            {
                camera.orthographicSize += 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (camera.orthographicSize > 5)
            {
                camera.orthographicSize -= 1;
            }
        }
    }
}
