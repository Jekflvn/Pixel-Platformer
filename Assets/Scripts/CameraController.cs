using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float timeOffset;
    [SerializeField] private Vector2 posOffset;

    private Vector3 velocity;

    private void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);
        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
    }
}
