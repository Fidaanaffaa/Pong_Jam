using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private float arenaHeight = 10f;
    private const float MinimalSpeed = 20f;
    private Rigidbody2D rbBall;
    private GameObject _lastPlayerTouched = null;
    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        DropBall();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rbBall.velocity.magnitude <= MinimalSpeed)
        {            
            float totalVelocity = rbBall.velocity.magnitude;
            rbBall.velocity = new Vector2(rbBall.velocity.x / totalVelocity * MinimalSpeed,
                rbBall.velocity.y / totalVelocity * MinimalSpeed);
        }
    }

    void DropBall()
    {
        float xPos = GetStartingConditions();
        transform.position = new Vector3(xPos, arenaHeight, 0f);
        rbBall.AddForce(new Vector3(0, -100, 0));
        
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
    // 
    void OnCollisionExit2D (Collision2D coll) 
    {
        if (coll.gameObject.GetComponent<Collider2D>().CompareTag("Player"))
        {
            _lastPlayerTouched = coll.gameObject;
        }
    }


    public GameObject GetLastPlayerTouched()
    {
        return _lastPlayerTouched;
    }

    public void SetLastPlayerToNull()
    {
        _lastPlayerTouched = null;
    }
}

