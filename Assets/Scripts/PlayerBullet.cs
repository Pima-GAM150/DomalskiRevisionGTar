using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;

    private void Update()
    {

        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y > 7)
            DestroyObject(gameObject);


    }
}
