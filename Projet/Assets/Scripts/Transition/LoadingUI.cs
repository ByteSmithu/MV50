using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class LoadingUI : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public Slider progressBar;
    public float delayBeforeStart; // Temps d’attente en secondes
    public ChangeSceneOnWin changeScene; 

    void Start()
    {
        StartCoroutine(LoadProgress());
    }

    IEnumerator LoadProgress()
    {
        loadingText.text = "Préparation...";
        yield return new WaitForSeconds(delayBeforeStart); // Attente avant de commencer

        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime * 0.2f;
            int percent = Mathf.RoundToInt(progress * 100f);
            loadingText.text = "Chargement... " + percent + "%";

            if (progressBar != null)
                progressBar.value = progress;

            yield return null;
        }

        loadingText.text = "Chargement terminé !";
        changeScene.Won();
    }
}
