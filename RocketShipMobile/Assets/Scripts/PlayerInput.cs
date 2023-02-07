using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float launchSpeed = 2f;
    [SerializeField] float orbitSpeed = 2f;
    public GameObject targetPlanet = null;
    bool moving = false;
    bool calibratingPosition = false;

    void Start()
    {

    }

    void Update()
    {
        OrbitPlanet();
        Launch();
    }

    void Launch()
    {
        if (Input.GetKey("space"))
        {
            targetPlanet = null;
            if (moving == false)
            {
                moving = true; // Stops moving being triggered again if the object is already moving.
                StartCoroutine(MoveForward());
            }
        }
    }

    IEnumerator MoveForward()
    {
        while (targetPlanet == null) // Only runs while it is not orbiting a planet.
        {
            transform.Translate(Vector3.up * Time.deltaTime * launchSpeed);
            yield return null;
        }
    }

    void OrbitPlanet()
    {
        if (targetPlanet != null && !calibratingPosition)
        {
            transform.RotateAround(targetPlanet.transform.localPosition, Vector3.back, Time.deltaTime * orbitSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!calibratingPosition)
        {
            if (other.gameObject.tag == "Planet")
            {
                moving = false;
                calibratingPosition = true;
                targetPlanet = other.gameObject;
                float targetPlanetX = targetPlanet.transform.position.x;
                RecalibratePosition(targetPlanetX);
            }
        }
    }

    void RecalibratePosition(float targetX) //Used to make Ship orbit a newly collided planet correctly.
    {
        transform.rotation = Quaternion.identity; // Reset rotation
        float angleToTarget = Vector2.Angle(transform.up, targetPlanet.transform.position - transform.position);

        if (targetX > transform.position.x) // If Ship hits left side of planet
        {
            Debug.Log("Left side of planet");
            transform.Rotate(new Vector3 (0f, 0f, 90 - angleToTarget));
        }
        else // If Ship hits right side of planet
        {
            Debug.Log("Right side of planet");
            transform.Rotate(new Vector3 (0f, 0f, 90 + angleToTarget));
        }
        calibratingPosition = false; // Other processes (such as orbiting planet) can continue now.
    }
}
