using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 100;
    EdgeCollider2D edge;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("GetHit", dmg);
        }
    }

    public void Change()
    {
        edge.enabled = !edge.enabled;
    }


	// Use this for initialization
	void Start ()
    {
        edge = GetComponent<EdgeCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}