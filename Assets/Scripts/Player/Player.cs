using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamage
{
    public event Action<int> coinsAction;
    public event Action deathAction;
    public static Player Singleton { get; set; }
    public float _health;

    [SerializeField] private GameObject _playerDeathParticle;
    [SerializeField] private AudioSource _playerLoseSound;

    public int _score;
    public string _name;
    public Weapon _weapon;
    public int _weaponAmmo = 0;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _weaponAmmo = _weapon.AmountAmmo;
        _health = 100f;
    }

    private void Update()
    {
        PositionCheck();
    }

    public void Attack(float angle) => _weapon.Shoot(angle);
    public void GetDamage(float damage)
    {
        _health -= damage;
        deathAction?.Invoke();
        _playerLoseSound.Play();
        if (_health <= 0)
        {
            Death();
        }
    }
    public void TakeCoins()
    {
        _score++;
        coinsAction?.Invoke(_score);
    }

    //перевірка позиції персонажа і якщо вона менше -5, то персонаж гине
    private void PositionCheck()
    {
        if(transform.position.y < -5)
        {
            Death();
        }
    }
    private void Death()
    {
        
        Instantiate(_playerDeathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    //Для взаємодії з іншими обєктами на сцені, які будуть по-різному реагувать
    //на зіткнення з персонажем

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IInteractable>() != null)
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }
    }
}
