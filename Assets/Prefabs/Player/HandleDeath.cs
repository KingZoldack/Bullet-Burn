using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    [SerializeField] Canvas _gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverCanvas.enabled = false;
    }

    public void HandlePlayerDeath()
    {
        _gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
