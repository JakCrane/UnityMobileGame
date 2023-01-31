using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 2f;

    void Start()
    {

    }

    void Update()
    {
        moveForward();
    }

    void moveForward()
    {
        if (Input.GetKey("space"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed);
        }
    }
}
