﻿using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    int enemyHp = 0;
    bool canFire = false;
    public Transform playerPos;
    public GameObject fireProjectileObj;

    private Transform p_Transform;

	// Use this for initialization
	void Start () {

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
	
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }

        transform.LookAt(playerPos);

        //look if enemy should fire
        //if ((gameObject.transform.position.x - playerPos.transform.position.x) < 0.01 && !canFire)
        if (canFire)
        {
            StartCoroutine(enemyOneFiring());
        }
    }

    //recieving damage
    public void gotHit()
    {
        enemyHp--;
    }


    IEnumerator enemyOneFiring()
    {

        //instantiate projectile
        Instantiate(fireProjectileObj, p_Transform.position, p_Transform.rotation);
        canFire = false;

        //wait for next firing
        yield return new WaitForSeconds(3);
        canFire = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canFire = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canFire = false;
        }
    }
}
