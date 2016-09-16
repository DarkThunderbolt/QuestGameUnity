using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StartMenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject ResMenu;

    public GameObject menu;

    private enum MenuStates { Main, Option, Resolution };
    private MenuStates currentState;
    private int newHight = 768;
    private int newWidth = 1280;

    private float resetTime;
    public bool isShowing;

    void Awake()
    {
        resetTime = Time.timeScale;
        currentState = MenuStates.Main;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "1")
            isShowing = false;
        else
            isShowing = true;
        menu.SetActive(isShowing);
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "1")
        {
            ShowHide();
        }
        if(isShowing)
        switch (currentState)
        {
            case MenuStates.Main:
                OptionMenu.SetActive(false);
                ResMenu.SetActive(false);
                MainMenu.SetActive(true);
                break;

            case MenuStates.Option:
                MainMenu.SetActive(false);
                ResMenu.SetActive(false);
                OptionMenu.SetActive(true);
                break;

            case MenuStates.Resolution:
                MainMenu.SetActive(false);
                OptionMenu.SetActive(false);
                ResMenu.SetActive(true);
                break;
        }

    }


    public void ShowHide()
    {
        isShowing = !isShowing;
        menu.SetActive(isShowing);
        if (isShowing)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = resetTime;
        }
    }

	public void OnStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainStreetScene");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }

    public void OnOption()
    {
        currentState = MenuStates.Option;
    }

    public void OnResolutionMenu()
    {
        currentState = MenuStates.Resolution;
    }

    public void on800()
    {
        newHight = 600;
        newWidth = 800;
    }

    public void on1280()
    {
        newHight = 768;
        newWidth = 1280;
    }

    public void on1920()
    {
        newHight = 1080;
        newWidth = 1920;
    } 

    public void OnResolutionSet()
    {
        Screen.SetResolution( newWidth, newHight, Screen.fullScreen);
        currentState = MenuStates.Option;
    }

    public void OnWindowed()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void OnMainManu()
    {
        currentState = MenuStates.Main;
    }
}
