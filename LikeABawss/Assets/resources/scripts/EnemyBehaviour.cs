using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public int enemyHp;
    public int MiniBossHp, MiniBoss2Hp;

    public bool playerAlive, hasShield;
    public ProjectileHit prjHitScript;
    public GameObject firstPowerUp;

    // Use this for initialization
    void Start () {

        playerAlive = true;

        if ( gameObject.name == "MiniBossTwo")
        {
            iTween.MoveAdd(GameObject.Find("MiniBossTwo"), iTween.Hash("amount", new Vector3(0, 0.5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
            hasShield = true;
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
	void Update ()
    {

        //TriggerDeath
        if (MiniBossHp == 0)
        {
            //spawn sphere ability
            Instantiate(firstPowerUp, transform.position, transform.rotation);

            //Miniboss dies
            Destroy(GameObject.Find("MiniBossOne"));
        }

        
        if (!hasShield)
        {
            //Trigger Death
            if (MiniBoss2Hp <= 0)
            {
                //spawn sphere ability
                Instantiate(firstPowerUp, transform.position, transform.rotation);

                //Miniboss dies
                Destroy(GameObject.Find("MiniBossTwo"));
            }
        }

    }


    //If player is in range - fire at player
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            prjHitScript.inRange = true;
        }

        if (col.gameObject.tag == "Projectile")
        {
            prjHitScript.inRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            prjHitScript.inRange = false;
        }
    }

}
