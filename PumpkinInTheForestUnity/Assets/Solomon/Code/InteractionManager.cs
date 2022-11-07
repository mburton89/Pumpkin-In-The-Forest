using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;
    public KeyCode interactKey;

    public GameObject spriteObject;
    public Sprite Icon = null;

    private Sprite defaultIcon = null;
    private SpriteRenderer interactsPrite;

    private bool showingIcon;
    private bool showingIconOnMe;
    private Transform otherTransform;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        spriteObject.SetActive(false);
        showingIcon = false;
        showingIconOnMe = false;

        spriteObject.transform.position = transform.position + new Vector3(0, 10f, 0);
        defaultIcon = Icon;

        interactsPrite = spriteObject.GetComponent<SpriteRenderer>();
        interactsPrite.sprite = Icon;
    }

    private void OnCollisionExit(Collision collision)
    {
        spriteObject.SetActive(false);
        showingIcon = false;
    }

    private void OnTriggerExit(Collider other)
    {
        spriteObject.SetActive(false);
        showingIcon = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interaction>())
        {
            GameObject other = collision.gameObject;
            Interaction otherInteract = other.GetComponent<Interaction>();
            otherTransform = other.transform;

            if (otherInteract.GetUseDefaultIcon() == false)
            {
                print("This should be working");
                interactsPrite.sprite = otherInteract.GetObjectIcon();
            }
            else
            {
                interactsPrite.sprite = defaultIcon;
            }

            if (otherInteract.GetDisplayOnMe() == false)
            {
                showingIcon = true;
                spriteObject.transform.position = transform.position + new Vector3(0, 5f, 0);
            }
            else
            {
                showingIcon = false;
                spriteObject.transform.position = otherTransform.position + new Vector3(0, 5f, 0);
            }

            spriteObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Interaction>())
        {
            GameObject other = collision.gameObject;
            Interaction otherInteract = other.GetComponent<Interaction>();
            otherTransform = other.transform;

            if (otherInteract.GetUseDefaultIcon() == false)
            {
                print("This should be working");
                interactsPrite.sprite = otherInteract.GetObjectIcon();
            }
            else
            {
                interactsPrite.sprite = defaultIcon;
            }

            if (otherInteract.GetDisplayOnMe() == false)
            {
                showingIcon = true;
                spriteObject.transform.position = transform.position + new Vector3(0, 5f, 0);
            }
            else
            {
                showingIcon = false;
                spriteObject.transform.position = otherTransform.position + new Vector3(0, 5f, 0);
            }

            spriteObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (otherTransform != null)
        {
            spriteObject.transform.position = showingIcon ? transform.position + new Vector3(0, 5f, 0) : otherTransform.position + new Vector3(0, 5f, 0);
        }
    }
}
