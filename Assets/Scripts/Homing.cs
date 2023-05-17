using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    public Enemy[] targets;
    public Enemy enemy;
    private Rigidbody missileRigidbody;
    public float speed = 0.01f;
    public float impactStrength = 20f;

    // Start is called before the first frame update
    void Start()
    {
        missileRigidbody = GetComponent<Rigidbody>();
        targets = FindObjectsOfType<Enemy>();
        enemy = targets[Random.Range(0,targets.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null){ Destroy(gameObject); }
        else
        {
            //transform.Translate(enemy.transform.position - transform.position);// += (enemy.transform.position - transform.position).normalized * speed*Time.deltaTime;
            missileRigidbody.AddForce((enemy.transform.position+new Vector3(0,0.5f,0) - transform.position).normalized * speed);
            //transform.Translate((enemy.gameObject.transform.position - transform.position));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            enemyRigidbody.AddForce((other.gameObject.transform.position-transform.position).normalized * impactStrength,ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
