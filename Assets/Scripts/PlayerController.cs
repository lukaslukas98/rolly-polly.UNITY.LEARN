using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{

    private GameObject focalPoint;
    [SerializeField]
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        thisRigidbody = GetThisRigidbody();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyIfOutOfBounds();
    }

    public void Move()//POLYMORPHISM
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        thisRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);
        thisRigidbody.AddForce(focalPoint.transform.right * speed * horizontalInput);
    }

    protected override void DestroyIfOutOfBounds()//POLYMORPHISM
    {
        if (transform.position.y < -10 ||
            transform.position.z < -30 ||
            transform.position.z > 30 ||
            transform.position.x < -30 ||
            transform.position.x > 30)
        {
            gameManager.gameOver();
        }
    }
}
