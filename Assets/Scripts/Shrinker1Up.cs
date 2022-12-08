using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shrinker1Up : MonoBehaviour
{
    public const float LifeTime = 100;
    private float _remaningTime;
    public GameObject Shrinker;

    
    // Update is called once per frame
    void Update()
    {
        if (_remaningTime >= 0)
        {
            _remaningTime -= Time.deltaTime;
        }
        else
        {
            Destroy(Shrinker);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Collider2D>().CompareTag("ball"))
        {
            GameObject player = col.gameObject.GetComponent<Bowl>().GetLastPlayerTouched();
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().SetNewScale(-1);
                col.gameObject.GetComponent<Bowl>().SetLastPlayerToNull();
            }
            Destroy(Shrinker);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        _remaningTime = LifeTime;
    }
}
