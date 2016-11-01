using UnityEngine;
using System.Collections;

public class BackPack : MonoBehaviour {

    public string[] items;
    public bool hasKey;

	// Use this for initialization
	void Start () {
        hasKey = false;
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
    }
}
