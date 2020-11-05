using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    #region Script Parameters

    [Header("Octohorse Carac")]

    [SerializeField]
    public float octopusSpeed = 3f;
    [SerializeField, Range(1, 10)] public int topSpeed = 5;
    //valeur de la stat :
    //1 => speed = minSpeed
    //10=> speed = maxSpeed

    [SerializeField, Range(0,2)] public int tenacity = 1;

    [SerializeField] public float panache = 3f;

    [SerializeField]
    private float octopusMaxSpeed = 5f;

    [SerializeField]
    private float octopusMinSpeed = 3f;

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
    private float tenacityPercent;

    private float ecartTopSpeed;
    private float timer = 0f;

    private bool isSlowed = false;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        //octopusSpeed = Random.Range(octopusMinSpeed, octopusMaxSpeed);
        //octopusSpeed = Mathf.Lerp(octopusMinSpeed, octopusMaxSpeed, (float)topSpeed / 10);
        octopusSpeed = octopusMinSpeed + (octopusMaxSpeed - octopusMinSpeed) * ((float)topSpeed - 1f) / (10 - 1); //Range de la top speed (1 et 10)
        ecartTopSpeed = (octopusMaxSpeed - octopusMinSpeed) * (2f / (10f - 1f));

        originalSpeed = octopusSpeed;

        switch (tenacity)
        {
            case 0:
                tenacityPercent = 2f;
                break;
            case 1:
                tenacityPercent = 1f;
                break;
            case 2:
                tenacityPercent = 0.5f;
                break;
        }
    }

    private void Update()
    {
        if (isSlowed) return;

        timer += Time.deltaTime;
        octopusSpeed = Mathf.Lerp(originalSpeed - ecartTopSpeed, originalSpeed + ecartTopSpeed, Mathf.Cos(timer));
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
        isSlowed = true;
        octopusSpeed *= (1 - Mathf.Clamp(0f, 100f, tenacityPercent * malusSpeed / 100));
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
        isSlowed = false;
    }

    private void ResetInvinsible()
    {
        isInvinsible = false;
    }

    #endregion
}
