using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedMove;

    [SerializeField] private bool _canMove;
    [SerializeField] private bool _canRotate;

    private Vector3 _startPosition;
    void Update()
    {
        Rotate(_speedRotate);
        _startPosition = transform.position;
        if(_canMove)
        {
            Move();
        }
    }

    private void Move()
    {
     
    }
    private void Rotate(float speed)
    {
        if(_canRotate)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
