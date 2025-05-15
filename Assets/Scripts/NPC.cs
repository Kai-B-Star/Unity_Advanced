using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueTree dialogueOnClick;
    [SerializeField] private Collider2D collide;
    private void OnMouseDown()
    {
        DialogueManager.instance.BeginDialogue(dialogueOnClick);
        collide.enabled = false;
    }
}
