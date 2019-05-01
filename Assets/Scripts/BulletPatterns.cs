using UnityEngine;
using System;
using System.Collections;


public class BulletPatterns : MonoBehaviour {



	public static GameObject gTar, ship;
	public static GameObject basicBullet, splitBullet, tarPat1, tarPat2, serpPat1, serpPat2, pulPat1, pulPat2;
	private static Vector3 gPos, sPos;

	void Start(){

		ship = GameObject.Find("Player");
		basicBullet = (GameObject)Resources.Load("Bullet");
		splitBullet = (GameObject)Resources.Load("Splitter Bullet");
		tarPat1 = (GameObject)Resources.Load("TargetedBulletPattern1");
		tarPat2 = (GameObject)Resources.Load("TargetedBulletPattern2");
		pulPat1 = (GameObject)Resources.Load("PulsingBulletPattern1");
		pulPat2 = (GameObject)Resources.Load("PulsingBulletPattern2");
		serpPat1 = (GameObject)Resources.Load("SerpentinePattern1");
		serpPat2 = (GameObject)Resources.Load("SerpentinePattern2");
		gTar = GameObject.Find("Note Detector");
		gPos = gTar.GetComponent<Transform>().position; }

	public static void spawnBullet(float xDir, float yDir, GameObject bulletType, Vector3 spawn){

		GameObject x = (GameObject)Instantiate (bulletType, spawn, Quaternion.identity);
		BasicBulletMovement y = x.GetComponent<BasicBulletMovement> ();
		y.xDir = xDir;
		y.yDir = yDir;
	}

	public static void spawnSplitterBullet(float xDir, float yDir, GameObject bulletType, Vector3 spawn){

		GameObject x = (GameObject)Instantiate (bulletType, spawn, Quaternion.identity);
		SplitBulletMovement y = x.GetComponent<SplitBulletMovement> ();
		//y.isActivated = true;
		y.xDir = xDir;
		y.yDir = yDir;

	}

	static void spawnBullet(float xDir, float yDir, GameObject bulletType){

		GameObject x = (GameObject)Instantiate (bulletType, gPos, Quaternion.identity);
		BasicBulletMovement y = x.GetComponent<BasicBulletMovement> ();
		y.xDir = xDir;
		y.yDir = yDir;
	}

	public static void PulsingBulletPattern1(){

		Instantiate(pulPat1, gPos, Quaternion.identity);

	}

	public static void PulsingBulletPattern2(){

		Instantiate(pulPat2, gPos, Quaternion.identity);

	}

	public static void CirclePattern1(){

		spawnBullet (-1f, 0f, basicBullet);
		spawnBullet (1f, 0f, basicBullet);
		spawnBullet (-0.951f, -0.309f, basicBullet);
		spawnBullet (-0.809f, -0.5878f, basicBullet);
		spawnBullet (-0.5878f, -0.809f, basicBullet);
		spawnBullet (-0.309f, -0.951f, basicBullet);
		spawnBullet (0f, -1f, basicBullet);
		spawnBullet (0.309f, -0.951f, basicBullet);
		spawnBullet (0.951f, -0.309f, basicBullet);
		spawnBullet (0.809f, -0.5878f, basicBullet);
		spawnBullet (0.5878f, -0.809f, basicBullet);
	}

	public static void CirclePattern2(){

		spawnBullet (-0.9877f, -0.1564f, basicBullet);
		spawnBullet (0.9877f, -0.1564f, basicBullet);
		spawnBullet (-0.1564f, -0.9877f, basicBullet);
		spawnBullet (0.1564f, -0.9877f, basicBullet);
		spawnBullet (-0.454f, -0.891f, basicBullet);
		spawnBullet (-0.891f, -0.454f, basicBullet);
		spawnBullet (0.454f, -0.891f, basicBullet);
		spawnBullet (0.891f, -0.454f, basicBullet);
		spawnBullet (-0.7071f, -0.7071f, basicBullet);
		spawnBullet (0.7071f, -0.7071f, basicBullet);
	}

