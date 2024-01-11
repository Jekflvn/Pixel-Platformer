using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource restartSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy")){
            Die();
        } 
        if(collision.gameObject.CompareTag("Border")){
            Die();
        }
    }

    private void Die(){
        deathSound.Play();
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }
    
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartSound.Play();
    }
}
