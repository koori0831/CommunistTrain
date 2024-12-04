using System;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    private float _distance = 1f;
    [SerializeField]
    private Transform _turningCenter;
    [SerializeField]
    private float _turningSpeed;

    private Vector3 _centerPoint;
    private float _hight;
    private float _currentAngle;
    private void Start()
    {
        _distance = (new Vector2(_turningCenter.position.x,_turningCenter.position.z) - new Vector2(transform.position.x, transform.position.z)).magnitude;
        _centerPoint = _turningCenter.position;
        _hight = transform.position.y;
    }

    private void Update()
    {
        if(_currentAngle > 360)
        {
            _currentAngle = 0;
        }
    }

    private void FixedUpdate()
    {
        _currentAngle += _turningSpeed;
        CircleTracingMove();
        print(_currentAngle);
    }

    private void CircleTracingMove()
    {
        float xPos = MathF.Cos(_currentAngle * Mathf.Deg2Rad) * _distance;
        float zPos = MathF.Sin(_currentAngle * Mathf.Deg2Rad) * _distance;
        Vector3 targetPos =  new Vector3 (xPos, _hight, zPos) ;

        transform.position = targetPos + _centerPoint;
        transform.rotation = Quaternion.Euler(0,-_currentAngle,0);
    }
}
