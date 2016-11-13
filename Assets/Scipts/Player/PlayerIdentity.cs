using UnityEngine;
using System.Collections;

public class PlayerIdentity : MonoBehaviour
{
    [Header("Player number")]
    public int playerIndex;
    public string playerName;

    [Header("Skin")]
    public Color color;
    public Texture lazerColor;
}
