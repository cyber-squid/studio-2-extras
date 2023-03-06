using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerObj : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveAmount = 5.0f;
    public float timeBetweenMovements = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {

        rb.velocity = Vector2.right * moveAmount;
        yield return new WaitForSeconds(timeBetweenMovements);

        rb.velocity = Vector2.up * moveAmount;
        yield return new WaitForSeconds(timeBetweenMovements); 

        rb.velocity = Vector2.left * moveAmount;
        yield return new WaitForSeconds(timeBetweenMovements);

        rb.velocity = Vector2.down * moveAmount;
        yield return new WaitForSeconds(timeBetweenMovements);

        StartCoroutine(Move());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
    }

}
