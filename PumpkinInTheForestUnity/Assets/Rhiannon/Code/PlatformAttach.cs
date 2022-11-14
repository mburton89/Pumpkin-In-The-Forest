using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public Rigidbody targetJoint;
    public FixedJoint joint;

    void Start()
    {
        joint = gameObject.GetComponent<FixedJoint>();
    }

    void Update()
    {
        joint = gameObject.GetComponent<FixedJoint>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit!");
            targetJoint = collision.rigidbody;
            Debug.Log(targetJoint);
            joint.connectedBody = targetJoint;
            Debug.Log(joint.connectedBody);
        }

    }

    //public GameObject Player;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Player.transform.parent = this.transform;
    //        Player.GetComponent<Rigidbody>().useGravity = false;
    //        Debug.Log("On");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Player.transform.parent = null;
    //        Player.GetComponent<Rigidbody>().useGravity = true;
    //        Debug.Log("Off");

    //    }
    //}


}