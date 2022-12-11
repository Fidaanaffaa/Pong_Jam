using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeOf1UP : MonoBehaviour
{
    public const float LifeTime = 15;
    private float _remaningTime;
    private const float _movingSpeed = 18;
    private Collider2D _collider2D;
    
    
    private void MoveToCenterOfScreen()
    {
        transform.position += _movingSpeed * Time.deltaTime * Vector3.down;
        if (transform.position[1] <= 0)
        {
            transform.position = Vector3.zero;
            _collider2D.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        transform.position = Vector3.up * 24; 
        GetComponent<Collider2D>().enabled = false; 
        _remaningTime = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_remaningTime >= 0)
        {
            _remaningTime -= Time.deltaTime;
        }

        else
        {
            Destroy(gameObject);
        }

        if (transform.position[1] > 0)
        {
            MoveToCenterOfScreen();
        }
    }
}
