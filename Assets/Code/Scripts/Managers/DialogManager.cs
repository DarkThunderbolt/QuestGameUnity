using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogWindow;
    public Text dialogText;
    public Text speakerName;
    public Image leftSpeakerImage;
    public Image rightSpeakerImage;

    private Replica currentReplica;
    private Dialogue currentDialog;
    private int currentLine;
    private bool dialogGo = false;
    private float resetTime;

	void Update ()
    {
        if(dialogGo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(currentLine < currentDialog.Replicas.Capacity-1)
                {
                    currentLine++;
                    SetNewReplica();
                }
                else
                {
                    dialogGo = false;
                    dialogWindow.SetActive(false);
                    Time.timeScale = resetTime;
                }
            }
        }
    }

    private void SetNewReplica()
    {
        currentReplica = currentDialog.Replicas[currentLine];
        dialogText.text = currentReplica.TextOfReplica;
        speakerName.text = currentReplica.NameOfCharacter;
        if(currentReplica.LeftPlace)
        {
            leftSpeakerImage.enabled = true;
            rightSpeakerImage.enabled = false;
            leftSpeakerImage.sprite = Resources.Load<Sprite>(currentReplica.ImageOfReplica);
        }
        else
        {
            leftSpeakerImage.enabled = false;
            rightSpeakerImage.enabled = true;
            rightSpeakerImage.sprite = Resources.Load<Sprite>(currentReplica.ImageOfReplica);
        }
    }

    public void GetDialog(Dialogue newDialog)
    {
        currentDialog = newDialog;
        SetNewReplica();
        currentLine = 0;
        resetTime = Time.timeScale;
        Time.timeScale = 0;
        dialogGo = true;
        dialogWindow.SetActive(true);
    }
}
