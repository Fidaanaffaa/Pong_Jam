using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpeedUp : MonoBehaviour
{
    public BoostOrSlow speederOrSlower;
    public float ballSpeedUpRatio = 2;
    public float playersSpeedUpRatio = 1.4f;
    
    
    // Start is called before the first frame update
    public enum BoostOrSlow
    {
        Boost,
        Slow
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().CompareTag("ball"))
        {
            var players = GameObject.FindGameObjectsWithTag("Player");

            foreach (var player in players)
            {
                player.GetComponent<PlayerMovement>().angularSpeed *= playersSpeedUpRatio;
            }

            col.GetComponent<Bowl>().boostSpeed = ballSpeedUpRatio;
        }
        Destroy(gameObject);
    }

    void Start()
    {
        ballSpeedUpRatio = (speederOrSlower == BoostOrSlow.Boost) ? ballSpeedUpRatio : 1 / ballSpeedUpRatio;
        playersSpeedUpRatio = (speederOrSlower == BoostOrSlow.Boost) ? playersSpeedUpRatio : 1 / playersSpeedUpRatio;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
