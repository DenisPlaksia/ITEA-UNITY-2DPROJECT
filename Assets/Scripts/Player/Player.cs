using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamage
{
    public event Action<int> coinsAction;
    public Weapon _weapun;
    public static Player Singleton { get; private set; }
    public float Health { get; private set; }

    [SerializeField] private GameObject _playerDeathParticle;

    private int _score;

    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        PositionCheck();
    }

    public void Atack(float angle) => _weapun.Shoot(angle);
    public void GetDamage(float _damage)
    {
        Health -= _damage;

        if (Health <= 0)
        {
            Death();
        }
    }

    private void PositionCheck()
    {
        if(transform.position.y < -5)
        {
            Death();
        }
    }

    public void TakeCoins()
    {
        _score++;
        coinsAction?.Invoke(_score);
    }
    private void Death()
    {
        Instantiate(_playerDeathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<ITakeable>() != null)
        {
            collision.gameObject.GetComponent<ITakeable>().Take();
        }
    }
}
