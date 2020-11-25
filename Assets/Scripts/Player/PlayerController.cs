using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private float _jumpSpeed = 0.0f;
    [SerializeField] private LayerMask _platformsLayerMask;
    private Rigidbody2D _playerRigidbody;
    private BoxCollider2D _boxCollider2D;
    private float _moveX = 0.0f;
    private Vector2 _direction = Vector2.zero;
    private float _angle;
    private bool facingRight = true;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveX = _speed * Input.GetAxis("Horizontal");

        MovingCheck();
        Attacing();
        _direction = new Vector2(_moveX, 0.0f);

        if (CheckGround() && Input.GetKeyDown(KeyCode.W))
        {
            Jumping();
        }


        Moving(_direction);
    }

    private void Attacing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Player.Singleton.Atack(_angle);
        }
    }

    private void MovingCheck()
    {
        if (_moveX != 0.0f)
        {
            TimeController.RunTime();
        }
        else
        {
            TimeController.StopTime();
        }
    }

    private void Jumping()
    {
        _playerRigidbody.velocity = Vector2.up * _jumpSpeed;
    }
    private void Moving(Vector2 _direction)
    {
        if(_moveX > 0f && facingRight == false)
        {
            _angle = 0f;
            Flip();
        }
        else if(_moveX < 0f && facingRight == true)
        {
            _angle = 180f;
            Flip();
        }
        transform.Translate(_direction * Time.deltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private bool CheckGround()
    {
        RaycastHit2D _raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, _platformsLayerMask);
        return _raycastHit2D.collider != null;
    }
}
