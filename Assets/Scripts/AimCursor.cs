using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCursor : MonoBehaviour
{
    #region Script Parameters

    [SerializeField]
    private Player player;

    [SerializeField]
    private float aimSpeed = 1.5f;

    #endregion

    #region Fields

    private float xPos;
    private float yPos;

    private Rewired.Player playerController;

    #endregion

    #region Unity Methods

    private void FixedUpdate()
    {
        xPos = playerController.GetAxis("MoveHorizontal");
        yPos = playerController.GetAxis("MoveVertical");

        transform.Translate(new Vector2(xPos, yPos) * aimSpeed * Time.fixedDeltaTime);
    }

    #endregion

    public void SetPlayer(Player playerToSet)
    {
        player = playerToSet;
        playerController = player.playerController;
    }
}
