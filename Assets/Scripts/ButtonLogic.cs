using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
    public void PlayButtonOnPress(){
        SceneManager.LoadScene(1);
    }

    public void ExitButtonOnPress(){
        Application.Quit();
    }
}
