using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    //player starting life
    private int Life = 5;
    //put the prefab inside the code so can use later
    public GameObject Strabarry;
    public GameObject Trap;
    private Rigidbody2D rb;
    //set up a vector2 so later items can genrated randomly on the map
    public Vector2 spawnPosition;
    [SerializeField] private Text warning;
    public List<Sprite> spr;

    //set the text so text are able to change when life changes
    [SerializeField] private Text lifeText;
    void Start()
    {
        //get the component so it can be used later in the game
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    
            //chek player hp, if hp too low, text will pop up
            string deathMessage = (Life <= 2) ? warning.text = "You are Dying" : warning.text = "Healthy!";
            Debug.Log(deathMessage);
            //switch state of player sprite when different player hp
            switch (Life)
            {
                case 5:
                    //if player hp is 5, change the sprite to 0
                    GetComponent<SpriteRenderer>().sprite = spr[0];
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = spr[1];
                    break;
                case 10:
                    GetComponent<SpriteRenderer>().sprite = spr[2];
                    break;

            }
        if (Life <= 0)
        {
            Die();
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collied with different object, they have different effects
        if (collision.gameObject.CompareTag("Life"))
        {
            //if collied with staberry, player will gain life
            Life++;
            lifeText.text = "Life: " + Life;
            //set up the spawn position se when it is random each time item spawned
            Vector2 spawnPosition = Vector2.zero;
            spawnPosition.x = Random.Range(-11, 11);
            spawnPosition.y = Random.Range(-8, 8);
            //then destroy the cutrrent strabarry and instantiate a new one randomly on the scene
            Instantiate(Strabarry, spawnPosition, Quaternion.identity);
            Destroy(collision.gameObject);
           
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            //if collied with trap, player will gain life
            Life--;
            lifeText.text = "Life: " + Life;
            //the trap will stay on the scene
            Destroy(collision.gameObject);
            Debug.Log("life lost");
        }
 
        if (collision.gameObject.CompareTag("End"))
        {

            Die();

        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();
    }
    //how the game was reset was by loading the scence again
    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
