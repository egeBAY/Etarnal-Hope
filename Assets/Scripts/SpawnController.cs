using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{

    private bool canEnter;
    private bool isSpawned = false;
    private string sceneToLoad;

    private Scene currentScene;
    private Scene targetScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HouseEnterController>())
        {
            sceneToLoad = "House";
            targetScene = SceneManager.GetSceneByName(sceneToLoad);
            canEnter = true;
        }
        else if (collision.GetComponent<BarnEnterController>())
        {
            sceneToLoad = "Barn";
            targetScene = SceneManager.GetSceneByName(sceneToLoad);
            canEnter = true;
        }
        else if (collision.GetComponent<HouseExitController>())
        {
            sceneToLoad = "Outside";
            targetScene = SceneManager.GetSceneByName(sceneToLoad);
            canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HouseEnterController>() || collision.GetComponent<BarnEnterController>())
        {
            canEnter = false; 
        }
    }

    private void Update()
    {
        if (canEnter && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
            DontDestroyOnLoad(gameObject);
        }
    }

}
