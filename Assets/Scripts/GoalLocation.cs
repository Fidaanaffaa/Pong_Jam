using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoalLocation : MonoBehaviour
{
    // Start is called before the first frame update
    public GoalSide Side;
    private float _scaleForPadding;
    private float _safetyParameter = 1.6f;
    private float _paddingAngle;
    private int _scaleIndex = 1;
    public float Radius;
    private float _startAngle = Mathf.PI / 2;
    private float _finishAngle = Mathf.PI * 3 / 2;
    private float _fullCircle;
    private float _circle;
    private float _insideArena = 0.95f;
    private float _angleOfPosition;   // TODO SET IN COMPOMEMTS
    private GameObject _lastPlayerTouched = null;
    private int _maxScale = 25;
    private int _minScale = 2;
    private int _delicateDistrabution = 1000000000;

    public void SetNewScale(float parameter)
    {
        if (parameter > 0 & _maxScale > transform.localScale[_scaleIndex])
        {
            transform.localScale += Vector3.up * parameter;
        }

        if (parameter < 0 & _minScale < transform.localScale[_scaleIndex])
        {
            transform.localScale += Vector3.up * parameter;
        }
    }
    
    public GameObject GetLastPlayerTouched()
    {
        return _lastPlayerTouched;
    }
    void Start()
    {
        AdjustPaddingAngle();
        if (Side == GoalSide.Right)
        {
            _startAngle *= 3;
            _finishAngle = _finishAngle * 5 / 3;
        }
        float angle = _startAngle + _paddingAngle;
        float xPos = Radius * _insideArena * Mathf.Cos(angle);
        float yPos = Radius * _insideArena * Mathf.Sin(angle);
        transform.position = new Vector3(xPos, yPos, 0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle);
    }

    private void AdjustPaddingAngle()
    {
        _scaleForPadding = transform.localScale[_scaleIndex] / 2 + _safetyParameter;
        _paddingAngle = _scaleForPadding / Radius;
    }
    
    public enum GoalSide
    {
        Left,
        Right
    }

    void DrawRandomPosition()
    {
        AdjustPaddingAngle();
        float ang = Random.Range((_startAngle + _paddingAngle)/_delicateDistrabution, (_finishAngle - _paddingAngle)/_delicateDistrabution) * _delicateDistrabution;
        float xPos = Radius * _insideArena * Mathf.Cos(ang);
        float yPos = Radius * _insideArena * Mathf.Sin(ang);
        transform.position = new Vector3(xPos, yPos, 0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * ang);
    }
    
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Collider2D>().CompareTag("ball"))
        {
            DrawRandomPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
