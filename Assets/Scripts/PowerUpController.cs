using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using static PowerUp;

public class PowerUpController : MonoBehaviour
{
    private float powerUpStrenght = 50f;
    [SerializeField]
    private GameObject missile;//ENCAPSULATION
    private Rigidbody playerRigidbody;
    private float jumpSpeed = 10f, smashSpeed = 100f,smashStrength = 100f;
    private bool hasJumped = false;
    [SerializeField]
    public static powerUpType currentPowerUpType;
    

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        currentPowerUpType = PowerUp.powerUpType.none;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentPowerUpType)
            {
                case PowerUp.powerUpType.missile:
                    Instantiate(missile, transform.position, missile.transform.rotation);
                    return;


                case PowerUp.powerUpType.smash:
                    if (!hasJumped)
                    {
                        hasJumped = true;
                        playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                        Invoke("SmashDown", 1f);
                    }
                    return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUpType == PowerUp.powerUpType.strength)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground") && currentPowerUpType == PowerUp.powerUpType.smash)
        {
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                Rigidbody enemyRigidbody = enemy.gameObject.GetComponent<Rigidbody>();
                enemyRigidbody.AddForceAtPosition((enemy.gameObject.transform.position - transform.position) * smashStrength, transform.position);
            }

        }
    }


    protected virtual void UsePowerUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (PowerUpController.currentPowerUpType)
            {
                case powerUpType.missile:
                    Instantiate(missile, transform.position, missile.transform.rotation);
                    return;


                case powerUpType.smash:
                    if (!hasJumped)
                    {
                        hasJumped = true;
                        playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                        Invoke("SmashDown", 1f);
                    }
                    return;
            }
        }
    }

    private void SmashDown()
    {
        playerRigidbody.AddForce(Vector3.down * smashSpeed, ForceMode.Impulse);
        hasJumped = false;
    }

}
