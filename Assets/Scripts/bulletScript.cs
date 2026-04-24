using System.Runtime.CompilerServices;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private float lifeSpan = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocityY = 5;
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan += Time.deltaTime;
        if (lifeSpan >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(gameObject);
        }
    }
}
