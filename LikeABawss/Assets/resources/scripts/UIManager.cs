using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        iTween.FadeTo(GameObject.Find("GUI Camera"), iTween.Hash("alpha", 0f, "time", 20.0f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
