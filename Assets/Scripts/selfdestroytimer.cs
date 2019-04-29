using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestroytimer : MonoBehaviour
{
    public float timer, max;

    void Update(){

    	timer+= Time.deltaTime;

    	if(timer > max)
    	Destroy(gameObject);

    }

}
