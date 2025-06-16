using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnWin : GameLogicEnd
{
    private int sceneIndex;

    public new void Start()
    {
        base.Start();
        sceneIndex = (gameObject.scene.buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }
        
    public override void Won()
    {
        StartCoroutine(LoadScene());
        StartCoroutine(WaitAndActivateScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneIndex);

        while (!load.isDone)
        {
            yield return null;
        }
        StartCoroutine(WaitAndActivateScene());
    }

    IEnumerator WaitAndActivateScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }
}
