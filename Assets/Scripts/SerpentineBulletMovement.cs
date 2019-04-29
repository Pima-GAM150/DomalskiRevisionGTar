using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SerpentineBulletMovement : MonoBehaviour{
    
	public float xdir, ydir, speed, variation, timer, varSpeed = 1f;
	public Vector2 perp, dir;

	void Start(){

		//get perpendicular vector
		perp = new Vector2(1f, ((-1f * xdir)/ ydir));
		perp.Normalize();
		//Debug.Log(perp);

		//get unit vector of direction
		dir = new Vector2(xdir, ydir);
		dir.Normalize();
		//Debug.Log(dir);

	}

	void Update(){

		//Debug.Log(perp);
		//this kind of came to me as I was at work and I'm trying to understand my scrawls
		//so I'm commenting as I type to understand what the hell I'm making here

		// create a magnitude for the bullet to deviate from the path
		float temp = (float)Math.Sin(timer) * variation / 5f; 

		//as I understand it at this point I'm using perp and dir as my own axes
		//I'm using dir as a constant line of movement, and perp as the axis of
		//variation, if I multiply perp by temp and then add it to dir multiplied by
		//speed, I should hopefully get the effect I'm looking for?

		Vector2 tempV = (perp * temp) + (dir * speed / 10f);

		Vector3 mov = new Vector3(tempV.x, tempV.y, 0f);

		transform.Translate(mov);

		timer += Time.deltaTime * varSpeed;

		if(timer > 2 * Math.PI)
			timer = 0f;

		if(transform.position.x > 11 || transform.position.x < -11 || transform.position.y > 8 || transform.position.y < -8)
			Destroy(gameObject);
	}
    
}
