using UnityEngine;
using System.Collections;

public class CrumbleDownStoneScript : MonoBehaviour {

    public GameObject crumbleObject;
    public GameObject BossCrumbleObject;

    public Transform transformObj;

	// Use this for initialization
	void Start () {
        transformObj = gameObject.GetComponent<Transform>();
        transformObj.position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateCrumble()
    {
        if(gameObject.name == "Mirror")
        {
            for (int i = 0; i < 10; i++)
            {
                var commonCrumble = Instantiate(crumbleObject, new Vector3(transformObj.position.x, transformObj.position.y + 5f, transformObj.position.z), transform.rotation) as GameObject;
                commonCrumble.name = "CommonCrumble";
            }
        }

        if (gameObject.name == "WallCollider")
        {
            for (int i = 0; i < 10; i++)
            {
                var commonCrumble = Instantiate(crumbleObject, new Vector3(transformObj.position.x, transformObj.position.y, transformObj.position.z), transform.rotation) as GameObject;
                commonCrumble.name = "CommonCrumble";
            }
        }

        if (gameObject.name == "Boss")
        {
            for (int i = 0; i < 10; i++)
            {
                var bossCrumble = Instantiate(BossCrumbleObject, new Vector3(transformObj.position.x, transformObj.position.y + 5f, transformObj.position.z), transform.rotation) as GameObject;
                bossCrumble.name = "BossCrumble";
            }
        }

        if (gameObject.name == "MiniBossOne" || gameObject.name == "MiniBossTwo")
        {
            for (int i = 0; i < 1; i++)
            {
                var bossCrumble = Instantiate(BossCrumbleObject, new Vector3(transformObj.position.x, transformObj.position.y + 3f, transformObj.position.z), transform.rotation) as GameObject;
                bossCrumble.name = "BossCrumble";
            }
        }

    }

}
