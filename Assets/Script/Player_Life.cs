using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    //player maximum health
    public int maxHealth = 10;
    //player starting health
    public int health = 5;
    [SerializeField] private Text warning;
    //set up list so when hp changes the sprite list goes down and gives a new sprite
    //public List<Sprite> spr;
    // Start is called before the first frame update
    void Start()
    {
        //get the component so it can be used later in the game
        rb = GetComponent<Rigidbody2D>();
    }
    //help set the limition of the player hp, can't be higher than 10
    //public int Health
   // {
      //  get
       // {
       //     return health;
     //   }
     //   set
     //   {

          //  health = Mathf.Clamp(value, 0, maxHealth);
         //   Debug.Log("Your Life is Good!");
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player get damaged or not, if player collides with trap, they will lose hp, but if player collides with straberry, they will gain life, if they collides with the wall in the bottom, they will die and game will restart
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
    }
    //what will happen when player die, which fitst the bodytype of the player gets changed and game get reset
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();
    }
    //how the game was reset was by loading the scence again
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
