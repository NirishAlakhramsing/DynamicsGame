using UnityEngine;
using System.Collections;

public class CollideWithItem : MonoBehaviour {

    Vector3 playerBackPos;
    GameObject getPlayerObj;

    // Use this for initialization
    void Start () {
        playerBackPos = GameObject.Find("PlayerBack").transform.position;
        getPlayerObj = GameObject.Find("PlayerBack");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //Attach key to player back
        if (col.gameObject.tag == "Player")
        {
            // add key to player backside
            gameObject.transform.parent = getPlayerObj.transform;

            gameObject.transform.localPosition = getPlayerObj.transform.localPosition;
            iTween.Stop(gameObject);

        }

        //Attach key to door
        if (col.gameObject.tag == "Door")
        {
            // add key to player backside
            gameObject.transform.parent = col.transform;

            //place key on door
            gameObject.transform.localPosition = col.transform.position;

            //destroy key
            Destroy(gameObject);
        }
    }
}
