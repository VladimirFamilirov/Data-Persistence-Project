using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Navigation : MonoBehaviour
{
    public TMP_InputField inputField;
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void StartButton()
    {
        GetInputName();
        SceneManager.LoadScene(1);
    }
   public void GetInputName()
    {
        ScoreManager.Instance.BestScoreName = inputField.text ?? "";
    }
}
