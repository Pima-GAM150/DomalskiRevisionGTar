using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PulseBulletMove : MonoBehaviour
{
    public float xdir, ydir, speed, timer;
    // Update is called once per frame
    void Update(){

    	float pulsar = (float)Math.Sin(timer);
    	transform.Translate(new Vector3(xdir, ydir).normalized * ((pulsar + speed) * speed));
        timer += Time.deltaTime;
        if(timer > 2f * Math.PI)
        	timer = 0f;

    }
}
