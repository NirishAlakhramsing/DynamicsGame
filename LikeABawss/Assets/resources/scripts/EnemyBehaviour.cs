using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    int enemyHp = 0;
    int fireRate;
    private bool inRange;
    public bool canRaycast;

    public bool playerAlive;
    public Transform playerPos;
    public GameObject fireProjectileObj;
    RaycastHit hit;

    private Transform p_Transform;

	// Use this for initialization
	void Start () {
        playerAlive = true;
        canRaycast = false;
        inRange= false;
        fireRate = 0;

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        //Projectile instantiation direction settings
        this.p_Transform = gameObject.transform;

        //Animation floating
        iTween.MoveAdd(GameObject.Find("EnemyOne"), iTween.Hash("amount", new Vector3(0, 0.5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));

        if ( gameObject.name == "EnemyOne")
        {
            enemyHp = 1;
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

        // check if enemy should be dead
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }

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

    void FixedUpdate()
    {
        /*
        Debug.Log("canRaycast is " + canRaycast);

        
        //look if enemy should fire
        if (canRaycast && Physics.Raycast(transform.position, playerPos.transform.localPosition, out hit, 5.0f))
        {
            Debug.DrawLine(transform.position, playerPos.transform.localPosition, Color.red);
            //print("Player in range to be attacked");
            StartCoroutine(enemyOneFiring());
            //enemyOneFiringV();
        }
        */


    }

    /*
    IEnumerator enemyOneFiring()
    {

        canRaycast = false;

        //wait for next firing
        yield return new WaitForSeconds(3);

        //instantiate projectile
        Instantiate(fireProjectileObj, p_Transform.position, p_Transform.rotation);
        Debug.Log("shot a fireball");
        canRaycast = true;

    }
    */

    public void enemyOneFiringV()
    {
        //instantiate projectile
        Instantiate(fireProjectileObj, p_Transform.position, p_Transform.rotation);
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //canRaycast = true;
            inRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canRaycast = false;
            inRange = false;
        }
    }

    //recieving damage
    public void gotHit()
    {
        enemyHp--;

        if (enemyHp == 0)
        {
            Destroy(gameObject);
        }
    }
}