	public static void TargetedPattern1(){
		gPos = gTar.GetComponent<Transform>().position;
		GameObject temp = (GameObject)Instantiate(tarPat1, gPos, Quaternion.identity);

		bool negative = (gPos.x < ship.transform.position.x);
		float tempx = Mathf.Abs(gPos.x - ship.transform.position.x);
		float tempy = gPos.y - ship.transform.position.y;
		float rotation = Mathf.Atan(tempx / tempy) * 180f / Mathf.PI;

		if(!negative)
			rotation = rotation * -1f;

		temp.transform.Rotate(0f, 0f, rotation);

	}

	public static void TargetedPattern2(){
		gPos = gTar.GetComponent<Transform>().position;
		GameObject temp = (GameObject)Instantiate(tarPat2, gPos, Quaternion.identity);

		bool negative = (gPos.x < ship.transform.position.x);
		float tempx = Mathf.Abs(gPos.x - ship.transform.position.x);
		float tempy = gPos.y - ship.transform.position.y;
		float rotation = Mathf.Atan(tempx / tempy) * 180f / Mathf.PI;

		if(!negative)
			rotation = rotation * -1f;

		temp.transform.Rotate(0f, 0f, rotation);
	}

	public static void TargetedPattern3(){

		sPos = ship.GetComponent<Transform>().position;
		float root3Side = Mathf.Sqrt(3) * 3f;
		TargetedPattern3BulletSpawner (sPos.x + 6, sPos.y, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x + root3Side, sPos.y + 3, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x + 3, sPos.y + root3Side, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x, sPos.y + 6, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x - root3Side, sPos.y + 3, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x - 3, sPos.y + root3Side, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x - 6, sPos.y, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x - root3Side, sPos.y - 3, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x - 3, sPos.y - root3Side, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x, sPos.y - 6, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x + root3Side, sPos.y - 3, basicBullet);
		TargetedPattern3BulletSpawner (sPos.x + 3, sPos.y - root3Side, basicBullet);
	}

	public static void SerpentinePattern1(){
		gPos = gTar.GetComponent<Transform>().position;
		Instantiate(serpPat1, gPos, Quaternion.identity);

	}

	public static void SerpentinePattern2(){
		gPos = gTar.GetComponent<Transform>().position;
		Instantiate(serpPat2, gPos, Quaternion.identity);

	}

	public static void SplitterPattern1(){
		gPos = gTar.GetComponent<Transform>().position;
		spawnSplitterBullet (-1f, 0f, splitBullet, gPos);
		spawnSplitterBullet (1f, 0f, splitBullet, gPos);
		spawnSplitterBullet (-0.951f, -0.309f, splitBullet, gPos);
		spawnSplitterBullet (-0.809f, -0.5878f, splitBullet, gPos);
		spawnSplitterBullet (-0.5878f, -0.809f, splitBullet, gPos);
		spawnSplitterBullet (-0.309f, -0.951f, splitBullet, gPos);
		spawnSplitterBullet (0f, -1f, splitBullet, gPos);
		spawnSplitterBullet (0.309f, -0.951f, splitBullet, gPos);
		spawnSplitterBullet (0.951f, -0.309f, splitBullet, gPos);
		spawnSplitterBullet (0.809f, -0.5878f, splitBullet, gPos);
		spawnSplitterBullet (0.5878f, -0.809f, splitBullet, gPos);

	}

	static void TargetedPattern3BulletSpawner(float xPos, float yPos, GameObject bulletType){
		
		Vector3 normal = new Vector3 (sPos.x - xPos, sPos.y - yPos);
		normal = normal / normal.magnitude;
		GameObject x = (GameObject)Instantiate (bulletType, new Vector3 (xPos, yPos), Quaternion.identity);
		BasicBulletMovement y = x.GetComponent<BasicBulletMovement> ();
		y.xDir = normal.x;
		y.yDir = normal.y;
	}

}
