using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            print("Processing");
            transform.position = new Vector3(player.position.x + 1.4f, player.position.y + 15.9f, player.position.z - 30.52f);
        }
    }
}
