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

    private ItemManager itemManager;
    private GameObject dialogBox;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        itemManager = this.GetComponent<ItemManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<HouseEnterController>())
        {
            sceneToLoad = "House";
            targetScene = SceneManager.GetSceneByName(sceneToLoad);
            dialogBox = collision.gameObject.GetComponent<HouseEnterController>().dialogBox;
            if (itemManager.hasShovel)
            {
                canEnter = true;
            }
            else 
            {
                Debug.Log("U need shovel");
                dialogBox.SetActive(true);
                canEnter = false;
            }
            
        }
        else if (collision.GetComponent<House2EnterController>())
        {
            sceneToLoad = "House2";
            targetScene = SceneManager.GetSceneByName(sceneToLoad);
            canEnter = true;
        }
        else if (collision.GetComponent<House3EnterController>())
        {
            sceneToLoad = "House3";
            targetScene = SceneManager.GetSceneByName(sceneToLoad);
            canEnter = true;
        }
        else if (collision.GetComponent<House4EnterController>())
        {
            sceneToLoad = "House4";
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
        if (collision.GetComponent<HouseEnterController>() || collision.GetComponent<House2EnterController>())
        {
            canEnter = false;
            dialogBox.SetActive(false);
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
