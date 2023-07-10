using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour
{
    //public string Movie_Intro; 
    public string Tutorial; //Mientras la pelicula no este hecha, no cambien esto!!

    public void StartGame()
    {
        SceneManager.LoadScene(Tutorial); //Recuerden cambiar esto si pasaran a la pelicula :]
    }
}