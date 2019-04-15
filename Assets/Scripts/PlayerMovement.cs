using UnityEngine;

using System.Collections;



public class PlayerMovement : MonoBehaviour {


	public float moveSpeed, invulTimer, invulMax;
	public int lives;
	public bool wasDamaged;

	
	void Update(){


		if (Input.GetKey (KeyCode.D) && transform.position.x < 9f)
			transform.Translate (new Vector2 (1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.A) && transform.position.x > -9f)
			transform.Translate (new Vector2 (-1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.S) && transform.position.y > -5f)
			transform.Translate (new Vector2 (0, -1) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.W) && transform.position.y < 5f)
			transform.Translate (new Vector2 (0, 1) * moveSpeed * Time.deltaTime);

		if(wasDamaged){

			invulTimer += Time.deltaTime;

			if(invulTimer >= invulMax){

				wasDamaged = false;

			}

		}
	
	}

	void GameOver(){}

	void OnCollisionEnter2D(Collision2D collision){

		if(collision.gameObject.tag.Equals("Bullet") && !wasDamaged){

			lives--;
			if(lives < 0){

				GameOver();

			}

			wasDamaged = true;
			invulTimer = 0;

		}


	}


}
