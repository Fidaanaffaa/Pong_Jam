using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CircularMovement : MonoBehaviour
{
    public Transform rotationCenter;
    public float _initial_angle = 0;
    public float angularSpeed, rotationRadius;
    private float posX, posY, angle = 0;
    private float _angle_limit = 2.0f * Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        posX = rotationRadius;
    }

    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector3(posX, posY, 0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle + _initial_angle);

        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= _angle_limit)
        {
            angle = 0;
        }
    }
}
