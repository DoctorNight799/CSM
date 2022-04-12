using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSphere : MonoBehaviour
{
    public float force = -1f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddRelativeForce(new Vector2(force, 0), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Destroy(gameObject);
    }
}
