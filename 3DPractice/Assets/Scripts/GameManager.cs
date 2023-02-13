using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public float restartDelay = 1f;
    public GameObject startScreen;
    public GameObject player;

    private void Awake()
    {

        startScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (gameOver)
        {
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<Movement>().enabled = false;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                gameOver = false;
                startScreen.GetComponent<Animator>().SetTrigger("start");
                player.GetComponent<Player>().enabled = true;
                player.GetComponent<Movement>().enabled = true;
            }
        }
    }

    public void EndGame()
    {
        if(gameOver) return;
        gameOver = true;
        Invoke("Restart", restartDelay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
