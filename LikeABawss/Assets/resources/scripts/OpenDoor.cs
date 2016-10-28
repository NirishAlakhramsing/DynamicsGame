using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {

        //Attach key to door
        if (col.gameObject.tag == "Player")
        {

            //Animate door to open
            iTween.MoveAdd(GameObject.Find("FirstEnemyDoor"), iTween.Hash("amount", new Vector3(0, -6, 0), "time", 2.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

            Destroy(gameObject);
        }
    }
}
