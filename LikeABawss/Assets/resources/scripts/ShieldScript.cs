using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

    public int shieldHP;
    public EnemyBehaviour enemyBossScript;
    public ProjectileHit enemyScript;
    public GameObject yellowExplosion;
    public GameObject redExplosion;

    // Use this for initialization
    void Start () {

        enemyScript = gameObject.GetComponentInParent<ProjectileHit>();

        if (transform.parent.name == "Boss")
        {
            iTween.RotateAdd(gameObject, iTween.Hash("y", 360f, "time", 5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
        }

        if (transform.parent.name == "MiniBossTwo")
        {
            iTween.RotateAdd(gameObject, iTween.Hash("y", 360f, "time", 5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
        }

        if (transform.parent.name == "NormalShieldEnemy")
        {
            iTween.MoveAdd(gameObject, iTween.Hash("y", 0.5f, "time", 2.5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.name == "ShieldRotationField")
        {
            if (shieldHP <= 0)
            {
                iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(1.5f, -1f, 0f), "time", 0.25f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                iTween.RotateAdd(gameObject, iTween.Hash("z", -90f, "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                Instantiate(yellowExplosion, transform.position, transform.rotation);
                enemyScript.hasShield = false;
                Destroy(gameObject, 1.25f);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        //iTween.PunchScale(GameObject.Find("MiniBossTwo"), iTween.Hash("amount", new Vector3(0.25f, 0.50f, 0.25f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        //Incoming hit on shield of small shield enemy
        if (col.gameObject.tag == "Projectile" && col.gameObject.name == "explosiveProjectile(Clone)" && gameObject.name == "Position1")
        {
            iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(1.5f, -1f, 0f), "time", 0.25f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.RotateAdd(gameObject, iTween.Hash("z",-90f, "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            Instantiate(yellowExplosion, transform.position, transform.rotation);
            enemyScript.hasShield = false;
            Destroy(col.gameObject);
            Destroy(gameObject, 1.25f); 
        }

        //Incoming red projectile hit on shield for MinibossTwo
        if (col.gameObject.tag == "Projectile" && col.gameObject.name == "fireProjectile(Clone)" && gameObject.name == "ShieldRotationField")
        {
            Destroy(col.gameObject);
            //iTween.PunchScale(GameObject.Find("ShieldRotationField"), iTween.Hash("amount", new Vector3(0.05f, 0.15f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.RotateAdd(gameObject, iTween.Hash("y", 360f, "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.RotateAdd(gameObject, iTween.Hash("y", 360f, "time", 5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 1f));
            Instantiate(redExplosion, transform.position, transform.rotation);
            shieldHP--;
            
            
        } else if (col.gameObject.tag == "Projectile" && col.gameObject.name == "explosiveProjectile(Clone)" && gameObject.name == "ShieldRotationField" && transform.parent.name != "Boss")
        {
            iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(1.5f, -1f, 0f), "time", 0.25f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.RotateAdd(gameObject, iTween.Hash("z", -90f, "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            Instantiate(yellowExplosion, transform.position, transform.rotation);
            enemyScript.hasShield = false;
            Destroy(col.gameObject);
            Destroy(gameObject, 1.25f);
        }



        ////shield go's down
        //if (shieldHP <= 0)
        //{
        //    enemyBossScript.hasShield = false;
        //    Destroy(gameObject);
        //}

        //iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(1.5f, -1f, 0f), "time", 0.25f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        

    }
}
