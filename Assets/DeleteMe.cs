using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale *= 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Time.timeScale *= 2f;
           
        }
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
