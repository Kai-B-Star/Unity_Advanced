using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueTree")]
public class DialogueTree : ScriptableObject
{
    [SerializeField] private string[] messages;

    public string[] Messages { get => messages; }
}
