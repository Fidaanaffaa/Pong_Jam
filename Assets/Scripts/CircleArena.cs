using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleArena : MonoBehaviour
{
    public EdgeCollider2D edgeCollider2D;
    List<Vector2> DrawCircle(int steps, float radius = 0.5f)
    {
        List<Vector2> lst = new List<Vector2>();
        
        
        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float x = Mathf.Cos(currentRadian) * radius;
            float y = Mathf.Sin(currentRadian) * radius;

            Vector2 currentPosition = new Vector2(x, y);
            lst.Add(currentPosition);
        } 
        lst.Add(new Vector2(radius, 0));
        return lst;
    }
    private void Awake()
    {
        edgeCollider2D.SetPoints(DrawCircle(20));
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
