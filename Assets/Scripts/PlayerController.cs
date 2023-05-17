using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{

    private GameObject focalPoint;


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

    public void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        thisRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);
        thisRigidbody.AddForce(focalPoint.transform.right * speed * horizontalInput);
    }

    private void DestroyIfOutOfBounds()
    {
        if (transform.position.y < -10 ||
            transform.position.z < -30 ||
            transform.position.z > 30 ||
            transform.position.x < -30 ||
            transform.position.x > 30)
        {
            GameManager.isGameOver = true;
        }
    }
}
