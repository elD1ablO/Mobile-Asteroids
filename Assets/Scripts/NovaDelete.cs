using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaDelete : MonoBehaviour
{
    [SerializeField] float deleteTime = 2;
    void Start()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
