using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    public delegate void CoinAction(int _coinCount);
    public event CoinAction coinsAction;
    [SerializeField] private Weapun _weapun;
    public static Player Singleton { get; private set; }
    public float Health { get; private set; }

    private int _score;

    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {

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
    public void TakeCoins()
    {
        _score++;
        coinsAction?.Invoke(_score);
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
