using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene");
    }
}
