using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPlatform : MonoBehaviour
{
    public float timeDestroy = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDestroy -= Time.deltaTime;
        if(timeDestroy < 0)
            Destroy(gameObject);
    }
}
