using UnityEngine;
using System.Collections;

public class LootScript : MonoBehaviour {

    public bool showChest = false;

	// Use this for initialization
	void Start () {


        if (gameObject.name == "Treasure_Chest_Gold")
        {
            iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, -10f, 0), "time", 3f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (showChest)
        {
            
            iTween.MoveAdd(GameObject.Find("StoneSlabCover"), iTween.Hash("amount", new Vector3(3f, 0, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.RotateAdd(GameObject.Find("StoneSlabCover"), iTween.Hash("y", -45f, "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 0.25f));
            iTween.MoveAdd(GameObject.Find("StoneSlabCover"), iTween.Hash("amount", new Vector3(0, 0, 0.5f), "time", 0.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 0.75f));
            

            iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, 10f, 0), "time", 3f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            showChest = false;
        }
	}
}
