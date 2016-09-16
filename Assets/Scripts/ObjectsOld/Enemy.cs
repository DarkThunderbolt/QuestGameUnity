using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int health;
	// Use this for initialization
	void Start ()
    {
        health = 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(health<=0)
        {
            Destroy(gameObject);
        }
	}


    public void GetHit(int damage)
    {
        health -= damage;
    }
}
