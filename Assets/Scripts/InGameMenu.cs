using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]AssetReference scene;

    [SerializeField] GameObject player;    

    [SerializeField] Button continueButton;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] AsteroidSpawner asteroidSpawner;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        int finalScore = scoreSystem.StopScoreCount();
        gameOverText.text = $"Your score: {finalScore}";

        gameOverCanvas.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
        scene.LoadSceneAsync().Completed += SceneLoadComplete;
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        continueButton.interactable = false;
        gameOverCanvas.gameObject.SetActive(false);

        scoreSystem.StartTimer();

        asteroidSpawner.enabled = true;   
        
    }
    void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            // Set our reference to the AsyncOperationHandle (see next section) Debug.Log(obj.Result.Scene.name + " successfully loaded."); // (optional) do more stuff } }
            Debug.Log(obj.Result.Scene.name + " successfully loaded.");
            // (optional) do more stuff
        }
    }
    private void OnDestroy()
    {
        scene.ReleaseAsset();
    }

}
