using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string Speed = "Speed";
    private const string IsGrounded= "IsGrounded";


    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerRenderer;
    [SerializeField] private Transform _groundCheck;

    [SerializeField] private LayerMask _ground;

    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _checkRadius = 0.5f;
    
    private void Start()
    {

    }

    private void Update()
    {
        _playerRenderer.flipX = false;
        _playerAnimator.SetFloat(Speed, 0);
        _playerAnimator.SetBool(IsGrounded, _isGrounded);

        GroundChecker();

        if (Input.GetKey(KeyCode.D))
        {
            _playerAnimator.SetFloat(Speed, _speed);
            _playerTransform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerRenderer.flipX = true;
            _playerAnimator.SetFloat(Speed, _speed);
            _playerTransform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }

        
    }

    private void GroundChecker()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
    }
}
