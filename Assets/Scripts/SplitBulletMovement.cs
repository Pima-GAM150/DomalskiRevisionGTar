using UnityEngine;
using System.Collections;

public class SplitBulletMovement : MonoBehaviour {

	public float xDir, yDir, movementSpeed;
	public GameObject boolet;
	//private float splitTimer = 0;
	private Transform transform;
	//public BulletPatterns bulletSpawner;
	public bool isActivated;

	// Use this for initialization
	void Start () {
	
		transform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isActivated) {
			transform.Translate (new Vector3 (xDir, yDir) * movementSpeed * Time.deltaTime);		

			if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -10 || transform.position.y > 10)
				Destroy (gameObject);

			if (Random.Range(0, 200) == 1/*splitTimer >= 1.2f*/) {

				if (boolet.name.Equals ("Bullet")) {
					//isActivated = false;
					BulletPatterns.spawnBullet (xDir, yDir, boolet, transform.position);
					BulletPatterns.spawnBullet (-1 * xDir, yDir, boolet, transform.position);
					BulletPatterns.spawnBullet (-1 * xDir, -1 * yDir, boolet, transform.position);
					BulletPatterns.spawnBullet (xDir, -1 * yDir, boolet, transform.position);
					//Destroy(boolet);
					Destroy (gameObject);

				} else {
					BulletPatterns.spawnSplitterBullet (xDir, yDir, boolet, transform.position);
					BulletPatterns.spawnSplitterBullet (-1 * xDir, yDir, boolet, transform.position);
					BulletPatterns.spawnSplitterBullet (-1 * xDir, -1 * yDir, boolet, transform.position);
					BulletPatterns.spawnSplitterBullet (xDir, -1 * yDir, boolet, transform.position);
					Destroy (gameObject);
				}

			}

			//if(Random.Range(0, 2) == 1)
			//splitTimer += (Time.deltaTime /* *Random.Range(5, 20)*/);
		}

	}
}

