using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wall;
    public GameObject platform;
    public GameObject player;

    public Transform Startpos;
    public Transform Backpos;
    public Transform Underpos;

    public LayerMask Ground;

    public float time = 2;

    public float sphereCoolDownMeta = 3;
    public float wallCoolDownMeta = 2;
    public float platformCoolDownMeta = 1;
    private float sphereCooldown;
    private float wallCooldown;
    private float platformCooldown;

    public bool notEmpty;
    public float checkedRadius = 0.05f;

    SpriteRenderer playerSr;
    SteamBullet Bull;

    void Start()
    {
        sphereCooldown = 0;
        wallCooldown = 0;
        platformCooldown = 0;
        playerSr = player.GetComponent<SpriteRenderer>();
        Bull = bullet.GetComponent<SteamBullet>();
    }

    void Update()
    {
        checkSpace();
        steampunkSpell();
    }

    void checkSpace()
    {
        notEmpty = Physics2D.OverlapCircle(Underpos.position, checkedRadius, Ground);
    }

    void steampunkSpell()
    {
        sphereCooldown -= Time.deltaTime;
        wallCooldown -= Time.deltaTime;
        platformCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.U) || time < 2 && time > 0)
        {

            time -= Time.deltaTime;
        }
        else
        {
            time = 2;
            return;
        }

        steampunkSphere();
        steampunkWall();
        steampunkPlatform();
    }
    void steampunkSphere()
    {
        if (Input.GetKeyDown(KeyCode.J) && time > 0 && sphereCooldown < 0)
        {
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
    }

    void steampunkWall()
    {
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

    void steampunkPlatform()
    {
        if (Input.GetKeyDown(KeyCode.L) && time > 0 && platformCooldown < 0 && !notEmpty)
        {
            if (!playerSr.flipX)
            {
                Instantiate(platform, Underpos.position, Quaternion.identity);
                time = 0;
                platformCooldown = platformCoolDownMeta;
            }
            else
            {
                Instantiate(platform, Underpos.position, Quaternion.identity);
                time = 0;
                platformCooldown = platformCoolDownMeta;
            }
        }
    }
}
