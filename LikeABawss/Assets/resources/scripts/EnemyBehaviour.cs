using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public int enemyHp;
    public int MiniBossHp;

    public bool playerAlive;
    public ProjectileHit prjHitScript;

	// Use this for initialization
	void Start () {
        playerAlive = true;

        if ( gameObject.name == "MiniBossOne")
        {
            
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


    }


    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
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
