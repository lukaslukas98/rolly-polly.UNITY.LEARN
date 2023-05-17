using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected GameObject powerUpIndicator;
    [SerializeField]
    protected GameObject currentPowerUpIndicator;
    protected GameObject player;
    [SerializeField]
    public powerUpType thisPowerUpType = powerUpType.strength;

    public enum powerUpType
    {
        strength,
        missile,
        smash,
        none
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PowerUpController.currentPowerUpType == powerUpType.none)
        {
            EnablePowerUp(thisPowerUpType);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        PowerUpController.currentPowerUpType = powerUpType.none;
        Destroy(currentPowerUpIndicator);
        Destroy(gameObject);
    }

    void EnablePowerUp(powerUpType thisPowerUpType)
    {
        PowerUpController.currentPowerUpType = thisPowerUpType;
        currentPowerUpIndicator = GameObject.Instantiate(powerUpIndicator, player.transform.position + new Vector3(0, -0.5f, 0),
            powerUpIndicator.transform.rotation) as GameObject;
        StartCoroutine(PowerUpCountdownRoutine());
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

}
