using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject bullet;
    public float dmg = 50;
    public float bulletForse;
    public LayerMask notToHit;
    Transform firePoint;

    // Use this for initialization
    void Start ()
    {
        firePoint = transform.FindChild("ShootPoint");
    }
	


	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Shoot()
    {
        GameObject shoot = (GameObject)Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.position * bulletForse);
    }
}
