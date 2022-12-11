using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player1Up : MonoBehaviour
{
    public TypeOfTrigger type;
    public float resizingParameter = 2;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Collider2D>().CompareTag("ball"))
        {
            GameObject player = col.gameObject.GetComponent<Bowl>().GetLastPlayerTouched();
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().SetNewScale(resizingParameter);
                col.gameObject.GetComponent<Bowl>().SetLastPlayerToNull();
                Destroy(gameObject); // should be destroyed on null also??????????
            }
        }
    }

    public enum TypeOfTrigger
    {
        Shrinker,
        Enlarger
    }

    // Start is called before the first frame update
    void Start()
    {
        resizingParameter = (type == TypeOfTrigger.Shrinker) ? -resizingParameter : resizingParameter;
    }
}
