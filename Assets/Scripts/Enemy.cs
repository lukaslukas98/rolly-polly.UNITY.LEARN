using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Entity
{

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        thisRigidbody = GetThisRigidbody();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(thisRigidbody,target);
        DestroyIfOutOfBounds();//INHERITANCE
    }
}
