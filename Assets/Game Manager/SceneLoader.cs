using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int _currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(_currentSceneIndex);
        Time.timeScale = 1;
    }
}
