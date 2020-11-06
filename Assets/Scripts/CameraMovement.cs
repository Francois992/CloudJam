using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Script Parameters

    [Header("Camera Carac")]

    [SerializeField]
    public float cameraSpeed = 3.5f;

    [SerializeField]
    public bool cameraCanMove = false;

    #endregion

    #region Unity Methods

    private void FixedUpdate()
    {
        if(cameraCanMove)
        transform.Translate(Vector3.right * cameraSpeed * Time.fixedDeltaTime);
    }

    #endregion
}
