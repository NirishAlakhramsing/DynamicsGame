using UnityEngine;
using System.Collections;

public class TreeFallOver : MonoBehaviour {

    Collider other;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "RightHandCollisionBox")
        {
            Debug.Log("tip over tree");
        }
    }
    
}
