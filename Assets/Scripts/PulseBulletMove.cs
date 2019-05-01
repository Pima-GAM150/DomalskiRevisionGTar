using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PulseBulletMove : MonoBehaviour
{
    public float xdir, ydir, speed, timer, timerMult, pulseM;
    // Update is called once per frame
    void Update(){

    	float pulsar = (float)Math.Sin(timer) * pulseM;
    	transform.Translate(new Vector3(xdir, ydir).normalized * ((pulsar + speed) * speed));
        timer += Time.deltaTime * timerMult;
        if(timer > 2f * Math.PI)
        	timer = 0f;
        if(transform.position.x > 11 || transform.position.x < -11 || transform.position.y > 8 || transform.position.y < -8)
			Destroy(gameObject);

    }
}
