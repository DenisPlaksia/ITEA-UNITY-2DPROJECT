using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour, IDamage
{
    private float _health;
    [SerializeField] private Weapon _weapon;
    private float _distanceToPlayer;
    [SerializeField] private float _radius;
    private void Start()
    {
        _health = 100f;
        SetDistance();
    }

    private void Update()
    {
        if(_distanceToPlayer < _radius)
        {
            Attack();
        }
    }

    private void SetDistance() => _distanceToPlayer = Vector3.Distance(Player.Singleton.transform.position, transform.position);
    private void Attack()
    {
        _weapon.Shoot(0);
    }
    public void GetDamage(float _damage)
    {
        _health -= _damage;
        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
