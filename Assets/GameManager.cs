using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    private bool paused;

    private void Awake()
    {
        if (INSTANCE)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            INSTANCE = this;
        }

        ServiceLocator.Initialize();
        ServiceLocator.AudioService = FindObjectOfType<AudioServiceProvider>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("TutorialSceneAfter");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
            {
               
                Time.timeScale = 0f;
                paused = true;

            }
            else
            {
                Time.timeScale = 1;
                paused = false;
            }
        }
    }
}