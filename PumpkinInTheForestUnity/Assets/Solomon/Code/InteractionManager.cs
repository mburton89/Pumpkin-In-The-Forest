using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Sprite defaultIcon = null;

    public GameObject spriteObject;
    public Sprite Icon = null;
    private Sprite interactsPrite;

    // Start is called before the first frame update
    void Start()
    {
        spriteObject.transform.position = transform.position + new Vector3(0, 10f, 0);

        defaultIcon = Icon;
        Sprite tempSprite = spriteObject.GetComponent<Sprite>();
        tempSprite = Icon;
        interactsPrite = spriteObject.GetComponent<Sprite>();
        interactsPrite = Icon;
    }

    private void OnCollisionExit(Collision collision)
    {
        spriteObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interaction>())
        {
            GameObject other = collision.gameObject;
            Interaction otherInteract = other.GetComponent<Interaction>();

            if (otherInteract.GetUseDefaultIcon() == false)
            {
                interactsPrite = otherInteract.GetObjectIcon();
            }
            else
            {
                interactsPrite = defaultIcon;
            }

            if (otherInteract.GetDisplayOnMe() == false)
            {
                spriteObject.transform.position = transform.position + new Vector3(0, 5f, 0);
            }
            else
            {
                spriteObject.transform.position = other.transform.position + new Vector3(0, 5f, 0);
            }

            spriteObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
