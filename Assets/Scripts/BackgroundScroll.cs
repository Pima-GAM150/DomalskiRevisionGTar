using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed;
    public float size;


    private void Update()
    {

        transform.Translate(0, -1 * speed * Time.deltaTime, 0);

        if(transform.position.y <= (-0.5f * size)+ 5) {

            transform.Translate(0, (size * 0.5f) - 5f, 0);

        }

    }
}
