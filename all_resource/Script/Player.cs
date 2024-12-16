using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveForce = 10f;
    [SerializeField] private float _jumpForce = 11f;
    private InputAction _jumpAction;

    private float _movementX;

    private Rigidbody2D _myBody;

    private SpriteRenderer _sr;

    private Animator _anim;
    private string _walkAnimation = "Walk";

    private string _enemyTag = "Enemy";

    private bool _isGround = true;

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerMoveKeyboard();
        Vanish();
        
    }
    private void FixedUpdate()
    {
       //PlayerJump();
       JumpUsingInputSystem();
    }

    private void PlayerMoveKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        

        transform.position += new Vector3(_movementX, 0f, 0f) * _moveForce * Time.deltaTime;
        AnimatePlayer();
    }
    private void AnimatePlayer()
    {
        if (_movementX > 0f)
        {
            _anim.SetBool(_walkAnimation, true);
            _sr.flipX = false;
        }
        else if (_movementX < 0f)
        {
            _anim.SetBool(_walkAnimation, true);
            _sr.flipX = true;  
        }
        else
        {
            _anim.SetBool(_walkAnimation, false);
        }
    }
    //private void PlayerJump()
    //{
    //    if (Input.GetButtonDown("Jump") && _isGround)
    //    {
    //        _isGround = false;
    //        _myBody.AddForce(new Vector2(0f,_jumpForce),ForceMode2D.Impulse);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }

        if (collision.gameObject.CompareTag(_enemyTag))
        {
            Destroy(gameObject);
        }

    }
    private void JumpUsingInputSystem()
    {
        _jumpAction = InputSystem.actions.FindAction("jump");
        if(_jumpAction.IsPressed() && _isGround)
        {
            _myBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _isGround=false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_enemyTag))
        {
            Destroy(gameObject);
        }
    }
    private void Vanish()
    {
        if(transform.position.x<-61 || transform.position.x > 62)
        {
            Destroy(gameObject);
        }
    }
}
