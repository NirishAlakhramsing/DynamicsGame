using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

    public int shieldHP;
    public EnemyBehaviour enemyBossScript;
    public ProjectileHit enemyScript;
    public GameObject yellowExplosion;

	// Use this for initialization
	void Start () {

        enemyScript = gameObject.GetComponentInParent<ProjectileHit>();

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
	
	}

    void OnTriggerEnter(Collider col)
    {
        iTween.PunchScale(GameObject.Find("MiniBossTwo"), iTween.Hash("amount", new Vector3(0.25f, 0.50f, 0.25f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        //Incoming hit on shield
        if (col.gameObject.tag == "Projectile" && col.gameObject.name == "explosiveProjectile(Clone)")
        {
            Debug.Log("destroying incoming projectile");
            Debug.Log("The object that needs to be destroy is " + col.name);
            iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(1.5f, -1f, 0f), "time", 0.25f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.RotateAdd(gameObject, iTween.Hash("z",-90f, "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            Instantiate(yellowExplosion, transform.position, transform.rotation);
            enemyScript.hasShield = false;
            Destroy(col.gameObject);
            Destroy(gameObject, 1.25f);
            shieldHP--;
        }


        ////shield go's down
        //if (shieldHP <= 0)
        //{
        //    enemyBossScript.hasShield = false;
        //    Destroy(gameObject);
        //}

    }
}
