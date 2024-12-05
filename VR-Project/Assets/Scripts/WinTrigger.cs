using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("player entered");
            SceneManager.LoadScene(sceneName);
        }
    }
}
