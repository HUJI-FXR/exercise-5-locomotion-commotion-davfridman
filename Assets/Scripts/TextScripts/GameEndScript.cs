using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEndScript : MonoBehaviour
{
    public static GameEndScript Instance {get; private set;}
    private TMPro.TextMeshProUGUI endGameText;
    [SerializeField] GameObject endGamePlane;
    private bool gameEnded = false;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the instance
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        endGameText = GetComponent<TMPro.TextMeshProUGUI>();
        endGameText.gameObject.SetActive(false);
        endGamePlane.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                ResetGame();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                QuitGame();
            }
        }
    }

    public void GameEnded(bool win)
    {
        gameEnded = true;
        ScoreScript.Instance.GameEnded();
        Image endTint = endGamePlane.GetComponent<Image>();
        if(win)
        {
            endTint.color = new Color(0,1f,0,0.3f);
            endGameText.color = Color.green;
            endGameText.text = "! YOU WIN !";
        }
        else
        {
            endTint.color = new Color(1f,0,0,0.3f);
            endGameText.color = Color.red;
            endGameText.text = "! YOU LOSE !";
        }
        endGameText.text += "\nRestart the game: Y/N";
        endGameText.gameObject.SetActive(true);
        endGamePlane.SetActive(true);
        Time.timeScale = 0f;
    }

    void ResetGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
