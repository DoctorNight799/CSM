using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkPreset : MonoBehaviour
{
    public GameObject sphere;
    public GameObject wall;
    public GameObject player;

    public Transform Startpos;
    public Transform Backpos;

    public float time = 2;
    public float wallCooldown = 2;
    public float sphereCooldown = 3;
    public float coolDown = 0;

    SpriteRenderer playerSr;
    SphereBullet Bull;

    void Start()
    {
        coolDown = 0;
        playerSr = player.GetComponent<SpriteRenderer>();
        Bull = sphere.GetComponent<SphereBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.U) || time < 2 && time > 0)
        {
            
            time -= Time.deltaTime;
            print(coolDown);
        }
        else
        {
            time = 2;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.J) && time > 0 && coolDown < 0){
            if (!playerSr.flipX)
            {
                if (Bull.force > 0)
                {
                    Instantiate(sphere, Startpos.position, Quaternion.identity);
                    time = 0;
                    coolDown = sphereCooldown;
                }
                else
                {
                    Bull.force *= -1;
                    Instantiate(sphere, Startpos.position, Quaternion.identity);
                    time = 0;
                    coolDown = sphereCooldown;
                }
            }
            else
            {
                if (Bull.force < 0)
                {
                    Instantiate(sphere, Backpos.position, Quaternion.identity);
                    time = 0;
                    coolDown = sphereCooldown;
                }
                else
                {
                    Bull.force *= -1;
                    Instantiate(sphere, Backpos.position, Quaternion.identity);
                    time = 0;
                    coolDown = sphereCooldown;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.K) && time > 0 && coolDown < 0)
        {
            if (!playerSr.flipX)
            {
                    Instantiate(wall, Startpos.position, Quaternion.identity);
                    time = 0;
                coolDown = wallCooldown;
            }
            else
            {
                    Instantiate(wall, Backpos.position, Quaternion.identity);
                    time = 0;
                coolDown = wallCooldown;
            }
        }
    }
}
