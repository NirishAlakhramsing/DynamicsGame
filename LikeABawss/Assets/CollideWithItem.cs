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
        if (col.gameObject.tag == "Player")
        {
            // add key to player backside
            gameObject.transform.parent = getPlayerObj.transform;

            gameObject.transform.localPosition = getPlayerObj.transform.localPosition;
            iTween.Stop(gameObject);

        }
    }
}
