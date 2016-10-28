using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{

    public float speed, lifeTime;
    private Vector3 forward;
    HealthBarScript hpScript;
    RPGCharacterControllerFREE animScript;

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
    }

    void OnTriggerEnter(Collider col)
    {
        //Attach key to player back
        if (col.gameObject.tag == "Player")
        {
            hpScript = col.GetComponentInChildren<HealthBarScript>();
            animScript = col.GetComponentInChildren<RPGCharacterControllerFREE>();

            //remove heart from player
            hpScript.health--;
            hpScript.RemoveHearth();

            //play hit animation
            animScript.GetHit();

            //play sound

            //destroy gameobject
            Destroy(gameObject);

        }
    }
}
