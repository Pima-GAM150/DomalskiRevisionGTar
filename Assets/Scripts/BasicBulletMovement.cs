using UnityEngine;

using System.Collections;



public class BasicBulletMovement : MonoBehaviour {

	public float xDir, yDir, movementSpeed;
	public Transform transform; 


	void Update(){

		transform.Translate(new Vector3(xDir, yDir) * movementSpeed * Time.deltaTime);		

		if(transform.position.x <  -10 || transform.position.x > 10 || transform.position.y < -10 || transform.position.y > 10)
			Destroy(gameObject);

	}


}
