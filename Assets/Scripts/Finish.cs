using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool finished = false;
    [SerializeField] private AudioSource finishSound;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(!finished){
            if (collision.gameObject.name == "Player"){
                finished = true;
                finishSound.Play();
                Invoke("CompleteLevel", 2f);
            
            }
        }
        
    }

    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
