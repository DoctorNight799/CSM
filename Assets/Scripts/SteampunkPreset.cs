using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkPreset : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wall;
    public GameObject player;

    public Transform Startpos;
    public Transform Backpos;

    public float time = 2;

    public float sphereCoolDownMeta = 3;
    public float wallCoolDownMeta = 2;
    private float wallCooldown;
    private float sphereCooldown;

    SpriteRenderer playerSr;
    SteamBullet Bull;

    void Start()
    {
        sphereCooldown = 0;
        wallCooldown = 0;
        playerSr = player.GetComponent<SpriteRenderer>();
        Bull = bullet.GetComponent<SteamBullet>();
    }

    void Update()
    {
        sphereCooldown -= Time.deltaTime;
        wallCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.U) || time < 2 && time > 0)
        {
            
            time -= Time.deltaTime;
        }
        else
        {
            time = 2;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.J) && time > 0 && sphereCooldown < 0){
            if (!playerSr.flipX)
            {
                if (Bull.force > 0)
                {
                    Instantiate(bullet, Startpos.position, Quaternion.identity);
                    time = 0;
                    sphereCooldown = sphereCoolDownMeta;
                }
                else
                {
                    Bull.force *= -1;
                    Instantiate(bullet, Startpos.position, Quaternion.identity);
                    time = 0;
                    sphereCooldown = sphereCoolDownMeta;
                }
            }
            else
            {
                if (Bull.force < 0)
                {
                    Instantiate(bullet, Backpos.position, Quaternion.identity);
                    time = 0;
                    sphereCooldown = sphereCoolDownMeta;
                }
                else
                {
                    Bull.force *= -1;
                    Instantiate(bullet, Backpos.position, Quaternion.identity);
                    time = 0;
                    sphereCooldown = sphereCoolDownMeta;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.K) && time > 0 && wallCooldown < 0)
        {
            if (!playerSr.flipX)
            {
                    Instantiate(wall, Startpos.position, Quaternion.identity);
                    time = 0;
                wallCooldown = wallCoolDownMeta;
            }
            else
            {
                    Instantiate(wall, Backpos.position, Quaternion.identity);
                    time = 0;
                wallCooldown = wallCoolDownMeta;
            }
        }
    }
}
