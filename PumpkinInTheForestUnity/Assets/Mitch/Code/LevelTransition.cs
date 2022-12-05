using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
 public class LevelTransition : MonoBehaviour
{


    public string SceneName;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneName); // loads scene When player enter the trigger collider
        }
    }


    /*void OnTriggerStay(Collider other)
    {
        if (other.tag == "AnythingYouLike")
        {
            if (Input.GetKeyDown(KeyCode.E)) // loads scene on user input when in collider
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }*/

   /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // loads scene on user input From anywhere
        {
            SceneManager.LoadScene(SceneName);
        }
    }*/
}