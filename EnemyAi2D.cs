using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi2D : MonoBehaviour
{

    private GameObject playerFind;
    private float playerPos;
    private int multiplier;
    private Rigidbody2D thisRb;
    [SerializeField]
    private float enemySpeed;
    private float currentYSpeed;
    private bool damaged;
    [SerializeField]
    private int currentHealth;
    private bool isDead;
    

    // Use this for initialization
    void Awake()
    {

        playerFind = GameObject.FindWithTag("Player");
        thisRb = GetComponent<Rigidbody2D>();
        currentHealth = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        playerPos = playerFind.transform.position.x;
        currentYSpeed = thisRb.velocity.y;
        if (this.gameObject.transform.position.x - playerPos > 0)
        {
            multiplier = -1;

        }
        else
        {
            multiplier = 1;
        }
        if((this.gameObject.transform.position.x - playerPos > 3) || (this.gameObject.transform.position.x - playerPos < -3))
        {
            thisRb.velocity = new Vector2(enemySpeed * multiplier, currentYSpeed);
            
        }
        else
        {
            thisRb.velocity = new Vector2(enemySpeed * -multiplier, currentYSpeed);
            
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        
        if (currentHealth <= 0 && !isDead)
        {
            Destroy(gameObject);
        }
    }
}
