using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkPreset : MonoBehaviour
{
    public GameObject sphere;
    public Transform Startpos;
    public Transform Backpos;
    public float time = 3;
    public GameObject player;
    SpriteRenderer playerSr;

    void Start()
    {
        playerSr = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            if (!playerSr.flipX)
            {
                Instantiate(sphere, Startpos.position, Quaternion.identity);
            }
            else
            {
                Instantiate(sphere, Backpos.position, Quaternion.identity);
            }
        }
    }
}
