using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AssetReference scene;

    [SerializeField] TMP_Text highScoreText;
    void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.highScoreKey, 0);

        highScoreText.text = $"High Score: {highScore}";

        
    }
    public void StartGame()
    {
        //SceneManager.LoadScene(2);
        scene.LoadSceneAsync().Completed += SceneLoadComplete;
    }

    public void QuitGame()
    {
        Application.Quit();
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

    // Release asset when parent object is destroyed
    private void OnDestroy()
    {
        scene.ReleaseAsset();
    }
}
