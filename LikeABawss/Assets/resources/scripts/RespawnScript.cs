using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

    public RPGCharacterControllerFREE playerScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("RPG-Character").GetComponent<RPGCharacterControllerFREE>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //Attach key to player back
        if (col.gameObject.tag == "Player")
        {
            playerScript.startRevive();
        }

    }
}
