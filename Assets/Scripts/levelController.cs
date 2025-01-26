using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Scene activeScene = SceneManager.GetActiveScene();

        if (collision.gameObject.tag == "portal" &&  activeScene.buildIndex <= 7)
        {
            
            int nextSceneIndex = activeScene.buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
