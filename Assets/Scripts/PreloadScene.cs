using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreloadScene : MonoBehaviour
{
    [SerializeField] float delayDime = 5f;
    void Start()
    {
        StartCoroutine(LoadMenu());
    }
    
    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(delayDime);
        SceneManager.LoadSceneAsync(1);
    }
}
