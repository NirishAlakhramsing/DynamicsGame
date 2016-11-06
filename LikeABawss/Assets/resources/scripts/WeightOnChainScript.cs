using UnityEngine;
using System.Collections;

public class WeightOnChainScript : MonoBehaviour {

    public UIManager uiManagerScript;
    public GameObject firstBridge;

    // Use this for initialization
    void Start () {
        uiManagerScript = GameObject.Find("UI manager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {

            if(other.name == "explosiveProjectile(Clone)")
            {

                //Loosen chain and drop the weight
                if (gameObject.name == "StoneWeight2")
                {
                    iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, -30f, 0), "time", 2f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                    uiManagerScript.weightsDropped++;
                    DropBridge();
                }

                if (gameObject.name == "StoneWeight1")
                {
                    iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, -30f, 0), "time", 2f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                    uiManagerScript.weightsDropped++;
                    DropBridge();
                }
            }
        }
    }

    void DropBridge()
    {
        //check if other weight is dropped too
        if (uiManagerScript.weightsDropped == 2)
        {
            Debug.Log("Dropping Bridge");
            //if both weights are dropped than lower bridge next to it
            iTween.RotateAdd(GameObject.Find("BridgeMesh2"), iTween.Hash("amount", new Vector3(45, 0, 0), "time", 5.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        if (uiManagerScript.weightsDropped == 4)
        {
            Debug.Log("Dropping Bridge");
            //if both weights are dropped than lower bridge next to it
            iTween.RotateAdd(GameObject.Find("BridgeMesh3"), iTween.Hash("amount", new Vector3(45, 0, 0), "time", 5.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }


    }

}
