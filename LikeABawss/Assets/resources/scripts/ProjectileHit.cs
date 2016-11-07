using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

    public EnemyBehaviour enemyScript;
    public Transform playerPos;
    private Transform p_Transform;
    public GameObject fireProjectileObj;
    public GameObject explosiveProjectileObj;
    public GameObject fireboxObj;

    private int enemyID;

    int fireRate;
    public bool inRange;

    // Use this for initialization
    void Start () {
        //fireboxObj = GameObject.Find("FireBox");

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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            //MiniBoss one collision
            if (gameObject.name == "MiniBossOne")
            {
                iTween.PunchScale(GameObject.Find("MiniBossOne"), iTween.Hash("amount", new Vector3(0.05f, 0.10f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                enemyScript.MiniBossHp--;
                Debug.Log("MiniBoss got hit");
            }

            //MiniBoss two collision
            if (gameObject.name == "MiniBossTwo" && col.gameObject.name == "fireProjectile(Clone)")
            {
                iTween.PunchScale(GameObject.Find("MiniBossTwo"), iTween.Hash("amount", new Vector3(0.25f, 0.50f, 0.25f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                enemyScript.MiniBoss2Hp--;
                Debug.Log("MiniBossTwo got hit");
            }
            else if (gameObject.name == "MiniBossTwo" && enemyScript.hasShield)
                {
                    Debug.Log("Break the shield first");
                }
            {
            }

            if (gameObject.name == "NormalEnemy" && col.gameObject.name == "fireProjectile(Clone)")
            {
                iTween.PunchScale(GameObject.Find("NormalEnemy"), iTween.Hash("amount", new Vector3(0.05f, 0.10f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                Destroy(gameObject, 0.5f);
                Debug.Log("Normal Enemy got hit");
            }

            if (gameObject.name == "NormalShieldEnemy" && col.gameObject.name == "fireProjectile(Clone)")
            {
                iTween.PunchScale(GameObject.Find("NormalShieldEnemy"), iTween.Hash("amount", new Vector3(0.05f, 0.10f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                Destroy(gameObject, 0.5f);
                Debug.Log("Shield Enemy got hit");
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
