using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool hasShovel = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                hasShovel = true;
                Destroy(collision.gameObject);
            }
        }
    }

}
