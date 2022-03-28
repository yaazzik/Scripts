using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public int laserSpeed = 6;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if(transform.position.y >= 5.5)
        {
            Destroy(this.gameObject);
        }
    }
}
