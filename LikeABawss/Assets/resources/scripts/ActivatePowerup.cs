using UnityEngine;
using System.Collections;

public class ActivatePowerup : MonoBehaviour {

    public RPGCharacterControllerFREE playerScript;
    private UIManager uiManagerScript;
    private OpenDoor door;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("RPG-Character").GetComponent<RPGCharacterControllerFREE>();
        door = GameObject.Find("CloseDoorFirstEnemy").GetComponent<OpenDoor>();
        uiManagerScript = GameObject.Find("UI manager").GetComponent<UIManager>();

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

                iTween.PunchScale(GameObject.Find("PowerUpOne"), iTween.Hash("amount", new Vector3(0.5f, 0.1f, 0.5f), "time", 2f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                iTween.MoveAdd(GameObject.Find("PowerUpOne"), iTween.Hash("amount", new Vector3(0, 2f, 0), "time", 2f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                
                //activate ability one for player
                playerScript.abilityOne = true;
                //show UI for ability one useage
                iTween.FadeTo(GameObject.Find("MouseRightButton"), iTween.Hash("alpha", 1f, "time", 1.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                //OpenDoor
                iTween.MoveAdd(GameObject.Find("FirstEnemyDoor"), iTween.Hash("amount", new Vector3(0, door.stepsizeEnemyDoor1, 0), "time", 2.5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                door.stepsizeEnemyDoor1 = 1 * -door.stepsizeEnemyDoor1;

                //Give text feedback
                uiManagerScript.StartCoroutine(uiManagerScript.RenderText(3));

                //Destroy PowerUpObject
                Destroy(gameObject, 0.5f);
            }

            if (gameObject.tag == "PowerUpTwo")
            {

                iTween.PunchScale(gameObject, iTween.Hash("amount", new Vector3(0.5f, 0.1f, 0.5f), "time", 2f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, 2f, 0), "time", 2f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

                // activate ability two for player
                playerScript.abilityTwo = true;
                //show UI for ability one useage
                iTween.FadeTo(GameObject.Find("MouseLeftButton"), iTween.Hash("alpha", 1f, "time", 1.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

                //Give text feedback
                uiManagerScript.StartCoroutine(uiManagerScript.RenderText(6));

                //Destroy PowerUpObject
                Destroy(gameObject, 0.5f);
            }

        }
    }
}
