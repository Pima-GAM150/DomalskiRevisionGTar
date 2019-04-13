using UnityEngine;

using System.Collections;



public class PlayerMovement : MonoBehaviour {


	public float moveSpeed;
	
	void Update(){


		if (Input.GetKey (KeyCode.D) && transform.position.x < 9f)
			transform.Translate (new Vector2 (1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.A) && transform.position.x > -9f)
			transform.Translate (new Vector2 (-1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.S) && transform.position.y > -5f)
			transform.Translate (new Vector2 (0, -1) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.W) && transform.position.y < 5f)
			transform.Translate (new Vector2 (0, 1) * moveSpeed * Time.deltaTime);
	
	}


}
