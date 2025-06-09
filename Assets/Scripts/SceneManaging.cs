using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player came in contact with the object, so the scene is changed.
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

}
