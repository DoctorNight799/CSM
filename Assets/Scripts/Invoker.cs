using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public GameObject player;

    public GameObject bullet;
    public GameObject wall;
    public GameObject platform;

    public GameObject fireBullet;
    public GameObject fireWall;
    public GameObject firePlatform;

    public Transform Startpos;
    public Transform Backpos;
    public Transform Underpos;

    public LayerMask Ground;

    public float time = 2;
    public float mtime = 2;
    private int[] spell = new int[7];
    private int cast = 1000000;

    public float sphereCoolDownMeta = 3;
    public float wallCoolDownMeta = 2;
    public float platformCoolDownMeta = 1;
    public float fireCDMeta = 1;

    private float sphereCooldown;
    private float wallCooldown;
    private float platformCooldown;
    private float fireCD;

    private bool isMagic = true;
    private bool isSteam = true;

    public bool notEmpty;
    public float checkedRadius = 0.05f;

    SpriteRenderer playerSr;
    SteamBullet Bull;

    void Start()
    {
        sphereCooldown = 0;
        wallCooldown = 0;
        platformCooldown = 0;
        fireCD = 0;
        playerSr = player.GetComponent<SpriteRenderer>();
        Bull = bullet.GetComponent<SteamBullet>();
    }

    void Update()
    {
        checkSpace();
        steampunkSpell();
        magicSpell();
        spellCast();
        spell[0] = 1;
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
            if(spell[2] == 0)
            {
                isMagic = false;
            }
            else
            {
                isMagic = true;
            }
            spell[1] = 1;
            print(spell[0] + "" + spell[1] + "" + spell[2] + "" + spell[3] + "" + spell[4] + "" + spell[5] + "" + spell[6]);
        }
        else
        {
            time = 2;
            isMagic = true;
            for (int i = 1; i < 3; i++)
                spell[i] = 0;
            return;
        }

        steampunkSphere();
        steampunkWall();
        steampunkPlatform();
    }
    void steampunkSphere()
    {
        if (Input.GetKeyDown(KeyCode.H) && time > 0 && sphereCooldown < 0 && isSteam)
        {
            spell[2] = 1;
            print(spell[0] + "" + spell[1] + "" + spell[2] + "" + spell[3] + "" + spell[4] + "" + spell[5] + "" + spell[6]);
        }
    }

    void steampunkWall()
    {
        if (Input.GetKeyDown(KeyCode.J) && time > 0 && wallCooldown < 0 && isSteam) {
            spell[2] = 2;
            print(spell[0] + "" + spell[1] + "" + spell[2] + "" + spell[3] + "" + spell[4] + "" + spell[5] + "" + spell[6]);
        }
    }

    void steampunkPlatform()
    {
        if (Input.GetKeyDown(KeyCode.K) && time > 0 && platformCooldown < 0 && !notEmpty && isSteam)
        {
            spell[2] = 3;
            print(spell[0] + "" + spell[1] + "" + spell[2] + "" + spell[3] + "" + spell[4] + "" + spell[5] + "" + spell[6]);
        }
    }

    void magicSpell()
    {   
        fireCD -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.I) || mtime < 2 && mtime > 0)
        {
            mtime -= Time.deltaTime;
            if (spell[6] == 0)
            {
                isSteam = false;
            }
            else
            {
                isSteam = true;
            }
            spell[5] = 1;
            print(spell[0] + "" + spell[1] + "" + spell[2] + "" + spell[3] + "" + spell[4] + "" + spell[5] + "" + spell[6]);
        }
        else
        {
            mtime = 2;
            isSteam = true;
            for (int i = 5; i <= 6; i++)
                spell[i] = 0;
            return;
        }

        FireMagic();
    }

    void FireMagic()
    {
        if (Input.GetKeyDown(KeyCode.H) && mtime > 0 && fireCD < 0 && isMagic)
        {
            spell[6] = 1;
            print(spell[0] + "" + spell[1] + "" + spell[2] + "" + spell[3] + "" + spell[4] + "" + spell[5] + "" + spell[6]);
        }
    }

    void spellCast()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int d = 1000000;
            for (int i = 1; i <= spell.Length - 1; i++)
            {
                d /= 10;
                if (spell[i] > 0)
                    cast += spell[i] * d;
            }
            switch (cast)
                {
                    case 1110000:
                        if (!playerSr.flipX)
                        {
                            if (Bull.force > 0)
                            {
                            Instantiate(bullet, Startpos.position, Quaternion.identity);
                            time = 0;
                            mtime = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            }
                            else
                            {
                            Bull.force *= -1;
                            Instantiate(bullet, Startpos.position, Quaternion.identity);
                            time = 0;
                            mtime = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            }
                        }
                        else
                        {
                            if (Bull.force < 0)
                            {
                            Instantiate(bullet, Backpos.position, Quaternion.identity);
                            time = 0;
                            mtime = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            }
                            else
                            {
                            Bull.force *= -1;
                            Instantiate(bullet, Backpos.position, Quaternion.identity);
                            time = 0;
                            mtime = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            }
                        }
                        break;

                    case 1120000:
                        if (!playerSr.flipX)
                        {
                            Instantiate(wall, Startpos.position, Quaternion.identity);
                            time = 0;
                            mtime = 0;
                            wallCooldown = wallCoolDownMeta;
                        }
                        else
                        {
                            Instantiate(wall, Backpos.position, Quaternion.identity);
                            time = 0;
                            mtime = 0;
                            wallCooldown = wallCoolDownMeta;
                        }
                        break;

                    case 1130000:
                        Instantiate(platform, Underpos.position, Quaternion.identity);
                        time = 0;
                        mtime = 0;
                        platformCooldown = platformCoolDownMeta;
                        break;

                case 1110011:
                    if (!playerSr.flipX)
                    {
                        if (Bull.force > 0)
                        {
                            Instantiate(fireBullet, Startpos.position, Quaternion.identity);
                            mtime = 0;
                            time = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            fireCD = fireCDMeta;
                        }
                        else
                        {
                            Bull.force *= -1;
                            Instantiate(fireBullet, Startpos.position, Quaternion.identity);
                            mtime = 0;
                            time = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            fireCD = fireCDMeta;
                        }
                    }
                    else
                    {
                        if (Bull.force < 0)
                        {
                            Instantiate(fireBullet, Backpos.position, Quaternion.identity);
                            mtime = 0;
                            time = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            fireCD = fireCDMeta;
                        }
                        else
                        {
                            Bull.force *= -1;
                            Instantiate(fireBullet, Backpos.position, Quaternion.identity);
                            mtime = 0;
                            time = 0;
                            sphereCooldown = sphereCoolDownMeta;
                            fireCD = fireCDMeta;
                        }
                    }
                    break;

                case 1120011:
                    if (!playerSr.flipX)
                    {
                        Instantiate(fireWall, Startpos.position, Quaternion.identity);
                        mtime = 0;
                        time = 0;
                        wallCooldown = wallCoolDownMeta;
                        fireCD = fireCDMeta;
                    }
                    else
                    {
                        Instantiate(fireWall, Backpos.position, Quaternion.identity);
                        mtime = 0;
                        time = 0;
                        wallCooldown = wallCoolDownMeta;
                        fireCD = fireCDMeta;
                    }
                    break;

                case 1130011:
                    Instantiate(firePlatform, Underpos.position, Quaternion.identity);
                    mtime = 0;
                    time = 0;
                    platformCooldown = platformCoolDownMeta;
                    fireCD = fireCDMeta;
                    break;
            }
            cast = 1000000;
        }
    }
}
