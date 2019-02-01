using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class respawn : MonoBehaviour
{
    public float threshold;

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}