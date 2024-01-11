using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int gems = 0;
    private int coins = 0;
    [SerializeField] private Text gemsText;
    [SerializeField] private Text coinsText;
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gems++;
            gemsText.text = "Gems: " + gems;
            collectSound.Play();
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            collectSound.Play();
        }
    }
}
