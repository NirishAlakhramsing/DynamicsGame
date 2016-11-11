using UnityEngine;
using System.Collections;

public class StandSpotScript : MonoBehaviour {

    public bool inside = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (!inside)
        {
            inside = true;
        }

        if (col.gameObject.tag == "Player" && inside) ;
        {
            Debug.Log("turn off spot");
            gameObject.SetActive(false);
        }
    }
}
