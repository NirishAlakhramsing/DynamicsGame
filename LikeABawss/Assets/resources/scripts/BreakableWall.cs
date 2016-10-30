using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

    Collider other;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (other == GameObject.Find("fireProjectile"))
        {
            Destroy(gameObject);
        }

	}


}
