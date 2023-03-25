using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEnterController : MonoBehaviour
{
    public string House; // The name of the scene to load when the player touches the door

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("31");
    }
}