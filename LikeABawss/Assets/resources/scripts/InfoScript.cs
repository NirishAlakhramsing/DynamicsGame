using UnityEngine;
using System.Collections;

public class InfoScript : MonoBehaviour {

     UIManager uiManagerScript;
        public BossScript bossScript;

	// Use this for initialization
	void Start () {
        uiManagerScript = GameObject.Find("UI manager").GetComponent<UIManager>();
        bossScript = GameObject.Find("Boss").GetComponent<BossScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player" && gameObject.name == "InfoTriggerRotateCam")
        {
            iTween.FadeTo(GameObject.Find("ControlsCamera"), iTween.Hash("alpha", 1f, "time", 1.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        if (col.gameObject.tag == "Player" && gameObject.name == "InfoTriggerFollowCam")
        {
            iTween.FadeTo(GameObject.Find("ControlsCamera2"), iTween.Hash("alpha", 1f, "time", 1.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        //Fade out all on screen control info 
        if (col.gameObject.tag == "Player" && gameObject.name == "RemoveInfo")
        {
            iTween.FadeTo(GameObject.Find("Controls"), iTween.Hash("alpha", 0f, "time", 5.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.FadeTo(GameObject.Find("ControlsCamera"), iTween.Hash("alpha", 0f, "time", 5.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.FadeTo(GameObject.Find("ControlsCamera2"), iTween.Hash("alpha", 0f, "time", 5.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            Destroy(gameObject);
        }


        if (col.gameObject.tag == "Player" && gameObject.name == "InfoTriggerFirstMinibossMeeting")
        {
            uiManagerScript.StartCoroutine(uiManagerScript.RenderText(1));
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && gameObject.name == "InfoTriggerBossMeeting")
        {
            uiManagerScript.StartCoroutine(uiManagerScript.RenderText(4));
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && gameObject.name == "InfoTriggerKeyDoor1")
        {
            uiManagerScript.StartCoroutine(uiManagerScript.RenderText(2));
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && gameObject.name == "StartBossFight")
        {
            bossScript.goToNextPhase = true;
            Destroy(gameObject);
        }

    }
}
