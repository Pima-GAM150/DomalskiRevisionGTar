using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SerpentineBulletMovement : MonoBehaviour{
    
	public float xdir, ydir, speed, variation, timer, varSpeed = 1f;
	public Vector2 perp, dir;

	void Start(){

		//get perpendicular vector
		perp = new Vector2(1f, ((-1f * xdir)/ ydir)).Normalize();

		//get unit vector of direction
		dir = new Vector2(xdir, ydir).Normalize();

	}

	void Update(){

		//this kind of came to me as I was at work and I'm trying to understand my scrawls
		//so I'm commenting as I type to understand what the hell I'm making here

		// create a magnitude for the bullet to deviate from the path
		float temp = (float)Math.Sin(timer) * variation; 

		//as I understand it at this point I'm using perp and dir as my own axes
		//I'm using dir as a constant line of movement, and perp as the axis of
		//variation, if I multiply perp by temp and then add it to dir multiplied by
		//speed, I should hopefully get the effect I'm looking for?

		transform.Translate((perp * temp) + (dir * speed));

		timer += Time.deltaTime * varSpeed;

		if(timer > 2 * Math.PI)
			timer = 0f;

	}
    
}
