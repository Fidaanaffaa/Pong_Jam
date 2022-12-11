using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpManager : MonoBehaviour
{
    
    public int LifeTime;
    private int interval = 5;

    private string[] _oneUps = new[] { "Enlarge", "GoalEnlarge","GrabBall", "GrabBall", "GoalShrinker",
        "GrabBall", "Shrinker", "Slow_down", "Speed_up"};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int GetRandom1UP()
    {
        return Random.Range(0, _oneUps.Length);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
