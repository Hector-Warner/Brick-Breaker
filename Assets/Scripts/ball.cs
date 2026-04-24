using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidBody;
    public GameObject paddle;
    public int ballSpeed = 3;
    public LogicScript logic;
    public cameraShake shakeScript;
    void Start()
    {
        GameObject shakeObj = GameObject.FindGameObjectWithTag("MainCamera");
        shakeScript = shakeObj.GetComponent<cameraShake>();

        paddle = GameObject.FindGameObjectWithTag("Paddle");

        GameObject logicObj = GameObject.FindGameObjectWithTag("Logic");
        logic = logicObj.GetComponent<LogicScript>();

        Vector2 launchDir = new Vector2(1, 1).normalized;
        myRigidBody.linearVelocity = launchDir * ballSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.linearVelocity = myRigidBody.linearVelocity.normalized * ballSpeed;
        if (transform.position.y <= -5)
        {
            gameOver();
        }
        if (myRigidBody.linearVelocity.y > -5 && myRigidBody.linearVelocity.y <= 0)
        {
            myRigidBody.linearVelocityY = -5;
        } else if (myRigidBody.linearVelocity.y < 5 && myRigidBody.linearVelocity.y >= 0)
        {
            myRigidBody.linearVelocityY = 5;
        }
        //transform.position = transform.position + (Vector3.right * velocityX * Time.deltaTime) + (Vector3.up * velocityY * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == paddle)
        {
            float paddleHitPoint = transform.position.x - collision.transform.position.x;
            float paddleWidth = collision.collider.bounds.size.x;

            float xDirection = paddleHitPoint / (paddleWidth / 2);

            Vector2 newDir = new Vector2(xDirection, 1).normalized;
            myRigidBody.linearVelocity = newDir * ballSpeed;
            shakeScript.CallShake();
        }
    }

    private void gameOver()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            logic.gameOver();
        }
    }
}
