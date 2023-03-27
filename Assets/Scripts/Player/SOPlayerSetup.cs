using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Movement")]
    public float speed = 10f;
    public float speedRun = 20f;
    public float forceJump = 20f;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
}
