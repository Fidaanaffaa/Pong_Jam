using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal1Up : MonoBehaviour
{
    public TypeOfTrigger type;
    public float resizingParameter = 2;
    public enum TypeOfTrigger
    {
        Shrinker,
        Enlarger
    }
    
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
                GameObject goal = (type == TypeOfTrigger.Shrinker) ? player.GetComponent<PlayerMovement>().MyGoal : player.GetComponent<PlayerMovement>().RivalGoal;
                goal.GetComponent<GoalLocation>().SetNewScale(resizingParameter);
                col.gameObject.GetComponent<Bowl>().SetLastPlayerToNull();
                Destroy(gameObject);   // should be destroyed on null also??????????
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resizingParameter = (type == TypeOfTrigger.Shrinker) ? -resizingParameter : resizingParameter;
    }
}
