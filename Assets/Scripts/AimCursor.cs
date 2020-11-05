﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCursor : MonoBehaviour
{
    #region Script Parameters

    public SpriteRenderer sprite;

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
        SetPlayer(player);

        switch (player.playerId)
            {
            case 0:
                sprite.color = Color.blue;
                break;

            case 1:
                sprite.color = Color.green;
                break;
            case 2:
                sprite.color = Color.red;
                break;
            case 3:
                sprite.color = Color.yellow;
                break;

        }
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
