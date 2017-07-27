using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EffectorPlacer : Pieka {

	public float EffectorTTLInSeconds = 1;
	public GameObject StraightEffector;
	

	private float effectorLife;

	private GameObject currentEffector;

	public void PlaceEffector(LineInfo lineInfo, List<Vector2> points)
	{

		float x = points.Average (e => e.x);
		float y = points.Average (e => e.y);

		currentEffector = Instantiate (StraightEffector, new Vector3 (x, y, 0), Quaternion.Euler (new Vector3 (0, 0, lineInfo.angle)));

		effectorLife = Time.time;
	}


	protected override void OnUpdate()
	{
		print ("OnUpdate");
		if ( Time.time - effectorLife >= EffectorTTLInSeconds)
		{
			Destroy (currentEffector);
		}
	}

}
