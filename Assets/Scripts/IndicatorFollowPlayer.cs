using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorFollowPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 powerUpIndicatorPosition = player.transform.position + new Vector3(0, -0.5f, 0);
        transform.position = powerUpIndicatorPosition;
    }
}
