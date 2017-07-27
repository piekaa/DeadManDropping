using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : Pieka {

	Vector3 position;
	Vector3 scale;
	Quaternion rotation;

	Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () 
	{
		position = transform.localPosition;
		scale = transform.localScale;
		rotation = transform.rotation;

		rigidbody2d = GetComponent<Rigidbody2D> (); 

	}



	[OnEvent(EventIDs.Game.Reset)]
	void OnReset()
	{
		print ("OnReset");

		transform.localPosition = position;
		transform.localScale = scale;
		transform.rotation = rotation;

		if (rigidbody2d != null)
		{

			rigidbody2d.velocity = Vector2.zero;
			rigidbody2d.angularVelocity = 0;
		}
	}


}
