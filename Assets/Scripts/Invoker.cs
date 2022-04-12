using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject wall;
    public GameObject platform;
    public GameObject player;

    public Transform Startpos;
    public Transform Backpos;
    public Transform Underpos;
    public Transform Deadpos;

    public LayerMask Ground;

    public float time = 2;
    private int[] spell = new int[6];
    private int cast = 1000000;

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
        spellCast();
        DeadSphere();
        print(cast);
    }

    void checkSpace()
    {
        notEmpty = Physics2D.OverlapCircle(Underpos.position, checkedRadius, Ground);
    }

    void steampunkSpell()
    {
        for (int i = 2; i < 4; i++)
            spell[i] = 0;
        sphereCooldown -= Time.deltaTime;
        wallCooldown -= Time.deltaTime;
        platformCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.U) || time < 2 && time > 0)
        {
            time -= Time.deltaTime;
            spell[2] = 1;
            spell[3] = 0;
        }
        else
        {
            spell[2] = 0;
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
            spell[3] = 1;
    }

    void steampunkWall()
    {
        if (Input.GetKeyDown(KeyCode.K) && time > 0 && wallCooldown < 0)
            spell[3] = 2;
    }

    void steampunkPlatform()
    {
        if (Input.GetKeyDown(KeyCode.L) && time > 0 && platformCooldown < 0 && !notEmpty)
            spell[3] = 3;
    }

    void spellCast()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int d = 1000000;
            for (int i = 0; i < spell.Length; i++)
            {
                d /= 10;
                if (spell[i] > 0)
                    cast += spell[i] * d;
            }
            switch (cast)
            {
                case 1001100:
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
                    cast = 1000000;
                    break;

                case 1001200:
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
                    cast = 1000000;
                    break;

                case 1001300:
                    Instantiate(platform, Underpos.position, Quaternion.identity);
                    time = 0;
                    platformCooldown = platformCoolDownMeta;
                    cast = 1000000;
                    break;
            }
        }
    }

    void DeadSphere()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(bullet1, Deadpos.position, Quaternion.identity);
        }
    }
}
