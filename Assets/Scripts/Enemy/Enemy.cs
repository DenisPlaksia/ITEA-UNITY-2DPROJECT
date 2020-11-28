using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _distance;
    [SerializeField] private bool _moveRight;
   

    private void Start()
    {
        _health = 100f;
    }

    private void Update()
    {
        PatorlGround();
    }
    private void PatorlGround()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundCheck.position, Vector2.down, _distance);
        if (groundInfo.collider == false)
        {
            if (_moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moveRight = true;
            }
        }
    }

    

    public void GetDamage(float _damage)
    {
        _health -= _damage;
        if(_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().GetDamage(100f);
        }
    }
}
