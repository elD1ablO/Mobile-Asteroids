using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    private AsyncOperation _asyncOp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsynchronousLoad(0));
    }

    private IEnumerator AsynchronousLoad(int scene)
    {
        yield return new WaitForSeconds(0.1f);

        Application.backgroundLoadingPriority = ThreadPriority.High;

        _asyncOp = SceneManager.LoadSceneAsync(scene);
        _asyncOp.allowSceneActivation = false;
        while (!_asyncOp.isDone)
        {
            if (Mathf.Approximately(_asyncOp.progress, 0.9f))
            {
                _asyncOp.allowSceneActivation = true;
            }
            yield return null;
        }

        Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;

        yield return new WaitForEndOfFrame();
        yield return null;
    }
}
