using UnityEngine;

public class PatrolEnemy : Enemy
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _distance;
    [SerializeField] private bool _moveRight;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
    }

    // Update is called once per frame
    void Update()
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
}
