using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int player1 = 0;
    int player2 = 0;
    public Text player1Score;
    public Text player2Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Goal")
        {
            if (coll.collider.transform.position.x < 0)
            {
                player1 += 1;
                player1Score.text = "" + player1;                
            }
            else
            {
                player2 += 1;
                player2Score.text = "" + player2;
            }
        }
    }
}
