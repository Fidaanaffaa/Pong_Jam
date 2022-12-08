using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoalLocation : MonoBehaviour
{
    // Start is called before the first frame update
    private float _scaleForPadding;
    private float _safetyParameter = 1.5f;
    private float _paddingAngle;
    private int _scaleIndex = 1;
    public float Radius;
    private float _startAngle = Mathf.PI / 2;
    private float _finishAngle = Mathf.PI * 3 / 2;
    private float _fullCircle;
    private float _circle;
    private float _insideArena = 0.9f;
    private float _angleOfPosition;
    void Start()
    {
        _scaleForPadding = transform.localScale[_scaleIndex] / 2 + _safetyParameter;
        _paddingAngle = _scaleForPadding / Radius;
        float angle = _startAngle + _paddingAngle;
        float xPos = Radius * _insideArena * Mathf.Cos(angle);
        float yPos = Radius * _insideArena * Mathf.Sin(angle);
        transform.position = new Vector3(xPos, yPos, 0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle);
    }

    void DrawRandomPosition()
    {
        float ang = Random.Range(_startAngle + _paddingAngle, _finishAngle - _paddingAngle);
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
        };
    }

    // Update is called once per frame
    void Update()
    {
    }
}
