using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Guitarcade : MonoBehaviour {

	public Text label;
	public Guitarput input;
	public int maxHealth;
	private int currentHealth;
	//public BulletPatterns patternList;
	public float analysisWait;
	private float effectiveWait;



	void Start () {
		effectiveWait = analysisWait;
		currentHealth = maxHealth;
		StartCoroutine(PatternController());
	
	}

	void OnCollisionEnter2D(Collision2D collision){


		if(collision.gameObject.tag.Equals("PlayerBullet")){


			currentHealth--;
			if(currentHealth <= 0){

				GameOver();

			}

		}

	}

	void GameOver(){}

	IEnumerator PatternController () {

		while (true) {
		int MIDI = input.FrequencyToMIDI (input.Analyze ());

			if (Input.GetKey (KeyCode.E))
				BulletPatterns.SplitterPattern1 ();

		int temp = MIDI % 12;
	

		switch (MIDI) {
		case 0:
			label.text = "" + MIDI + ": C";
				BulletPatterns.TargetedPattern3 ();
				effectiveWait = 0.8f;
			break;
		case 1:
			label.text = "" + MIDI + ": Db/C#";
			break;
		case 2:
			label.text = "" + MIDI + ": D";
				BulletPatterns.SplitterPattern1();
				effectiveWait = 3f;
			break;
		case 3:
			label.text = "" + MIDI + ": Eb/D#";
				BulletPatterns.CirclePattern1 ();
				effectiveWait = 0.8f;
			break;
		case 4:
			label.text = "" + MIDI + ": E";

			break;
		case 5:
			label.text = "" + MIDI + ": F";
				BulletPatterns.CirclePattern1 ();
				effectiveWait = 0.8f;
			break;
		case 6:
			label.text = "" + MIDI + ": Gb/F#";
			break;
		case 7:
			label.text = "" + MIDI + ": G";
				BulletPatterns.CirclePattern2 ();
				effectiveWait = 0.8f;
			break;
		case 8:
			label.text = "" + MIDI + ": Ab/G#";
				BulletPatterns.TargetedPattern1 ();
				effectiveWait = 0.5f;
			break;
		case 9:
			label.text = "" + MIDI + ": A";
			break;
		case 10:
			label.text = "" + MIDI + ": Bb/A#";
				BulletPatterns.TargetedPattern2 ();
				effectiveWait = 0.5f;
			break;
		case 11:
			label.text = "" + MIDI + ": B";
			break;

		default:
			label.text = "Unrecognized";
			break;

		}

			yield return new WaitForSeconds (effectiveWait);
			effectiveWait = analysisWait;
	
		}}
}
