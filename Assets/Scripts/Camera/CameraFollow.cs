using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	public GameObject ToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (ToFollow.transform.position.x, ToFollow.transform.position.y, transform.position.z);

	}
}
