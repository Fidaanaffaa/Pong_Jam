using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
 // Reference point, center of circle, should be the center of the arena (the position of the camera) 
    public Transform rotationCenter;
    private Vector3 _rotationPosition;

    public Collider2D playerBounds;
    
    // The initial angle of the object, can be changed if needed
    public float initialAngle = 0;

    // The speed of the movement
    public float angularSpeed;
    
    // The Radius of the movement 
    public float rotationRadius;
    
    // Whether the player is in the left side (-1) or the eight side (1)
    private int _orientation;

    private float _posX, _posY, _angle = 0;
    private const float AngleLimit = 2.0f * Mathf.PI;
    private List<List<bool>> _keyDisabled = new List<List<bool>>() {new List<bool>(){ false, false},new List<bool>() { false, false } };

    public enum PlayerSide
    {
        Left,
        Right
    }

    // The side of the screen of the player, either left or right
    public PlayerSide side;
    
    private readonly Dictionary<PlayerSide, int> _sideToOrientation = 
        new Dictionary<PlayerSide, int>() {{ PlayerSide.Right, 1}, { PlayerSide.Left, -1}};
    
    // Start is called before the first frame update
    void Start()
    {
        _rotationPosition = rotationCenter.position;
        _orientation = _sideToOrientation[side];
        _angle += -((float)_orientation - 1) / 4 * AngleLimit;
        _posX = rotationRadius * _orientation;
        _posY = 0;
        transform.position = new Vector3(_posX, _posY, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerBounds)
        {
            _keyDisabled[(_orientation-1)/-2][(int)(Mathf.Sign(_posY)-1)/-2] = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerBounds)
        {
            _keyDisabled[(_orientation - 1) / -2][(int)(Mathf.Sign(_posY) - 1) / -2] = false;
        }
    }
    
    private void UpdateAngle(int direction)
    {
        _angle = (_angle + Time.deltaTime * angularSpeed * direction * _orientation + AngleLimit) % AngleLimit;
    }

    private void Move()
    {
        _posX = _rotationPosition[0] + Mathf.Cos(_angle) * rotationRadius;
        _posY = _rotationPosition[1] + Mathf.Sin(_angle) * rotationRadius;
        transform.position = new Vector3(_posX, _posY, 0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * _angle + initialAngle);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow) & side == PlayerSide.Right & !_keyDisabled[0][0])
        {
            UpdateAngle(1);
            Move();
        }

        if (Input.GetKey(KeyCode.DownArrow)& side == PlayerSide.Right & !_keyDisabled[0][1])  
        {  
            UpdateAngle(-1);
            Move();
        }
        
        if (Input.GetKey(KeyCode.W) & side == PlayerSide.Left & !_keyDisabled[1][0])
        {
            UpdateAngle(1);
            Move();
        } 
        
        if (Input.GetKey(KeyCode.S)& side == PlayerSide.Left & !_keyDisabled[1][1])  
        {  
            UpdateAngle(-1);
            Move();
        }
    }
}
