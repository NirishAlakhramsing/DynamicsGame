using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public int enemyHp = 0;
    public int MiniBossHp;
    int fireRate;
    private bool inRange;

    public bool playerAlive;
    public Transform playerPos;
    public GameObject fireProjectileObj;
    public GameObject powerup;

    private Transform p_Transform;

	// Use this for initialization
	void Start () {
        playerAlive = true;
        inRange= false;
        fireRate = 0;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        //Projectile instantiation direction settings
        this.p_Transform = gameObject.transform;

        if ( gameObject.name == "MiniBossOne")
        {
            MiniBossHp = 3;
            //Animation floating
            iTween.MoveAdd(GameObject.Find("MiniBossOne"), iTween.Hash("amount", new Vector3(0, 0.5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
        }

        if ( gameObject.name == "EnemyTwo")
        {
            enemyHp = 2;
        }

        if (gameObject.name == "Boss")
        {
            enemyHp = 3;
        }
        

	}
	
	// Update is called once per frame
	void Update () {

        //always look at player
        transform.LookAt(playerPos);

        if (inRange)
        {
            fireRate++;
            if (fireRate == 90 )
            {
                enemyOneFiringV();
                fireRate = 0;
            }
        }
    }


    public void enemyOneFiringV()
    {
        //instantiate projectile
        Instantiate(fireProjectileObj, p_Transform.position + new Vector3(0, 1f,0), p_Transform.rotation);
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

    //recieving damage
    public void gotHit()
    {
        Debug.Log(MiniBossHp);

        if (MiniBossHp < 0 && (gameObject.name == "MiniBossOne"))
        {
            Instantiate(powerup, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
