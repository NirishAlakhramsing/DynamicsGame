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

    void OnTriggerEnter(Collider col)
    {
        iTween.PunchScale(GameObject.Find("MiniBossTwo"), iTween.Hash("amount", new Vector3(0.25f, 0.50f, 0.25f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col, 1.5f);
        }

    }
}
