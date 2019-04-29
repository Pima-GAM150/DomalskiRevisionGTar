using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedBulletMovement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector3.down * speed);
    }

}
