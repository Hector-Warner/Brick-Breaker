using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class platform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidBody;
    public float playerSpeed;
    public float speed = 10;
    private Vector2 mousePos;
    public GameObject ball;
    public GameObject bullet;
    private float bulletDuration = 0;
    private bool gunActive = false;
    private float fireRateTimer = 0;
    private float extensionTimer = 0;
    private bool extensionActive = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletDuration += Time.deltaTime;
        fireRateTimer += Time.deltaTime;
        extensionTimer += Time.deltaTime;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, -4.5f);
        if (gunActive)
        {
            if (fireRateTimer >= 0.5f)
            {
                fireRateTimer = 0;
                Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), transform.rotation);
            }
            if (bulletDuration >= 5)
            {
                gunActive = false;
            }
        }
        if (extensionActive)
        {
            if (extensionTimer >= 5)
            {
                extensionActive = false;
                transform.localScale = new Vector2(3, 0.4f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
            switch (collision.gameObject.GetComponent<PowerUp>().PUType)
            {
                case 0:
                    // 3
                    Destroy(collision.gameObject);
                    for (int i = -1; i < 2; i++)
                    {
                        Instantiate(ball, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - (i * 0.5f), -4.5f), transform.rotation);
                    }
                    break;
                case 1:
                    // gun
                    Destroy(collision.gameObject);
                    gunActive = true;
                    bulletDuration = 0;
                    fireRateTimer = 0;
                    print("Gun is Active!");
                    
                    break;
                case 2:
                    // Paddle Expansion
                    Destroy(collision.gameObject);
                    extensionTimer = 0;
                    extensionActive = true;
                    gameObject.transform.localScale = new Vector3(6,0.4f,1);
                    Debug.Log("Extending!!");
                    break;
                case 3:
                    // Safety Net
                    break;
            }
    }
}