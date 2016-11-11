using UnityEngine;
using System.Collections;

public class CrumbleDownStoneScript : MonoBehaviour {

    public GameObject crumbleObject;

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
                Instantiate(crumbleObject, new Vector3(transformObj.position.x, transformObj.position.y + 5f, transformObj.position.z), transform.rotation);
            }
        }

        if (gameObject.name == "WallCollider")
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(crumbleObject, new Vector3(transformObj.position.x, transformObj.position.y, transformObj.position.z), transform.rotation);
            }
        }
    }

}
