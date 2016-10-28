using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

    public float speed, lifeTime;
    private Vector3 forward;

	// Use this for initialization
	void Start () {
        forward = transform.forward;

        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += forward * speed * Time.deltaTime;
	}

}
