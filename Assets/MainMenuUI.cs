using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private RectTransformMover menuPanel;

    private Vector3 inactivePosition = Vector3.left * 1080;
    private Vector3 activePosition = Vector3.zero;

    public void ButtonClickEventStart()
    {
      //Debug.Log("Game Start");
      menuPanel.MoveTo(AfterStartEvent, inactivePosition);
    }

    private void AfterStartEvent()
    {
      //Debug.Log("Game Start");
      stageController.IsGameStart = true;
    }

    public void ButtonClickEventReset()
    {
      Debug.Log("Reset Stage");
    }

    public void ButtonClickEventExit()
    {
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;

      #else
      Application.Quit();
      #endif
    }

    public void StageExit()
    {
      menuPanel.MoveTo(AfterStageExitEvent, activePosition);
    }

    private void AfterStageExitEvent()
    {
      SceneManager.LoadScene(0);
    }
}
