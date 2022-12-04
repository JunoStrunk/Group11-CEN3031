//Credit to Matthew Ventures on Youtube for providing free resources and tutorials on how to use Twine with Unity!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class DialogueController : MonoBehaviour
{

    [SerializeField] TextAsset NPC1;
    [SerializeField] TextAsset NPC2;
    [SerializeField] TextAsset NPC3;
    Dialogue curDialogue;
    Node curNode;

    public delegate void NodeEnteredHandler(Node node);
    public event NodeEnteredHandler onEnteredNode;

    public Node GetCurrentNode()
    {
        return curNode;
    }

    public void InitializeDialogue(int npc)
    {
        switch(npc)
        {
            case 1:
                curDialogue = new Dialogue(NPC1);
                break;
            case 2:
                curDialogue = new Dialogue(NPC2);
                break;
            case 3:
                curDialogue = new Dialogue(NPC3);
                break;
            default:
                curDialogue = new Dialogue(NPC1);
                break;
        }
        curNode = curDialogue.GetStartNode();
        onEnteredNode(curNode);
    }

    public List<Response> GetCurrentResponses()
    {
        return curNode.responses;
    }

    public void ChooseResponse(int responseIndex)
    {
        string nextNodeID = curNode.responses[responseIndex].destinationNode;
        Node nextNode = curDialogue.GetNode(nextNodeID);
        curNode = nextNode;
        onEnteredNode(nextNode);
    }
}
