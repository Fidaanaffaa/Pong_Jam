using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLocation : MonoBehaviour
{
    // Start is called before the first frame update
    private float _scaleForPadding;
    private float _safetyParameter = 0.5f;
    private float _paddingAngle;
    private int _scaleIndex = 1;
    public float Radius;
    private float _fullCircle;
    private float _circle;
    void Start()
    {
        _scaleForPadding = transform.localScale[_scaleIndex] / 2 + _safetyParameter;
        _paddingAngle = _scaleForPadding / Radius;
        _circle = 
    }

    // Update is called once per frame
    void Update()
    {
        Random.Range()
        
    }
}
