using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] private GameObject _playerDeathParticle;

    public event Action<int> coinsAction;
    public event Action deathAction;
    public event Action winAction;
    public static Player Singleton { get; set; }
    public PlayerData _playerData;
    public Weapon _weapon;


    private void Awake() => Singleton = this;
    private void Start() => _playerData._health = 50f;
    private void Update() => PositionCheck();

    public void Attack(float angle) => _weapon.Shoot(angle);
    public void GetDamage(float damage)
    {
        _playerData._health -= damage;
        
        if (_playerData._health <= 0)
        {
            Death();
        }
    }
    public void WinGame() => winAction?.Invoke();
    public void TakeCoins(int score) => coinsAction?.Invoke(score);

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
        deathAction?.Invoke();
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


[Serializable]
public class PlayerData
{
    public float _health;
    public int _score;
    public string _name = " ";

    public void SetName(string name)
    {
        _name = name;
    }
}