﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Guitarcade : MonoBehaviour {

	public Text label;
	public Guitarput input;
	public int maxHealth;
	public int currentHealth;
	//public BulletPatterns patternList;
	public float analysisWait;
	private float effectiveWait;
	public bool canFire;
    private int previousMIDI;
    public int winScene;



	void Start () {
		effectiveWait = analysisWait;
		currentHealth = maxHealth;
		//StartCoroutine(PatternController());
	
	}

	void Update(){

        int MIDI = input.FrequencyToMIDI(input.Analyze());

        if(!canFire && MIDI != previousMIDI && analysisWait > 0.16f) {

            canFire = true;

        }

        if (canFire){

				if (Input.GetKey (KeyCode.E))
					BulletPatterns.SplitterPattern1 ();

			int temp = MIDI % 12;
            previousMIDI = MIDI;
		

			switch (MIDI) {
			case 0:
				label.text = "" + MIDI + ": C";
					BulletPatterns.TargetedPattern3 ();
					effectiveWait = 0.6f;
					canFire = false;
				break;
			case 1:
				label.text = "" + MIDI + ": Db/C#";
				break;
			case 2:
				label.text = "" + MIDI + ": D";
					BulletPatterns.SplitterPattern1();
					effectiveWait = 1.2f;
					canFire = false;
				break;
			case 3:
				label.text = "" + MIDI + ": Eb/D#";
					BulletPatterns.CirclePattern1 ();
					effectiveWait = 0.6f;
					canFire = false;
				break;
			case 4:
				label.text = "" + MIDI + ": E";

				break;
			case 5:
				label.text = "" + MIDI + ": F";
					BulletPatterns.CirclePattern1 ();
					effectiveWait = 0.6f;
					canFire = false;
				break;
			case 6:
				label.text = "" + MIDI + ": Gb/F#";
				break;
			case 7:
				label.text = "" + MIDI + ": G";
					BulletPatterns.CirclePattern2 ();
					effectiveWait = 0.6f;
					canFire = false;
				break;
			case 8:
				label.text = "" + MIDI + ": Ab/G#";
					BulletPatterns.TargetedPattern1 ();
					effectiveWait = 0.3f;
					canFire = false;
				break;
			case 9:
				label.text = "" + MIDI + ": A";
				break;
			case 10:
				label.text = "" + MIDI + ": Bb/A#";
					BulletPatterns.TargetedPattern2 ();
					effectiveWait = 0.3f;
					canFire = false;
				break;
			case 11:
				label.text = "" + MIDI + ": B";
				break;

			default:
				label.text = "Unrecognized";
				break;

			}
		}
		else{

			analysisWait += Time.deltaTime;

			if(analysisWait >= effectiveWait){

				analysisWait = 0;
				canFire = true;

			}

		}


	}

	void OnCollisionEnter2D(Collision2D collision){


		if(collision.gameObject.tag.Equals("PlayerBullet")){


			currentHealth--;
			if(currentHealth <= 0){

				GameOver();

			}

		}

	}

	void GameOver(){ SceneManager.LoadScene(winScene); }

	
}
