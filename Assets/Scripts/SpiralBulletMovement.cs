using UnityEngine;

using System.Collections;



public class SpiralBulletMovement : MonoBehaviour {


	public float theta, movementSpeed, ROCTheta;
	public Transform transform; 

	void Update(){

		transform.Translate(new Vector3(Mathf.Cos(theta), Mathf.Sin(theta)) * Time.deltaTime * movementSpeed);

		theta += Time.deltaTime * ROCTheta;
				

		if(transform.position.x <  -10 || transform.position.x > 10 || transform.position.y < -10 || transform.position.y > 10)
			Destroy(gameObject);

	}


}
