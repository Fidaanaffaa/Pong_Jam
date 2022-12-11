using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall1Up : MonoBehaviour
{
    private float _distanceFromAreaCenter = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SetBallPosition(GameObject ball, float angle)
    {
        ball.transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * _distanceFromAreaCenter;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            GameObject player = col.gameObject.GetComponent<Bowl>().GetLastPlayerTouched();
            if (player != null)
            {
                col.gameObject.GetComponent<Bowl>().boostSpeed = 0;
                col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                SetBallPosition(col.gameObject, player.GetComponent<PlayerMovement>().GetAngle());
                col.transform.SetParent(player.transform.GetChild(0).transform, true);
                col.GetComponent<Bowl>().SetHittingModeTrue();

                Destroy(gameObject);   // should be destroyed on null also??????????
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
