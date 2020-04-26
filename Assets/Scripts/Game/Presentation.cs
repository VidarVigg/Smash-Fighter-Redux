using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Presentation : MonoBehaviour
{

    public TextMeshProUGUI presentationText;
    public TextMeshProUGUI headLines;

    [TextArea]
    [SerializeField]
    private string[] presentationTexts;

    [SerializeField]
    private string[] headlineTexts;

    private int index;
    private int headlineIndex;

    [SerializeField]
    int headlinePoint0;
    [SerializeField]
    int headlinePoint1;
    [SerializeField]
    int headlinePoint2;




    void Start()
    {
        index = -1;
        headlineIndex = -1;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            index++;
            if (index < presentationTexts.Length)
            {

                presentationText.text = presentationTexts[index];
            }
            if (index >= presentationTexts.Length)
            {
                SceneManager.LoadScene("SampleScene");
            }



            if (index == headlinePoint0)
            {
                headLines.text = headlineTexts[0];
            }
            else if (index == headlinePoint1)
            {

                headLines.text = headlineTexts[1];
            }
            else if (index == headlinePoint2)
            {

                headLines.text = headlineTexts[2];
            }
        }
    }
}
