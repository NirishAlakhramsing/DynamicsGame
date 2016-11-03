using UnityEngine;
using System.Collections;

public class RotateItem : MonoBehaviour {

	// Use this for initialization
	void Start () {

            iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, 0, 1.0f), "time", 2.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
            iTween.RotateAdd(gameObject, iTween.Hash("amount", new Vector3(0, 0, 360.0f), "time", 5.0f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
