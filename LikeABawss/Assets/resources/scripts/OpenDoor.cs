using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    RPGCharacterControllerFREE playerscript;
    GameObject moveColliderBox;
    public BackPack backpackScript;
    private bool keyDoor1, EnemyDoor1;
    public float stepziseCollisionBox1, stepsizeEnemyDoor1, stepziseCollisionBoxKey1, stepsizeKeyDoor1;

    // Use this for initialization
    void Start () {
        EnemyDoor1 = true;
        keyDoor1 = false;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {

        //Attach key to door
        if (col.gameObject.tag == "Player")
        {
            //First enemy door
            if (gameObject.name == "CloseDoorFirstEnemy")
            {
                iTween.MoveAdd(moveColliderBox = GameObject.Find("CloseDoorFirstEnemy"), iTween.Hash("amount", new Vector3(0, 0, stepziseCollisionBox1), "time", 0.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                stepziseCollisionBox1 = 1 * -stepziseCollisionBox1;

                iTween.MoveAdd(GameObject.Find("FirstEnemyDoor"), iTween.Hash("amount", new Vector3(0, stepsizeEnemyDoor1, 0), "time", 2.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                stepsizeEnemyDoor1 = 1 * -stepsizeEnemyDoor1;
            }

            //First key and door that belongs to it.
            if (gameObject.name == "CollisionBoxKey1" && backpackScript.hasKey )
            {
                iTween.MoveAdd(moveColliderBox = GameObject.Find("CollisionBoxKey1"), iTween.Hash("amount", new Vector3(stepziseCollisionBoxKey1, 0, 0), "time", 0.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                stepziseCollisionBoxKey1 = 1 * -stepziseCollisionBoxKey1;

                iTween.MoveAdd(GameObject.Find("DoorKeyOne"), iTween.Hash("amount", new Vector3(0, stepsizeKeyDoor1, 0), "time", 2.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                stepsizeKeyDoor1 = 1 * -stepsizeKeyDoor1;
            } else
            {
                Debug.Log("YOU HAS NO KEYZZ");
            }
        }
    }
}
