using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSpawner : MonoBehaviour
{
    public GameObject LadderToSpawn;
    public bool AlreadySpawned;
    public bool ownerHasInteraction;
    bool isColliding;
    bool isSpawned;
    public Item itemExample;

    // Start is called before the first frame update
    void Start()
    {
        LadderToSpawn.SetActive((AlreadySpawned) ? true : false);

        isSpawned = (AlreadySpawned) ? true : false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding && Input.GetKeyDown(InteractionManager.Instance.interactKey) && !isSpawned)
        {
            if (InventoryManager.instance.containsItem(itemExample))
            {
                LadderToSpawn.SetActive(true);
                InventoryManager.instance.Remove(itemExample);

                if (ownerHasInteraction)
                {
                    Destroy(gameObject.GetComponent<Interaction>());
                }
                
                isSpawned = true;

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
