using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider), typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMouseController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    private Vector2 destinationPosition;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private Vector2 lastPosition;
    private bool isMoving = false;
    private bool facingRight = true;
    private float direction;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        destinationPosition = lastPosition = rigidBody.position;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {               
            if (Vector2.Distance(destinationPosition, rigidBody.position) > .1f     // Check if payer come to destination point
                && Vector2.Distance(lastPosition,rigidBody.position)> .05f)         // Check for stop by obstacle
            {
                
                direction = destinationPosition.x - rigidBody.position.x;           // Rotate left\rigth
                if (direction > 0 && !facingRight)
                    Flip();
                else if (direction < 0 && facingRight)
                    Flip();
                
                lastPosition = rigidBody.position;                                  // For check if player stoped by obstacle

                animator.SetFloat("xSpeed", 1.0f);
                rigidBody.MovePosition(Vector3.MoveTowards(rigidBody.position,       // Move
                    destinationPosition, MoveSpeed * Time.deltaTime));
            }
            else
            {
                isMoving = false;
                animator.SetFloat("xSpeed", 0);
                destinationPosition = rigidBody.position;
            }
        }
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    MoveToPoint(mousePosition);
        //}
    }

    public void MoveToPoint(Transform destination)
    {
        destinationPosition = destination.position;
        destinationPosition.y = rigidBody.transform.position.y;
        lastPosition = destinationPosition;
        isMoving = true;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
