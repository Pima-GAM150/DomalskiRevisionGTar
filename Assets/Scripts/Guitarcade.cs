using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Guitarcade : MonoBehaviour {

	public Text label;
	public Guitarput input;
	public int maxHealth;
	private int currentHealth;
	public BulletPatterns patternList;
	public float analysisWait;
	private float effectiveWait;



	void Start () {
		effectiveWait = analysisWait;
		currentHealth = maxHealth;
		StartCoroutine(PatternController());
	
	}

	IEnumerator PatternController () {

		while (true) {
		int MIDI = input.FrequencyToMIDI (input.Analyze ());

			if (Input.GetKey (KeyCode.E))
				patternList.SplitterPattern1 ();
	

		switch (MIDI) {
		case 24: case 36: case 48: case 60:	case 72: case 84: case 96:
			label.text = "" + MIDI + ": C";
				patternList.TargetedPattern3 ();
				effectiveWait = 0.8f;
			break;
		case 25: case 37: case 49: case 61: case 73: case 85: case 97:
			label.text = "" + MIDI + ": Db/C#";
			break;
		case 26: case 38: case 50: case 62: case 74: case 86: case 98:
			label.text = "" + MIDI + ": D";
				patternList.SplitterPattern1();
				effectiveWait = 3f;
			break;
		case 27: case 39: case 51: case 63: case 75: case 87: case 99:
			label.text = "" + MIDI + ": Eb/D#";
				patternList.CirclePattern1 ();
				effectiveWait = 0.8f;
			break;
		case 28: case 40: case 52: case 64: case 76: case 88: case 100:
			label.text = "" + MIDI + ": E";

			break;
		case 29: case 41: case 53: case 65: case 77: case 89: case 101:
			label.text = "" + MIDI + ": F";
				patternList.CirclePattern1 ();
				effectiveWait = 0.8f;
			break;
		case 30: case 42: case 54: case 66: case 78: case 90: case 102:
			label.text = "" + MIDI + ": Gb/F#";
			break;
		case 31: case 43: case 55: case 67: case 79: case 91: case 103:
			label.text = "" + MIDI + ": G";
				patternList.CirclePattern2 ();
				effectiveWait = 0.8f;
			break;
		case 32: case 44: case 56: case 68: case 80: case 92: case 104:
			label.text = "" + MIDI + ": Ab/G#";
				patternList.TargetedPattern1 ();
				effectiveWait = 0.5f;
			break;
		case 33: case 45: case 57: case 69: case 81: case 93: case 105:
			label.text = "" + MIDI + ": A";
			break;
		case 34: case 46: case 58: case 70: case 82: case 94: case 106:
			label.text = "" + MIDI + ": Bb/A#";
				patternList.TargetedPattern2 ();
				effectiveWait = 0.5f;
			break;
		case 35: case 47: case 59: case 71: case 83: case 95: case 107:
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
