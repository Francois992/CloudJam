using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    #region Script Parameters

    [Header("Octohorse Carac")]

    [SerializeField]
    private float octopusSpeed = 3f;

    [SerializeField]
    private float octopusMaxSpeed = 5f;

    [SerializeField]
    private float octopusMinSpeed = 2f;

    [SerializeField]
    private float invinsibleFrame = 0.75f;

    [SerializeField]
    private float cocoStun = 0.25f;

    [Header("Octohorse Bool")]

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ThrowThing thing = collision.gameObject.GetComponent<ThrowThing>();

        if (thing != null)
        {
            Destroy(collision.gameObject);
            switch (thing.GetEThrowType())
            {
                case eThrowType.COCONUT:
                    HitByCoconut();
                    break;
                default:
                    break;
            }
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
            Invoke("ResetSpeed", cocoStun);
        }
        else
        {
            isAlreadyStun = true;

            HitByTrap(0.7f);
            Invoke("ResetSpeed", 1);
        }

        isInvinsible = true;
        Invoke("ResetInvinsible", invinsibleFrame);
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
    }

    private void ResetInvinsible()
    {
        isInvinsible = false;
    }

    #endregion
}
