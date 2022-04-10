using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPos : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer playerSr;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        playerSr = player.GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSr.flipX)
            trans.SetPositionAndRotation(-transform.position, transform.rotation);
    }
}
