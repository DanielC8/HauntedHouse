using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{

    //attach it to play button, plays the game
    public void StartScene()
    {
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("MainScene");
    }

    //attach to exit button, exits game
    public void ExitGame()
    {
        SoundManager.Instance.PlayButton();
        Application.Quit();
    }
}
