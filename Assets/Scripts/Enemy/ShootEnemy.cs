using UnityEngine;

public class ShootEnemy : Enemy
{

    [SerializeField] private float _distanceToPlayer;
    [SerializeField] private LayerMask _isPlayer;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _borderObject;
    [SerializeField] private float _timeBetweenAttack = 1.5f;
    private bool _canAttack = false;

    private void Start()
    {
        _health = 300;
    }

    private void Update()
    {
        PlayerCheck();
    }
    private void ResetAttack() => _canAttack = false;
    private void PlayerCheck()
    {
        try
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.left, _distanceToPlayer, _isPlayer);
            if (hitinfo.transform.GetComponent<Player>() != null)
            {
                if (!_canAttack)
                {
                    _canAttack = true;
                    Attack();
                    Invoke(nameof(ResetAttack), _timeBetweenAttack);
                }
            }
        }
        catch (System.Exception)
        {

        }

    }

    public override void Death()
    {
        base.Death();
        Instantiate(_key, transform.position, Quaternion.identity);
        Destroy(_borderObject);
    }

    private void Attack()
    {
        Instantiate(_bullet, _targetPoint.transform.position, Quaternion.Euler(new Vector3(0f, 0f, 180)));
    }
}
