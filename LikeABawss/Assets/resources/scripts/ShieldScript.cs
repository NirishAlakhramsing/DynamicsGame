using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.RotateAdd(gameObject, iTween.Hash("y", 360f, "time", 5f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
