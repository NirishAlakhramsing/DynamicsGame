using UnityEngine;
using System.Collections;

public class MiniBoss : MonoBehaviour {

    public int miniBossHp;
    int fireRate;
    private bool inRange;

    public bool playerAlive;
    public Transform playerPos;
    public GameObject fireProjectileObj;
    public GameObject powerup;
    private Transform p_Transform;

    // Use this for initialization
    void Start () {
        miniBossHp = 3;
        playerAlive = true;
        inRange = false;
        fireRate = 0;

        //Projectile instantiation direction settings
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        this.p_Transform = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {

        //always look at player
        transform.LookAt(playerPos);

        if (inRange)
        {
            fireRate++;
            if (fireRate == 90)
            {
                Attack();
                fireRate = 0;
            }
        }

        if (miniBossHp <= 0)
        {
            Instantiate(powerup, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        //instantiate projectile
        Instantiate(fireProjectileObj, p_Transform.position + new Vector3(0, 1f, 0), p_Transform.rotation);
    }
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
