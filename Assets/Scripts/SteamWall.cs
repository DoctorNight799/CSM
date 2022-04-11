using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamWall : MonoBehaviour
{
    public float timeDestroy = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        timeDestroy -= Time.deltaTime;
        if (timeDestroy < 0)
            Destroy(gameObject);
    }
}
