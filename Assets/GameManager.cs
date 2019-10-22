using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}