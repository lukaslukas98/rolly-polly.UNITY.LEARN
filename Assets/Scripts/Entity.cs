using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    protected Rigidbody thisRigidbody;
    protected GameObject target;

    protected Rigidbody GetThisRigidbody()
    {
        return GetComponent<Rigidbody>();
    }

    protected GameObject GetTargetByName(string targetName)
    {
        return GameObject.Find(targetName);
    }

    protected virtual void DestroyIfOutOfBounds()
    {
        if (transform.position.y < -10 ||
            transform.position.z < -30 ||
            transform.position.z > 30 ||
            transform.position.x < -30 ||
            transform.position.x > 30)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void MoveTo(Rigidbody thisRigidbody, GameObject target)
    {
        Vector3 lookDirectionVector3 = (target.transform.position - transform.position).normalized * speed;
        thisRigidbody.AddForce(new Vector3(lookDirectionVector3.x, 0, lookDirectionVector3.z));
    }
}
