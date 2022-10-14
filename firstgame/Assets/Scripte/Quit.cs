using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
    public class Quit : MonoBehaviour
{
    public void QuitButton()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}