using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

    Collider other;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
