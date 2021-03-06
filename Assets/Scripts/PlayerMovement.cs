﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;



public class PlayerMovement : MonoBehaviour {


	public float moveSpeed, invulTimer, invulMax, bulletCDTimer, bulletCD, flashTimer;
	public SpriteRenderer self;
	public Text lifeText;
    public GameObject bullet;
	public int lives;
	public bool wasDamaged;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f), playerColor; 
	AudioSource playerAudio;
	public AudioSource shootAudio;

    void Start(){

    	playerAudio = GetComponent<AudioSource>();
    	self.color = playerColor;

    }
	
	void Update(){

		lifeText.text = "lives: " + lives;

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

		if(wasDamaged && flashTimer > 0.11f){

			flashTimer = 0f;
			if(self.color == playerColor)
				self.color = flashColour;
			else
				self.color = playerColor;

		}
		else if(!wasDamaged){


			self.color = playerColor;

		}

		flashTimer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {

            GameObject tempo = Instantiate(bullet, transform);
            tempo.transform.parent = null;
            shootAudio.Play();
        
        }
        else if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) { 
        
            if(bulletCDTimer >= bulletCD) {

               GameObject tempo = Instantiate(bullet, transform);
                tempo.transform.parent = null;
                bulletCDTimer = 0;
                shootAudio.Play();

            }
            else {

                bulletCDTimer += Time.deltaTime;
                

            }

        }
        else {

            bulletCDTimer = 0;
        
        }




    }

	void GameOver(){SceneManager.LoadScene(0);}

	void OnCollisionEnter2D(Collision2D collision){

		if(collision.gameObject.tag.Equals("Bullet") && !wasDamaged){
            Debug.Log(collision.gameObject.name);
			lives--;
			if(lives < 0){

				GameOver();

			}

			playerAudio.Play();
			wasDamaged = true;
			invulTimer = 0;

		}


	}


}
