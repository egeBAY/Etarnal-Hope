using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Transform startingPos;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    private void Start()
    {
        playerPrefab = Instantiate(playerPrefab, startingPos.position, transform.localRotation);
    }
}
