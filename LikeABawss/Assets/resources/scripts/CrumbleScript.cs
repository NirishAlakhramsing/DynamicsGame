using UnityEngine;
using System.Collections;

public class CrumbleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (gameObject.name == "CommonCrumble")
        Destroy(gameObject, 5f);

        if (gameObject.name == "BossCrumble")
            Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
