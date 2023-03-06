using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Separate class from the flyweight squad. in this case both values (besides prefab and speed, stored in context)
/// are extrinsic, so I decided to make these a simple, single class.
/// </summary>
public class Projectile : MonoBehaviour
{

    public Rigidbody2D projectileRB;
    public SpriteRenderer projectileSprite;

    private void OnEnable()
    {
        projectileRB = GetComponent<Rigidbody2D>();
        projectileSprite = GetComponent<SpriteRenderer>();

        StartCoroutine(DestroyCountdown()); // make sure we don't build up instances
    }

    IEnumerator DestroyCountdown()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

}
