using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnWin : GameLogicEnd
{
    private int sceneIndex;
    public AudioSource transitionSound;

    public new void Start()
    {
        base.Start();
        sceneIndex = (gameObject.scene.buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }

    public override void Won()
    {
        StartCoroutine(LoadSceneByIndex(sceneIndex));
    }

    IEnumerator LoadSceneByIndex(int index)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(index);
        load.allowSceneActivation = false;

        if (transitionSound != null)
        {
            transitionSound.Play(); // Joue le son
            yield return new WaitForSeconds(transitionSound.clip.length); // Attend la fin du son
        }
        Physics.gravity = new Vector3(0, -9.81f, 0); // Reinitialise la gravite
        load.allowSceneActivation = true;
    }

    // Transition vers une scène portant le nom du texte
    public void TransitionToSceneFromText(string sceneName)
    {
        if (sceneName != null)
        {
            StartCoroutine(LoadSceneByName(sceneName));
        }
        
    }

    IEnumerator LoadSceneByName(string sceneName)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);
        load.allowSceneActivation = false;

        if (transitionSound != null)
        {
            transitionSound.Play(); // Joue le son
            yield return new WaitForSeconds(transitionSound.clip.length); // Attend la fin du son
        }
        Physics.gravity = new Vector3(0, -9.81f, 0); // Reinitialise la gravite
        load.allowSceneActivation = true;
    }
}


        
