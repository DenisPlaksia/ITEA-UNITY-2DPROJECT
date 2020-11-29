using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamage
{
    protected float _health;
    [SerializeField] protected float _speed;
    [SerializeField] private GameObject _enemyDeathParticle;

    public void GetDamage(float _damage)
    {
        _health -= _damage;
        if(_health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Instantiate(_enemyDeathParticle, transform.position, Quaternion.identity);
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
