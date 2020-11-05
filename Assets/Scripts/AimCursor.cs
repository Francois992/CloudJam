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

    [Header("Throwing Things")]

    [SerializeField]
    private GameObject coconutThing;
    [SerializeField]
    private float coconutCD = 1f;

    #endregion

    #region Fields

    private float xPos;
    private float yPos;

    private Rewired.Player playerController;

    private bool canThrowCoconut = true;

    #endregion

    #region Unity Methods

    private void Start()
    {
        SetPlayer(GameManager.instance.Players[0]);
    }

    private void FixedUpdate()
    {
        xPos = playerController.GetAxis("MoveHorizontal");
        yPos = playerController.GetAxis("MoveVertical");

        transform.Translate(new Vector2(xPos, yPos) * aimSpeed * Time.fixedDeltaTime);

        if (playerController.GetButton("AButton") && canThrowCoconut)
        {
            ThrowCoconut();
        }
    }

    #endregion

    public void SetPlayer(Player playerToSet)
    {
        player = playerToSet;
        playerController = player.playerController;
    }

    #region Throw things

    private void ThrowCoconut()
    {
        canThrowCoconut = false;

        float xCocoPos = transform.position.x;
        float yCocoPos = transform.position.y;

        GameObject coco = Instantiate(coconutThing, new Vector2(xCocoPos, yCocoPos), Quaternion.identity);
        coco.transform.parent = null;

        Destroy(coco, 0.5f);
        Invoke("CoconutCD", coconutCD);
    }

    private void CoconutCD()
    {
        canThrowCoconut = true;
    }

    #endregion
}
