using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMover.itemsBumped++;
            Debug.Log("No. times you bumped an item: " + PlayerMover.itemsBumped);
        }
    }
}
