using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextMenager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool started;

    // Use this for initialization
    void Start()
    {
        textBox.SetActive(false);

        currentLine = 0;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (currentLine >= endAtLine)
                {
                    textBox.SetActive(false);
                    currentLine = 0;
                    started = false;
                }
                else
                {
                    theText.text = textLines[currentLine++];
                }
            }
        }
    }

    public void SetStart()
    {
        started = true;
        textBox.SetActive(true);
        theText.text = textLines[currentLine++];
    }
}
