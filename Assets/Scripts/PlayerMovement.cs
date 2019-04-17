using UnityEngine;

using System.Collections;



public class PlayerMovement : MonoBehaviour {


	public float moveSpeed, invulTimer, invulMax, bulletCDTimer, bulletCD;
    public GameObject bullet;
	public int lives;
	public bool wasDamaged;

	
	void Update(){


		if (Input.GetKey (KeyCode.D) && transform.position.x < 8.8f)
			transform.Translate (new Vector2 (1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.A) && transform.position.x > -8.8f)
			transform.Translate (new Vector2 (-1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.S) && transform.position.y > -4.8f)
			transform.Translate (new Vector2 (0, -1) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.W) && transform.position.y < 4.8f)
			transform.Translate (new Vector2 (0, 1) * moveSpeed * Time.deltaTime);

		if(wasDamaged){

			invulTimer += Time.deltaTime;

			if(invulTimer >= invulMax){

				wasDamaged = false;

			}

		}

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {

            Instantiate(bullet, transform);
        
        }
        else if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) { 
        
            if(bulletCDTimer >= bulletCD) {

                Instantiate(bullet, transform);
                bulletCDTimer = 0;

            }
            else {

                bulletCDTimer += Time.deltaTime;
                

            }

        }
        else {

            bulletCDTimer = 0;
        
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
