using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform Deadpos;

    // Update is called once per frame
    void Update()
    {
        DeadSphere();
    }

    void DeadSphere()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(bullet, Deadpos.position, Quaternion.identity);
        }
    }
}
