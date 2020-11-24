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


    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveX = _speed * Input.GetAxis("Horizontal");
        _direction = new Vector2(_moveX, 0.0f);


        if (CheckGround() && Input.GetKeyDown(KeyCode.W))
        {
            Jumping();
        }

        Moving(_direction);
    }

    private void Jumping()
    {
        _playerRigidbody.velocity = Vector2.up * _jumpSpeed;
    }
    private void Moving(Vector2 _direction)
    {
        transform.Translate(_direction * Time.deltaTime);
    }

    private bool CheckGround()
    {
        RaycastHit2D _raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, _platformsLayerMask);
        return _raycastHit2D.collider != null;
    }

}
