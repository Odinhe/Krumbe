using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public int maxHealth = 10;
    public int health = 5;
    public int stage = 0;
    [SerializeField] private Text warning;

    public List<Sprite> spr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //help set the limition of the player hp, can't be higher than 10
    public int Health
    {
        get
        {
            return health;
        }
        set
        {

            health = Mathf.Clamp(value, 0, maxHealth);
            Debug.Log("Your Life is Good!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player get damaged or not
        if (collision.gameObject.CompareTag("Trap"))
        {
            health--;
            
        }
        if (collision.gameObject.CompareTag("Life"))
        {
            
            health++;

        }
        if (health == 0)
        {
            Die();
        }
        if (collision.gameObject.CompareTag("End"))
        {

            Die();

        }
    }
    void Update()
    {
        //chek player hp, if hp too low, text will pop up
        string deathMessage = (health <= 2) ? warning.text = "You are Dying" : warning.text = "Healthy!";
        Debug.Log(deathMessage);
        //switch state of player sprite when different player hp
        switch (health)
        {
            case 5:
                GetComponent<SpriteRenderer>().sprite = spr[0];
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = spr[1];
                break;
            case 10:
                GetComponent<SpriteRenderer>().sprite = spr[2];
                break;

        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
