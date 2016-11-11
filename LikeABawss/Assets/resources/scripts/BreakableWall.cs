using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

    Collider other;
    public CrumbleDownStoneScript crumbleScript;
    public GameObject redExplosion;

    // Use this for initialization
    void Start () {
        crumbleScript = gameObject.GetComponentInChildren<CrumbleDownStoneScript>();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            //show effect on kill
            Instantiate(redExplosion, transform.position, transform.rotation);

            //Crumble the wall
            crumbleScript.CreateCrumble();

            
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
