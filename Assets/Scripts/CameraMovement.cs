using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Script Parameters

    [Header("Octohorse Carac")]

    [SerializeField]
    private float cameraSpeed = 3.5f;

    #endregion

    #region Unity Methods

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * cameraSpeed * Time.fixedDeltaTime);
    }

    #endregion
}
