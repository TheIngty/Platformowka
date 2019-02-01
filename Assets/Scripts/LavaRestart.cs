using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LavaRestart : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SceneManager.LoadScene(0);
            Debug.Log("is colliding");
        }
    }
}