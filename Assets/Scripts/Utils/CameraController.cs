using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;

    public void StartCamera(GameObject player)
    {
        if (player != null)
        {
            Debug.Log(playerCam);
            Transform playerTransform = player.transform;
            playerCam.LookAt = playerTransform;
            playerCam.Follow = playerTransform;
        }
    }
}