using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class Bowl : MonoBehaviour
{
    private float arenaHeight = 10f;
    private const float MinimalSpeed = 20f;
    public float boostSpeed = 1;
    private Rigidbody2D rbBall;
    private GameObject _lastPlayerTouched = null;
    private float _initialSpeed = 70;
    private bool _hittingMode = false;

    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        DropBall();
    }

    // Update is called once per frame
    void Update()
    
    
    {
        // minimal speed check and assure
        if (rbBall.velocity.magnitude < MinimalSpeed * boostSpeed & rbBall.velocity.magnitude != 0)
        {

            float totalVelocity = rbBall.velocity.magnitude;
            rbBall.velocity = new Vector2(rbBall.velocity.x / totalVelocity * MinimalSpeed * boostSpeed,
                rbBall.velocity.y / totalVelocity * MinimalSpeed * boostSpeed);
        }

        if (Input.GetKey(KeyCode.Space) & _hittingMode)
        {
            FireBall();
        }
    }

    void DropBall()
    {
        float xPos = GetStartingConditions();
        transform.position = new Vector3(xPos, arenaHeight, 0f);
        rbBall.AddForce(new Vector3(0, -_initialSpeed, 0));
        
    }
    // Randomly chooses a location for the ball to start in
    float GetStartingConditions()
    {
        // Choose which half the ball drops in
        int half = Random.Range(0,2);
        
        if (half == 1)
        {
            return Random.Range(1f, 5f);
        }
        else
        {
            return Random.Range(-1f, -5f);
        }

    }

    public void SetHittingModeTrue()
    {
        _hittingMode = true;
    }

    private void FireBall()
    {
        float ang  = transform.parent.parent.GetComponent<PlayerMovement>().GetAngle();
        transform.SetParent(null);
        boostSpeed = 1;
        Vector3 hit = new Vector2(Mathf.Cos(ang)* -_initialSpeed * 5, Mathf.Sin(ang) * -_initialSpeed * 5) ;
        rbBall.AddForce(hit);
        _hittingMode = false;
    }
    

    public GameObject GetLastPlayerTouched()
    {
        return _lastPlayerTouched;
    }
    
    public void SetLastPlayerTouched(GameObject obj)
    {
        _lastPlayerTouched = obj;
    }

    public void SetLastPlayerToNull()
    {
        _lastPlayerTouched = null;
    }
}

