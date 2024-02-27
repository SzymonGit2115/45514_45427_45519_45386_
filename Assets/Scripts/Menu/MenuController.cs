using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private float timeScale;

    [Header("Menu")]
    public bool Menu = true;
    [SerializeField] GameObject MenuPanel;

    [Header("Pause")]
    public bool Pause = true;
    [SerializeField] GameObject PausePanel;

    [Header("Options")]
    public bool Options = true;
    [SerializeField] GameObject OptionsPanel;

    [Header("Exit")]
    public bool Exit = true;
    [SerializeField] TextMeshProUGUI exitTMP;
    private string exitText = "Are you sure?";

    [Header("Credits")]
    public bool Credits = true;
    [SerializeField] GameObject CreditsPanel;

    void Start()
    {

        if(Menu)
            MenuPanelStart(Menu, 0);
        else if(!Menu) 
            MenuPanelStart(Menu, 1);

        
    }
    
    public void BackToMenuButton()
    {
        Menu = true;
        Pause= false;
        MenuPanelStart(true,0);
    }

    private void MenuPanelStart(bool boolean, int time)
    {
        MenuPanel.SetActive(boolean);
        PausePanel.SetActive(false);
        Time.timeScale = time;


    }

    void Update()
    {
        timeScale= Time.timeScale;

        if(Input.GetKeyUp(KeyCode.Escape) && !Menu) 
        {
            if (Pause)
            PauseButton(false, 1);
            else if(!Pause)
            PauseButton(true, 0);
        }
        
    }

    public void PauseButtonUI()
    {
        PauseButton(false, 1);
    }


    public void PauseButton(bool boolean, int time)
    {
        Time.timeScale = time;
        PausePanel.SetActive(boolean);
        Pause =boolean;
    }



    public void PlayMenuButton()
    {
        Menu = false;
        MenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        if(!Exit) 
        {
            
            StartCoroutine(ExitWait());
        }
        else if(Exit)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

    }

    private float waitTiExit = 3.5f;
    IEnumerator ExitWait()
    {
        exitTMP.text = exitText;
        Exit = true;

        yield return new WaitForSecondsRealtime(waitTiExit);
        exitTMP.text = "Exit";
        Exit = false;

    }

}
