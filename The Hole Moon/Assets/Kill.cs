using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    private Transform target;  // Player's transform
    private Rigidbody2D rb;
    private float facingDirection;
    public float speed = 2f;
    public float knockOutTime = 15;
    private bool isKnockedOut = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        facingDirection = transform.localScale.x;
    }

    // Coroutines 
    IEnumerator knockout()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        isKnockedOut = true;
        yield return new WaitForSeconds(knockOutTime);
        rb.bodyType = RigidbodyType2D.Static;
        isKnockedOut = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isKnockedOut)
        {
            //Change direction of Monster
            if (target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-facingDirection, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(facingDirection, transform.localScale.y);
            }

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isKnockedOut)
        {
            // Game Over - Player is Dead
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            // Restart Level 
            // TODO: Need better transition
            Debug.Log("You dead m8");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (collision.gameObject.tag == "Object")
        {
            // Knock the Monster Out
            Debug.Log("Get Rekted Monster");
            if (isKnockedOut)
            {
                StopCoroutine(knockout());
            }
            StartCoroutine(knockout());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}