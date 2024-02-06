using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private int Life = 5;
    public GameObject Strabarry;
    public GameObject Trap;
    public Vector2 spawnPosition;


    [SerializeField] private Text lifeText;
    void Update()
    {
        Vector2 spawnPosition = Vector2.zero;
        spawnPosition.x = Random.Range(-11, 11);
        spawnPosition.y = Random.Range(-8, 8);
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Life"))
        {
            Life++;
            lifeText.text = "Life: " + Life;

            Instantiate(Strabarry, spawnPosition, Quaternion.identity);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Life--;
            lifeText.text = "Life: " + Life;
            Destroy(collision.gameObject);
            Instantiate(Trap);
            Debug.Log("life lost");
        }
    }


}
