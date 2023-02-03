using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2f;
    public GameObject targetPlanet = null;
    bool moving = false;

    void Start()
    {

    }

    void Update()
    {
        // orbitPlanet();
        moveForward();
    }

    void moveForward()
    {
        if (Input.GetKey("space"))
        {
            targetPlanet = null;

            // while (targetPlanet == null)
            //{
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed);
            //}
        }
    }

    // void orbitPlanet()
    // {
    //     if (!Input.GetKey("space") && targetPlanet != null)
    //     {

    //     }
    // }
}
