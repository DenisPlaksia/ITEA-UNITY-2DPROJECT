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
        if(Input.GetMouseButtonDown(0))
        {
            Atack();
        }
    }
    public void Atack() => _weapun.Shoot();

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
