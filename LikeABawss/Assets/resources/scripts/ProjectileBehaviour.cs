using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{

    public float speed, lifeTime, selfdestuctTime;
    private Vector3 forward;
    HealthBarScript hpScript;
    RPGCharacterControllerFREE animScript;
    public EnemyBehaviour enemyScript;
    private bool bounced;

    // Use this for initialization
    void Start()
    {

        forward = transform.forward;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += forward * speed * Time.deltaTime;

        //kill object after certain amount of time
        StartCoroutine(Selfdestruct());
    }

    void OnTriggerEnter(Collider col)
    {
        //Attach key to player back
        if (col.gameObject.tag == "Player")
        {
            hpScript = col.GetComponentInChildren<HealthBarScript>();
            animScript = col.GetComponentInChildren<RPGCharacterControllerFREE>();

            //remove heart from player
            if (hpScript.health >= 0)
            {
                hpScript.RemoveHearth(hpScript.health);
                hpScript.health--;
            }
            

            //play hit animation
            animScript.GetHit();

            //play sound

            //stop firing new projectiles if health is lower than 0
            if (hpScript.health > 0)
            {
                enemyScript.playerAlive = false;
                Destroy(gameObject);
                
            }

            //destroy gameobject
            
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Obstacle")
        {
            if (col.name == "Mirror")
            {
                gameObject.transform.Rotate(new Vector3(180f, 0, 0));
                speed = speed * -1;
                bounced = true;
            } else
            {
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "EnemyT1")
        {

                Destroy(gameObject);
        }

    }

    IEnumerator Selfdestruct()
    {
        yield return new WaitForSeconds(selfdestuctTime);

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
