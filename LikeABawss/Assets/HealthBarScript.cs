using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

    public int health;
    GameObject getUIObj;

    // Use this for initialization
    void Start () {
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0f, "time", 10f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        getUIObj = GameObject.Find("HealthBarGUI");

	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }

    public void RemoveHearth()
    {
        switch (health)
        {
            case 3:
            // fade out first heart
                break;
            case 2:
                // fade out second heart
                break;
            case 1:
                //fade out last heart
                break;
            default:
                // player dies
                break;
        }
    }
}
