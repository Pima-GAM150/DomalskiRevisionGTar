using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Guitarcade : MonoBehaviour {

	public Text label;
	public Guitarput input;
	public GameObject healthBar;
	public int MIDI;
	public int maxHealth;
	public int currentHealth, calc;
	//public BulletPatterns patternList;
	public float analysisWait, timerChar, consMin, consMax, min, timerMax, speed;
	private float effectiveWait;
	public bool canFire, charging, firing, posDir;
    private int previousMIDI;
    public GameObject charger, laser;
    public int winScene;



	void Start () {
		effectiveWait = analysisWait;
		currentHealth = maxHealth;
		//StartCoroutine(PatternController());
		
	
	}

	void Update(){

        MIDI = input.FrequencyToMIDI(input.Analyze());

        //if(!canFire && MIDI != previousMIDI && analysisWait > 0.33f) {

          //  canFire = true;

        //}
        healthBar.transform.localScale = new Vector3(1f, (1f / maxHealth) * currentHealth, 1f);

        if (canFire){

				if (Input.GetKey (KeyCode.E))
					BulletPatterns.SplitterPattern1 ();

			int temp = MIDI % 12;
            previousMIDI = MIDI;
		

			switch (temp) {
			case 0:
				label.text = "" + MIDI + ": C";
					BulletPatterns.TargetedPattern3 ();
					effectiveWait = min + 0.6f;
					canFire = false;
				break;
			case 1:
				label.text = "" + MIDI + ": Db/C#";
				BulletPatterns.SplitterPattern1();
					effectiveWait = min + 1.2f;
					canFire = false;
				break;
			case 2:
				label.text = "" + MIDI + ": D";
					BulletPatterns.SerpentinePattern1();
					effectiveWait = min + 1.2f;
					canFire = false;
				break;
			case 3:
				label.text = "" + MIDI + ": Eb/D#";
					BulletPatterns.CirclePattern1 ();
					effectiveWait = min + 0.6f;
					canFire = false;
				break;
			case 4:
				label.text = "" + MIDI + ": E";
				BulletPatterns.CirclePattern1 ();
					effectiveWait = min + 0.6f;
					canFire = false;

				break;
			case 5:
				label.text = "" + MIDI + ": F";
					BulletPatterns.SerpentinePattern2 ();
					effectiveWait = min + 0.6f;
					canFire = false;
				break;
			case 6:
				label.text = "" + MIDI + ": Gb/F#";
				BulletPatterns.CirclePattern2 ();
					effectiveWait = min + 0.6f;
					canFire = false;
				break;
			case 7:
				label.text = "" + MIDI + ": G";
					BulletPatterns.CirclePattern2 ();
					effectiveWait = min + 0.6f;
					canFire = false;
				break;
			case 8:
				label.text = "" + MIDI + ": Ab/G#";
					BulletPatterns.TargetedPattern1 ();
					effectiveWait = min + 0.3f;
					canFire = false;
				break;
			case 9:
				label.text = "" + MIDI + ": A";
				BulletPatterns.PulsingBulletPattern2 ();
					effectiveWait = min + 0.6f;
					canFire = false;
				break;
			case 10:
				label.text = "" + MIDI + ": Bb/A#";
					BulletPatterns.PulsingBulletPattern1 ();
					effectiveWait = min + 0.3f;
					canFire = false;
				break;
			case 11:
				label.text = "" + MIDI + ": B";
				BulletPatterns.TargetedPattern2 ();
					effectiveWait = min + 0.3f;
					canFire = false;
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

		if(charging){

			timerChar += Time.deltaTime;
			if(timerChar > timerMax){

				FireLaser();

			}


		}
		else if(firing){

			if(posDir){

				transform.Translate(Vector3.right * speed);
				if(transform.position.x > consMax){

					posDir = false;
					calc++;

				}

			}
			else{

				transform.Translate(Vector3.left * speed);
				if(transform.position.x < consMin){

					posDir = true;
					calc++;

				}

			}

			if(calc >= 2 && transform.position.x > -0.1){

				EndLaser();

			}

		}


	}

	void ChargeLaser(){

		charging = true;
		charger.SetActive(true);
		timerChar = 0;
		min = 0.1f;

	}
	void FireLaser(){

		charging = false;
		firing = true;
		posDir = true;
		calc = 0;
		laser.SetActive(true);
		min = 0.2f;

	}
	void EndLaser(){

		charger.SetActive(false);
		laser.SetActive(false);
		firing = false;
		min = 0f;

	}

	void OnCollisionEnter2D(Collision2D collision){

		if(collision.gameObject.tag.Equals("Player")){


			currentHealth = currentHealth - 1;
			if(currentHealth <= 0){

				GameOver();

			}

		}

	}

	void OnTriggerEnter2D(Collider2D collision){


		if(collision.gameObject.tag.Equals("PlayerBullet")){


			currentHealth--;
			if(currentHealth <= 0){

				GameOver();

			}

		}

	}

	void GameOver(){ SceneManager.LoadScene(winScene); }

	
}
