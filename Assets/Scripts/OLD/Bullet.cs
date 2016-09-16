using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int dmg = 100;
    CircleCollider2D edge;
    Animator anim;
    Rigidbody2D body2D;

    // Use this for initialization
    void Start ()
    {
        edge = GetComponent<CircleCollider2D>();
        body2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
    void Awake()
    {
        Destroy(gameObject, 4f);
    }
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("GetHit", dmg);
            anim.SetBool("Alive", false);
            Destroy(gameObject, 1f);
            body2D.velocity = new Vector2(0,0);
            //body2D.velocity.x = 0;
            //body2D.velocity.y = 0;
            body2D.gravityScale = 0;
        }
        else
            Destroy(gameObject, 3f);
    }
}
