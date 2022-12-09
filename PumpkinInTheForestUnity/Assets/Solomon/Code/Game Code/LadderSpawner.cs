using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSpawner : MonoBehaviour
{
    public GameObject LadderToSpawn;
    bool isColliding;
    public Item itemExample;

    // Start is called before the first frame update
    void Start()
    {
        LadderToSpawn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding && Input.GetKeyDown(InteractionManager.Instance.interactKey))
        {
            if (InventoryManager.instance.containsItem(itemExample))
            {
                LadderToSpawn.SetActive(true);
                InventoryManager.instance.Remove(itemExample);
            }
            print("Spawner Ladder");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
        }
    }
}
