using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class brick : MonoBehaviour
{
    public LogicScript logic;
    public GameObject ball;
    public GameObject powerUp;
    public int damageLevel = 0;
    public AudioSource audioSrc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Color color = new Color(1.0f, 0f, 0f);
        this.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        damageLevel += 1;
        gameObject.GetComponent<Renderer>().material.color = new Color(1 - (0.2f * damageLevel), 0, 0);
        AudioSource.PlayClipAtPoint(audioSrc.clip, transform.position);
        if (damageLevel == 3)
        {
            spawnPowerUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<bulletScript>())
        {
            damageLevel += 1;
            gameObject.GetComponent<Renderer>().material.color = new Color(1 - (0.2f * damageLevel), 0, 0);
            AudioSource.PlayClipAtPoint(audioSrc.clip, transform.position);
            if (damageLevel == 3)
            {
                spawnPowerUp();
            }
        }
    }
    private void spawnPowerUp()
    {
        GameObject newPowerUp;
        if (Random.Range(1, 5) == 1)
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    // 3 balls
                    newPowerUp = Instantiate(powerUp, transform.position, transform.rotation);
                    newPowerUp.GetComponentInParent<PowerUp>().PUType = 0;
                    break;
                case 2:
                    // gun
                    newPowerUp = Instantiate(powerUp, transform.position, transform.rotation);
                    newPowerUp.GetComponentInParent<PowerUp>().PUType = 1;
                    break;
                case 3:
                    // Paddle Expansion
                    Debug.Log("Paddle expansion!!");
                    newPowerUp = Instantiate(powerUp, transform.position, transform.rotation);
                    newPowerUp.GetComponentInParent<PowerUp>().PUType = 2;
                    break;
                case 4:
                    // Safety Net
                    break;
            }
        }
        Destroy(gameObject);
    }
}
