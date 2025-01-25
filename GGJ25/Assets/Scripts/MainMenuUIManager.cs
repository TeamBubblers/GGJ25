using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{

    [SerializeField]
    private string GameScene;

    [SerializeField]
    private GameObject HowTo;

    [SerializeField]
    private GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        HowTo.SetActive(false);
        credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void HowToButton()
    {
        HowTo.SetActive(true);
    }

    public void ReturnFromHowTo()
    {
        HowTo.SetActive(false);
    }

    public void ReturnFromCredits()
    {
        credits.SetActive(false);
    }


}
