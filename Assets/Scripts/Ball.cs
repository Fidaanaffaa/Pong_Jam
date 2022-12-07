using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float arenaHeight = 10f;
    public float ballSpeed = 1.0f;
    private Rigidbody2D rbBall;
    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        DropBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropBall()
    {
        float xPos = GetStartingConditions();
        transform.position = new Vector3(xPos, arenaHeight, 0f);
        rbBall.AddForce(new Vector3(0, -200, 0));
        
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
    void OnCollisionEnter2D (Collision2D coll) {
    // if(coll.collider.CompareTag("Paddle")){
    //     Vector2 vel;
    //     vel.x = rbBall.velocity.x;
    //     vel.y = (rbBall.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
    //     rbBall.velocity = vel;
    //     }
        rbBall.AddForce(new Vector3(coll.contacts[0].normal.x * 100, coll.contacts[0].normal.y * 100, 0 ));

    }
}
