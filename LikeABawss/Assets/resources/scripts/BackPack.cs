using UnityEngine;
using System.Collections;

public class BackPack : MonoBehaviour {

    public string[] items;
    public bool hasKey, hasKey2;

	// Use this for initialization
	void Start () {
        hasKey = false;
        hasKey2 = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void AquireItem(string name)
    {
        if (name == "FirstKey")
        {
            hasKey = true;
        }

        if (name == "SecondKey")
        {
            hasKey2 = true;
        }
    }
}
