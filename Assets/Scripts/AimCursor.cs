using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCursor : MonoBehaviour
{
    #region Script Parameters

    public SpriteRenderer sprite;

    [SerializeField]
    public Color p1Color = new Color(36, 130, 255);
    public Color p2Color = new Color(5, 255, 10);
    public Color p3Color = new Color(255, 235, 30);
    public Color p4Color = new Color(255, 25, 25);

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

        SetColor();
    }

    private void SetColor()
    {
        switch (player.playerId)
        {
            case 0:
                sprite.color = p1Color;
                break;
            case 1:
                sprite.color = p2Color;
                break;
            case 2:
                sprite.color = p3Color;
                break;
            case 3:
                sprite.color = p4Color;
                break;
        }
    }

    private void FixedUpdate()
    {
        xPos = playerController.GetAxis("MoveHorizontal");
        yPos = playerController.GetAxis("MoveVertical");

        transform.Translate(new Vector2(xPos, yPos) * aimSpeed * Time.fixedDeltaTime);

        if (GameManager.instance.IsRacing)
        {
            if (playerController.GetButton("AButton") && canThrowCoconut)
            {
                ThrowCoconut();
                Hud.instance.cocoFills[player.playerId].gameObject.SetActive(true);
                Hud.instance.cocoFills[player.playerId].fillAmount = 0;
            }

            if (playerController.GetButton("BButton"))
            {
                Debug.LogError("B !!!");
                GameManager.instance.OctoHorses[0].canBreathAgain = true;
                GameManager.instance.OctoHorses[0].ActiveSecondBreath();
            }
        }
    }

    #endregion

    public void SetPlayer(Player playerToSet)
    {
        player = playerToSet;
        playerController = player.playerController;

        SetColor();
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
