using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    void Start()
    {
        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //load scene
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //quit game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player HAS quit THE game");
    }
}
