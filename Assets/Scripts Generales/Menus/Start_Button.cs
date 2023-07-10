using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour
{
    public string Movie_Intro; 

    public void StartGame()
    {
        SceneManager.LoadScene(Movie_Intro); 
    }
}