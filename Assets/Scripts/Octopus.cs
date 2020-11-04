using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    #region Script Parameters

    [Header("Octohorse Carac")]

    [SerializeField]
    public float octopusSpeed = 3f;

    [SerializeField]
    public float tenacity = 3f;

    [SerializeField]
    public float panache = 3f;

    [SerializeField]
    private float octopusMaxSpeed = 5f;

    [SerializeField]
    private float octopusMinSpeed = 2f;

    [SerializeField]
    private float invinsibleFrame = 0.75f;

    [SerializeField]
    private bool canRun = false;

    [SerializeField]
    private bool isInvinsible = false;

    [SerializeField]
    private bool isAlreadyStun = false;

    #endregion

    #region Fields

    private float originalSpeed;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        octopusSpeed = Random.Range(octopusMinSpeed, octopusMaxSpeed);
        originalSpeed = octopusSpeed;
    }

    private void FixedUpdate()
    {
        if (canRun)
        {
            transform.Translate(Vector3.right * octopusSpeed * Time.fixedDeltaTime);
        }
    }

    #endregion

    public void HorseCanRun(bool nowRun)
    {
        canRun = nowRun;
    }

    #region Hit By

    public void HitByCoconut()
    {
        if (isInvinsible)
        {
            return;
        }

        if (isAlreadyStun)
        {
            octopusSpeed = 0;
            Invoke("ResetSpeed", 1);

            isInvinsible = true;
        }
        else
        {
            isAlreadyStun = true;

            HitByTrap(0.7f);
            Invoke("ResetSpeed", 2);
        }
    }

    public void HitByTrap(float malusSpeed)
    {
        if (isInvinsible)
        {
            return;
        }

        octopusSpeed *= malusSpeed;
    }

    public void HitByProjectile(float malusSpeed)
    {
        if (isInvinsible)
        {
            return;
        }

        octopusSpeed *= malusSpeed;

        Invoke("ResetSpeed", 2);
    }

    #endregion

    #region Reset

    public void ResetSpeed()
    {
        isAlreadyStun = false;
        octopusSpeed = originalSpeed;

        if (isInvinsible)
        {
            Invoke("ResetInvinsible", invinsibleFrame);
        }
    }

    private void ResetInvinsible()
    {
        isInvinsible = false;
    }

    #endregion
}
