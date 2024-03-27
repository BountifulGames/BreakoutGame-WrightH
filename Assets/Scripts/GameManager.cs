using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int bricks;
    public float resetDelay = 1f;
    public TMP_Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    [SerializeField] private List<GameObject> bricksPrefabs = new List<GameObject>();
    public GameObject paddle;
    private GameObject clonePaddle;
    [SerializeField] private int sceneNum;

    private static GameManager _instance;
    public static GameManager Instance 
    { 
        get 
        { 
            return _instance; 
        } 
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }


        sceneNum = 0;
    }

    private void Start()
    {
        Setup();

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextScene();
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Debug.Log("OnSceneLoaded: " + scene.name);

        Setup();

    }
    public void Setup()
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            lives = 3;
            livesText.text = "Lives: " + lives;
        }

        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
        Instantiate(bricksPrefabs[sceneNum], transform.position, Quaternion.identity);
        bricks = bricksPrefabs[sceneNum].transform.childCount;

        youWon.SetActive(false);
        gameOver.SetActive(false);

    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            if (sceneNum < 3)
            {
                lives++;
            }
            Invoke("LoadNextScene", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);

        }
    }
    void Reset()
    {
        Time.timeScale = 1f;
        sceneNum = 0;
        SceneManager.LoadScene("Level1");
    }

    private void LoadNextScene()
    {
        sceneNum++;
        sceneNum = Mathf.Clamp(sceneNum++, 0, 2);
        SceneManager.LoadScene(sceneNum);
    }
    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }
    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
