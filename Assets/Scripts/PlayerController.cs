using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private float _jumpSpeed = 0.0f;
    private float _moveX = 0.0f;
    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _playerRigidbody;
    private bool _canJump = true;

    private void Start()
    {
        _canJump = true;
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _moveX = _speed * Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _playerRigidbody.velocity = Vector2.up * _jumpSpeed;
            _canJump = false;
        }

        _direction = new Vector2(_moveX, 0.0f);

        Moving(_direction);
    }

    private void Moving(Vector2 _direction)
    {
        transform.Translate(_direction * Time.deltaTime);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _canJump = true;
        }
    }
}
