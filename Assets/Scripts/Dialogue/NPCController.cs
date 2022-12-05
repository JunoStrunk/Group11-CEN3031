using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] DialogueViewer viewer;
    [SerializeField] Lush_Bounds_Behavior lushBounds;
    bool entered = false;
    enum NPC
    {
        One,
        Two,
        Three
    };
    
    [SerializeField]
    NPC npc = new NPC();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch(npc)
            {
                case NPC.One:
                    viewer.npc1();
                    break;
                case NPC.Two:
                    viewer.npc2();
                    break;
                case NPC.Three:
                    viewer.npc3();
                    break;
                default:
                    viewer.npc1();
                    break;
            }

            viewer.GetComponent<Canvas>().enabled = true;

            Debug.Log(entered);
            if (!entered) //if we haven't entered yet
            {
                lushBounds.expandLush();
                entered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            viewer.GetComponent<Canvas>().enabled = false;
        }
    }
}
