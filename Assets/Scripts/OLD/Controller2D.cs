using UnityEngine;
using System.Collections;
/// <summary>
/// !!!OLD!!!
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Controller2D : MonoBehaviour {

    public LayerMask groundMask;
    public Transform groundPoint;

    private float _radius = 0.05f;
    private int _originExtraJumps = 1;
    private int _extraJump;
    private int jumpHight = 250;
    private bool _isGrounded;
    private bool _facingRight = true;

    private Animator _anim;
    private Rigidbody2D _body;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    public void Move(float moveSpeed)
    {
        Vector2 moveX = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _body.velocity.y);
        _body.velocity = moveX;
        if (_body.velocity.x > 0 && !_facingRight)
            Flip();
        else if (_body.velocity.x < 0 && _facingRight)
            Flip();
        _anim.SetFloat("Speed", Mathf.Abs(_body.velocity.x));
        _anim.SetFloat("vSpeed", _body.velocity.y);
        _isGrounded = Physics2D.OverlapCircle(groundPoint.position, _radius, groundMask);
        _anim.SetBool("isGrounded", _isGrounded);
    }

    public void Jump(Vector2 velocity)
    {
        _body.AddForce(new Vector2(0, jumpHight));
    }


    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundPoint.position, _radius);
    }



}