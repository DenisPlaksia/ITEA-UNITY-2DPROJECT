using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _canMove;
    [SerializeField] private bool _canRotate;
    private Vector3 _startPosition;
    void Update()
    {
        Rotate(_speed);
        _startPosition = transform.position;
    }

    private void Move(Vector3 to)
    {
        if(transform.position != to)
        {
            transform.Translate(to * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(_startPosition * _speed * Time.deltaTime);
        }

    }
    private void Rotate(float speed)
    {
        if(_canRotate)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
