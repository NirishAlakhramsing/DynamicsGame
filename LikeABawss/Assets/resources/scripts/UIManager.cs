using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    //track bridgeweights
    public int weightsDropped = 0;

	// Use this for initialization
	void Awake () {
        iTween.FadeTo(GameObject.Find("GUI Camera"), iTween.Hash("alpha", 0f, "time", 20.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        iTween.FadeTo(GameObject.Find("MouseRightButton"), iTween.Hash("alpha", 0f, "time", 0.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        iTween.FadeTo(GameObject.Find("MouseLeftButton"), iTween.Hash("alpha", 0f, "time", 0.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
