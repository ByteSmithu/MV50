using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{

    //On créer un entier pour conter le nombre de cube qui sont dans la bonne zone 
    private int checkEnd;

    //On instancie AudioSource pour pouvoir jouer un son à la réussite de l'énigme
    private AudioSource audioSource;


    void Start()
    {
        //On donne comme valeur à checkEnd le nombre de cube dans l'énigme
        checkEnd = 4;
        
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }


    //La fonction Increase augment de 1 la valeur de checkEnd si un cube sort de sa zone dédier 
    public void Increase()
    {
        checkEnd = checkEnd + 1;
        print(checkEnd);
    } 

    //La fonction Decrease diminue de 1 la valeur de checkEnd si un cube entre dans sa zone dédier 
    public void Decrease()
    {
        checkEnd = checkEnd - 1;
        print(checkEnd);
    }

    //A chaque fois qu'un cube entre dans la bonne zonne, on vérifie la valeur de checkEnd, si il est nul cela veut dire que l'énigme est réussie 
    public void ifWin()
    {
        if (checkEnd == 0)
        {
            audioSource.Play(0);
            print(checkEnd);
            print("win");
        }       
    }
}
