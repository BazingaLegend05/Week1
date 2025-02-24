using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] string playScene = "PlayerSandboxScene";
    [SerializeField] string mainMenuScene = "StartScene";
    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(playScene);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}