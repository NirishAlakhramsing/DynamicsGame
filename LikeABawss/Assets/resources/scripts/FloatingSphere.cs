using UnityEngine;
using System.Collections;

public class FloatingSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, 0.5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
    }
	
}
