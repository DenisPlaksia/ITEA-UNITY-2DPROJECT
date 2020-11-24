using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    public delegate void CoinAction(int _coinCount);
    public event CoinAction coinsAction;
    public static Player Singleton { get; private set; }
    public float Health { get; private set; }

    private int _score;

    private void Awake()
    {
        Singleton = this;
    }
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
