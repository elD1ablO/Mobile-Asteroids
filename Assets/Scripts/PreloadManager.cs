using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PreloadManager : MonoBehaviour
{
    // Assign in Editor
    public AssetReference scene;

    // Start the load operation on start
    void Start()
    {
        scene.LoadSceneAsync().Completed += SceneLoadComplete;
    }

    // Instantiate the loaded prefab on complete

    private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
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
