using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    [SerializeField] private InputManager inputManager;
    [SerializeField] private MovementManager player;

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
        Initialize();
    }

    void Initialize()
    {

        ServiceLocator.Initialize();
        ServiceLocator.TimerService = FindObjectOfType<TimerProvider>();

    }
}
