using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int PUType;
    public Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.linearVelocityY = -1;
        Color color;
        switch (PUType)
        {
            case 0:
                color = new Color(1.0f, 0f, 0f);
                gameObject.GetComponent<Renderer>().material.color = color;
                break;
            case 1:
                color = new Color(0f, 1.0f, 0f);
                gameObject.GetComponent<Renderer>().material.color = color;
                break;
            case 2:
                color = new Color(0f, 0f, 1.0f);
                gameObject.GetComponent<Renderer>().material.color = color;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
