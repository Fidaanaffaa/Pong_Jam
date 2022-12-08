using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalElarge : MonoBehaviour
{
    public const float LifeTime = 10000000;
    private float _remaningTime;
    public GameObject Enlarger;

    
    // Update is called once per frame
    void Update()
    {
        if (_remaningTime >= 0)
        {
            _remaningTime -= Time.deltaTime;
        }

        else
        {
            Destroy(Enlarger);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Collider2D>().CompareTag("ball"))
        {
            GameObject player = col.gameObject.GetComponent<Bowl>().GetLastPlayerTouched();
            if (player != null)
            {
                GameObject myGoal = player.GetComponent<PlayerMovement>().MyGoal;
                myGoal.GetComponent<GoalLocation>().SetNewScale(1);
                col.gameObject.GetComponent<Bowl>().SetLastPlayerToNull();
            }
            Destroy(Enlarger);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        _remaningTime = LifeTime;
    }
}
