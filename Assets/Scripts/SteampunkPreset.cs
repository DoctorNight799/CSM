using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkPreset : MonoBehaviour
{
    public GameObject sphere;
    public Transform Startpos;
    public Transform Backpos;
    public float time = 2;
    public GameObject player;
    SpriteRenderer playerSr;
    SphereBullet Bull;

    void Start()
    {
        playerSr = player.GetComponent<SpriteRenderer>();
        Bull = sphere.GetComponent<SphereBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) || time < 2 && time > 0)
        {
            time -= Time.deltaTime;
            print(time);
        }
        else
        {
            time = 2;
            return;
        }
        if (Input.GetKeyDown(KeyCode.J) && time > 0){
            if (!playerSr.flipX)
            {
                if (Bull.force > 0)
                {
                    Instantiate(sphere, Startpos.position, Quaternion.identity);
                    time = 0;
                }
                else
                {
                    Bull.force *= -1;
                    Instantiate(sphere, Startpos.position, Quaternion.identity);
                    time = 0;
                }
            }
            else
            {
                if (Bull.force < 0)
                {
                    Instantiate(sphere, Backpos.position, Quaternion.identity);
                    time = 0;
                }
                else
                {
                    Bull.force *= -1;
                    Instantiate(sphere, Backpos.position, Quaternion.identity);
                    time = 0;
                }
            }
        }
    }
}
