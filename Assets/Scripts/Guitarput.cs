using UnityEngine;
using System.Collections;

public class Guitarput : MonoBehaviour {

	public float sensitivity = 100;
	public float loudness = 0;
	public AudioSource audio;

	void Start() {
		audio.clip = Microphone.Start("Rocksmith", true, 10, 48000);
		while (!(Microphone.GetPosition("Rocksmith") > 0)){Debug.Log("wait");} // Wait until the recording has started
		Debug.Log("Go!");
		audio.Play(); // Play the audio source!
	}

	void Update(){
	}

	public float Analyze(){

		float[] data = new float[2048];
		float max = 0f;
		int maxIndex = 0;

		audio.GetSpectrumData (data, 0, FFTWindow.BlackmanHarris);

		for (int i = 0; i < 2048; i++) {

			if (data [i] > max) {

				maxIndex = i;
				max = data [i];

			}

		}

		float freq = (float)maxIndex;

		if (maxIndex > 0 && maxIndex < 2048) {

			float x = data [maxIndex - 1] / data [maxIndex];
			float y = data [maxIndex + 1] / data [maxIndex];
			freq += 0.5f * (y * y - x * x);

		}

		return freq * (float)AudioSettings.outputSampleRate / 2048; // convert index to frequency

	}

	public int FrequencyToMIDI(float freq, float tuningA = 440f){

		return (int)(69.5 + (12 * (Mathf.Log (freq / tuningA, 2))));

	}

}
