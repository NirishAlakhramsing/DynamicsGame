using UnityEngine;
using System.Collections;

public class BossShootingScript : MonoBehaviour {

    public bool mayShoot, inRange;
    public int fireRate;

    private Transform p_Transform;

    public GameObject fireProjectileObj;
    public GameObject fireboxObj;

    // Use this for initialization
    void Start () {
        mayShoot = false;
        this.p_Transform = fireboxObj.transform;
    }
	
	// Update is called once per frame
	void Update () {
	if (mayShoot)
        {
            //send fire balls at player
            if (inRange)
            {
                fireRate++;
                if (fireRate == 90)
                {
                    Fire();
                    fireRate = 0;
                }
            }
        }
	}

    public void Fire()
    {
        var fireProjectile = Instantiate(fireProjectileObj, p_Transform.position, p_Transform.rotation) as GameObject;
        fireProjectile.name = "fireProjectile(Clone)";
    }

    //If player is in range - fire at player
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
