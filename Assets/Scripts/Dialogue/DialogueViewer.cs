//Credit to Matthew Ventures on Youtube for providing free resources and tutorials on how to use Twine with Unity!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogueObject;
using UnityEngine.Events;
using System;
using System.Runtime.InteropServices;
using TMPro;

public class DialogueViewer : MonoBehaviour
{
    //[SerializeField] Transform parentOfResponses;
    [SerializeField] Button prefab_btnResponse;
    [SerializeField] TextMeshProUGUI txtNodeDisplay;
    [SerializeField] DialogueController dialogueController;
    [SerializeField] GameObject NodeDisplayBG;
    DialogueController controller;
    Button newButton;

    [DllImport("__Internal")]
    private static extern void openPage(string url);

    public void Start()
    {
        this.GetComponent<Canvas>().enabled = false;
    }

    public void npc1()
    {
        controller = dialogueController;
        controller.onEnteredNode += OnNodeEntered;

        controller.InitializeDialogue(1);
        // Start the dialogue
        var curNode = controller.GetCurrentNode();
    }

    public void npc2()
    {
        controller = dialogueController;
        controller.onEnteredNode += OnNodeEntered;

        controller.InitializeDialogue(2);
        // Start the dialogue
        var curNode = controller.GetCurrentNode();
    }

    public void npc3()
    {
        controller = dialogueController;
        controller.onEnteredNode += OnNodeEntered;

        controller.InitializeDialogue(3);
        // Start the dialogue
        var curNode = controller.GetCurrentNode();
    }

    public void viewerEndDialogue()
    {
        Destroy(newButton);
    }

    public static void KillAllChildren(UnityEngine.Transform parent)
    {
        UnityEngine.Assertions.Assert.IsNotNull(parent);
        for (int childIndex = parent.childCount - 1; childIndex >= 0; childIndex--)
        {
            UnityEngine.Object.Destroy(parent.GetChild(childIndex).gameObject);
        }
    }

    private void OnNodeSelected(int indexChosen)
    {
        //Debug.Log("Chose: " + indexChosen);
        controller.ChooseResponse(indexChosen);
    }

    private void OnNodeEntered(Node newNode)
    {
        txtNodeDisplay.text = newNode.text;
    }
}