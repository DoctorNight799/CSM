using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBullet : MonoBehaviour
{
    public float force = 10f;
    public float timeDestroy = 1f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddRelativeForce(new Vector2(force, 0), ForceMode2D.Impulse);
        timeDestroy -= Time.deltaTime;
        if (timeDestroy < 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
