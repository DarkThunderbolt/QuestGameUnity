using UnityEngine;
using System.Collections;
using Assets;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public Transform groundPoint1;
    public Transform groundPoint2;
    public LayerMask groundMask;

    private EdgeCollider2D _attackZone;

    private bool _facingRight = true;
    private bool _isGrounded = false;
    private float _groundDist;
    private bool _attackMelee = false;
    private bool _jumped = false;
    private bool _attackRagnes= false;
    int extraJump;
    int originExtraJumps = 1;

    private Rigidbody2D _body;
    private Animator _anim;

    private HudManager _hud;

    public void Start()
    {
        _hud = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HudManager>();
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _attackZone = GetComponent<EdgeCollider2D>();
        _groundDist = Vector2.Distance(groundPoint1.position, groundPoint2.position);
        extraJump = originExtraJumps;
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {
        HandleMovement();
        HandleAttack();
        if (extraJump < 1 && _isGrounded)
        {
            extraJump = originExtraJumps;
        }

        ResetValues();
    }

    private void IsGrounded()
    {
        if(_body.velocity.y!=0)
        {
            if (Physics2D.Raycast(groundPoint1.position, groundPoint2.position, _groundDist, groundMask) == true)
            {
                _isGrounded = true;
            }
            else
            {
                _isGrounded = false;
            }
            _anim.SetBool("isGrounded", _isGrounded);
        }
       
    }

    private void Run()
    {
        if(!_anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal") * 50, _body.velocity.y);
            _body.velocity = move;

            //Rotate left\rigth
            if (_body.velocity.x > 0 && !_facingRight)
                Flip();
            else if (_body.velocity.x < 0 && _facingRight)
                Flip();
            _anim.SetFloat("Speed", Mathf.Abs(_body.velocity.x));
            _anim.SetFloat("vSpeed", _body.velocity.y);
        }
    }

    private void Jump()
    {
        _body.velocity = new Vector2(_body.velocity.x, 0f);
        _body.AddForce(new Vector2(0, 100));
        extraJump--;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void HandleMovement()
    {
        Run();
        if(_jumped && !_anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && extraJump>0)
        {
            Jump();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && extraJump != 0)
        {
            _jumped = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _attackMelee = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _attackRagnes = true;
        }
    }

    private void HandleAttack()
    {
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            if (_attackMelee)
            {
                if (_isGrounded)
                {
                    _anim.SetTrigger("MeleeTrigger");
                    _body.velocity = Vector2.zero;
                }
                else
                {
                    _anim.SetTrigger("MeleeJumpTrigger");
                }
            }
            else if (_attackRagnes)
            {
                if (_isGrounded)
                {
                    _anim.SetTrigger("RangeTrigger");
                    _body.velocity = Vector2.zero;
                }
                else
                {
                    _anim.SetTrigger("RangeJumpTrigger");
                }
            }
        }
        
    }

    public void RangeAttack()
    {
        GetComponent<Weapon>().Shoot();
    }


    public void MeleeAttack()
    {
        transform.Find("AttackTrigger").GetComponent<AttackTrigger>().Change();
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundPoint1.position, groundPoint2.position);
    }

    private void ResetValues()
    {
        _attackMelee = false;
        _jumped = false;
        _attackRagnes = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collecteble" )
        {
            Destroy(other.gameObject);
        }
    }

}
