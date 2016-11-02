using UnityEngine;
using System.Collections;

public class ActivatePowerup : MonoBehaviour {

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
        
        if (col.gameObject.tag == "Player")
        {
            
            if (gameObject.tag == "PowerUp")
            {

                iTween.PunchScale(GameObject.Find("PowerUpOne"), iTween.Hash("amount", new Vector3(0.5f, 0.1f, 0.5f), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                iTween.MoveAdd(GameObject.Find("PowerUpOne"), iTween.Hash("amount", new Vector3(0, 2f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                
                // activate ability one for player
                playerScript.abilityOne = true;
                Debug.Log(playerScript.abilityOne);
                //show UI for ability one useage

                //OpenDoor

                //Destroy PowerUpObject
                Destroy(gameObject, 0.5f);
            }

        }
    }
}
