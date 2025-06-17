using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{

    //On créer un entier pour conter le nombre de cube qui sont dans la bonne zone 
    public int trialNumber;

    private static int forEnd;

    public GameObject correctTrigger;

    //On instancie AudioSource pour pouvoir jouer un son à la réussite de l'énigme
    private AudioSource sound;

    public ChangeSceneOnWin changeScene; 

    void Start()
    {
        //On donne comme valeur à forEnd le nombre de cube dans l'énigme

        sound = gameObject.GetComponent<AudioSource>();
        forEnd += 1;
    }


    //La fonction Increase augment de 1 la valeur de forEnd si un cube sort de sa zone dédier 
    public void Increase()
    {
        forEnd = forEnd + 1;
    }

    //La fonction Decrease diminue de 1 la valeur de forEnd si un cube entre dans sa zone dédier 
    public void Decrease()
    {
        forEnd = forEnd - 1;
    }

    //A chaque fois qu'un cube entre dans la bonne zonne, on vérifie la valeur de forEnd, si il est nul cela veut dire que l'énigme est réussie 
    public void checkWin()
    {
        if (forEnd == 0)
        {
            sound.Play(0);
            StartCoroutine(endingLevel());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == correctTrigger.name)
        {
            Debug.Log(other.gameObject.name);
            Decrease();
            checkWin();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == correctTrigger.name)
        {
            Increase();
        }
    }
    
        private IEnumerator endingLevel()
    {
        yield return new WaitForSeconds(sound.clip.length + 2);
        changeScene.Won();
    }

}
