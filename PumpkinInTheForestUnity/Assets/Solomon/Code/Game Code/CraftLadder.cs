using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftLadder : MonoBehaviour
{
    public GameObject ladder;
    public Item ladderItemPrefab;

    bool isPlayerColliding; //Using a variable rather than the system seems to have better results.
    bool wasLadderCrafted;

    // Start is called before the first frame update
    void Start()
    {
        HideLadder();
        isPlayerColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(InteractionManager.Instance.interactKey) && isPlayerColliding)
        {
            if (InventoryManager.instance.containsItem(ladderItemPrefab))
            {
                ShowLadder();
            }
        }

        if (wasLadderCrafted && !ladder.activeSelf)
        {
            ShowLadder();
        }

        if (!wasLadderCrafted && ladder.activeSelf)
        {
            HideLadder();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerColliding = false;
    }

    public void HideLadder()
    {
        ladder.SetActive(false);
    }

    public void ShowLadder()
    {
        wasLadderCrafted = true;
        ladder.SetActive(true);
    }
}
