using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

    public CrumbleDownStoneScript crumbeScript;
    public EnemyBehaviour enemyScript;
    public Transform playerPos;
    private Transform p_Transform;
    public GameObject fireProjectileObj;
    public GameObject explosiveProjectileObj;
    public GameObject fireboxObj;
    public GameObject yellowExplosion;
    public GameObject redExplosion;
    public GameObject secondPowerUp;
    public BossScript bossScript;

    public bool hasShield;

    private int enemyID;

    int fireRate;
    public bool inRange;

    // Use this for initialization
    void Start () {
        crumbeScript = gameObject.GetComponent<CrumbleDownStoneScript>();
        bossScript = GameObject.Find("Boss").GetComponent<BossScript>();

        if(gameObject.name == "NormalShieldEnemy")
        {
            hasShield = true;
        }

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if(gameObject.name == "NormalEnemy")
        {
            enemyID = gameObject.GetInstanceID();
        }

        
        //Projectile instantiation direction settings
        this.p_Transform = fireboxObj.transform;

        inRange = false;
        fireRate = 0;

        //Animation floating
        iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, 0.5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));

    }
	
	// Update is called once per frame
	void Update () {

        //always look at player
        transform.LookAt(playerPos);

        if(enemyScript.MiniBoss2Hp <= 0 && gameObject.name == "MiniBossTwo")
        {
            Destroy(gameObject);
            
            //spawn second ability pickup
            Instantiate(secondPowerUp, transform.position, transform.rotation);
        }

        //send fire balls at player
        if (inRange)
        {
            fireRate++;
            if (fireRate == 90)
            {
                enemyOneFiringV();
                fireRate = 0;
            }
        }
    }

    void FixedUpdate()
    {
        float maxDistance = 0.5f;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawLine(transform.position, fwd);

        if (Physics.Raycast(transform.position, fwd, maxDistance)) {
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            //MINIBOSS ONE
            //When miniboss gets hit by his own projectile
            if (gameObject.name == "MiniBossOne" && gameObject.tag == "EnemyT1" && col.gameObject.name == "fireProjectile(Clone)")
            {
                iTween.PunchScale(GameObject.Find("MiniBossOne"), iTween.Hash("amount", new Vector3(0.10f, 0.15f, 0.10f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                enemyScript.MiniBossHp--;
                crumbeScript.CreateCrumble();
                Instantiate(redExplosion, transform.position, transform.rotation);
                Destroy(col.gameObject);
            }

            //MNIBOSS TWO collision
            if (gameObject.name == "MiniBossTwo" && gameObject.tag == "EnemyT1" && col.gameObject.name == "fireProjectile(Clone)" && !hasShield)
            {
                iTween.PunchScale(GameObject.Find("MiniBossTwo"), iTween.Hash("amount", new Vector3(0.05f, 0.20f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                enemyScript.MiniBoss2Hp--;
                crumbeScript.CreateCrumble();
                Instantiate(redExplosion, transform.position, transform.rotation);
            }


            if (gameObject.name == "MiniBossTwo" && gameObject.tag == "EnemyT1" && col.gameObject.name == "explosiveProjectile(Clone)" && !hasShield)
            {
                Instantiate(yellowExplosion, transform.position, transform.rotation);
                Destroy(col.gameObject);
            }


            //NORMAL ENEMY
            if ( gameObject.tag == "EnemyT1" && gameObject.name == "NormalEnemy" && col.gameObject.name == "fireProjectile(Clone)")
            {
                iTween.PunchScale(GameObject.Find("NormalEnemy"), iTween.Hash("amount", new Vector3(0.05f, 0.10f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                Instantiate(redExplosion, transform.position, transform.rotation);
                bossScript.enemies--;
                Destroy(gameObject, 0.1f);
                Debug.Log("Normal Enemy got hit");
                
            }

            //SHIELD ENEMY
            //Normal shield enemy hit on explosive projectile
            if (gameObject.tag == "Shield" && gameObject.name == "NormalShieldEnemy" && col.gameObject.name == "explosiveProjectile(Clone)" && hasShield)
            {
                iTween.PunchScale(GameObject.Find("NormalShieldEnemy"), iTween.Hash("amount", new Vector3(0.05f, 0.10f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                Destroy(col);
                hasShield = false;
                Debug.Log("Shield Enemy got hit");
                //When hitting an ememy without a shield with the correct abillity
            } else if (!hasShield && gameObject.name == "NormalShieldEnemy" && col.gameObject.name == "fireProjectile(Clone)")
                {
                Instantiate(redExplosion, transform.position, transform.rotation);
                Destroy(col.gameObject);
                bossScript.enemies--;
                Destroy(gameObject);
                //When hitting an ememy without a shield with the wrong abillity
                } else if (!hasShield && gameObject.name == "NormalShieldEnemy" && col.gameObject.name == "explosiveProjectile(Clone)")
                    {
                    iTween.PunchScale(GameObject.Find("EnemyBodySE"), iTween.Hash("amount", new Vector3(0.05f, 0.10f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                    Instantiate(yellowExplosion, transform.position, transform.rotation);
                    Destroy(col.gameObject);
                    }
        }
    }

    public void enemyOneFiringV()
    {
        //instantiate projectile
        if (gameObject.name == "NormalEnemy")
        {
            Instantiate(fireProjectileObj, p_Transform.position, p_Transform.rotation);
        }

        if (gameObject.name == "MiniBossOne")
        {
            Instantiate(fireProjectileObj, p_Transform.position, p_Transform.rotation);
        }

        if (gameObject.name == "MiniBossTwo")
        {
            Instantiate(explosiveProjectileObj, p_Transform.position, p_Transform.rotation);
        }


        if (gameObject.name == "NormalShieldEnemy")
        {
            Instantiate(explosiveProjectileObj, p_Transform.position, p_Transform.rotation);
        }
    }
}
