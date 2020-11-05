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

    [Header("Second Souffle")]

    [SerializeField]
    private float secondBreathCheckDelay = 2f;

    [SerializeField]
    private float secondBreathSpeedBonus = 1.25f;

    [SerializeField]
    private float secondBreathDuration = 1f;

    [SerializeField]
    private float secondBreathBaseChance = 1f;

    [SerializeField]
    private List<float> secondBreathPositionBonus = new List<float>() { 0f, 3f, 5f, 8f };

    [Header("Second Souffle - Rage")]

    [SerializeField]
    private float secondBreathRage = 0f;

    [SerializeField]
    private float secondBreathRageMax = 3f;

    [SerializeField]
    private float secondBreathRageDecrease = 0.5f;

    [SerializeField]
    private float secondBreathRageDecreaseDelay = 1f;

    [SerializeField]
    private float secondBreathRageBonusByCoco = 0.75f;

    [Header("Second Souffle - Tension")]

    [SerializeField]
    private float secondBreathTension = 0f;

    [SerializeField]
    private float secondBreathTensionMax = 3f;

    [SerializeField]
    private float secondBreathTensionIncrease = 0.75f;

    [SerializeField]
    private float secondBreathTensionIncreaseDelay = 1f;

    [SerializeField]
    private float secondBreathTensionDecrease = 1f;

    [SerializeField]
    private float secondBreathTensionDecreaseDelay = 1f;

    #endregion

    #region Fields

    private int horsePosition = 4;

    private float originalSpeed;
    private float tenacityPercent;

    private bool canBreathAgain = true;

    private bool isCheckingSecondBreath = false;
    private float currentSecondBreathCheckTimer = 0;
    private float currentRageTimer = 0;

    private bool tensionDecrease = false;
    private float currentTensionIncreaseTimer = 0;
    private float currentTensionDecreaseTimer = 0;
    private float ecartTopSpeed;
    private float timer = 0f;

    private bool isSlowed = false;

    [HideInInspector] public BetManager.HorseAttribute attribute;
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

            currentSecondBreathCheckTimer += Time.fixedDeltaTime;

            if (canBreathAgain && !isCheckingSecondBreath)
            {
                CheckIfBreathAgain();
            }

            currentRageTimer += Time.fixedDeltaTime;

            CheckRageTimer();

            CheckPosition();

            if (tensionDecrease)
            {
                currentTensionDecreaseTimer += Time.fixedDeltaTime;
                CheckTensionIncreaseTimer();
            }
            else
            {
                currentTensionIncreaseTimer += Time.fixedDeltaTime;
                CheckTensionDecreaseTimer();
            }
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

    private void CheckPosition()
    {
        if (horsePosition == 3 || horsePosition == 4)
        {
            tensionDecrease = false;
        }
        else
        {
            tensionDecrease = true;
        }
    }

    public void SetPosition(int position)
    {
        horsePosition = position;

        CheckPosition();
    }

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

        ResetRageTimer();
        secondBreathRage = Mathf.Clamp(secondBreathRage + secondBreathRageBonusByCoco, 0, secondBreathRageMax);

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

    #region Second Souffle

    private void CheckIfBreathAgain()
    {
        if (currentSecondBreathCheckTimer >= secondBreathCheckDelay)
        {
            currentSecondBreathCheckTimer = 0;
            SecondBreath();
        }
    }

    private void SecondBreath()
    {
        float secondBreathChance = secondBreathBaseChance + secondBreathPositionBonus[horsePosition - 1] + secondBreathRage + secondBreathTension;

        int rnd = Random.Range(0, 101);

        if (rnd <= secondBreathBaseChance)
        {
            ActiveSecondBreath();
        }
    }

    private void ActiveSecondBreath()
    {
        canBreathAgain = false;

        isInvinsible = true;

        octopusSpeed *= secondBreathSpeedBonus;

        Invoke("ResetSpeed", secondBreathDuration);
        Invoke("ResetInvinsible", secondBreathDuration);
    }

    #region Rage

    private void CheckRageTimer()
    {
        if(currentRageTimer >= secondBreathRageDecreaseDelay)
        {
            ResetRageTimer();

            secondBreathRage = Mathf.Clamp(secondBreathRage - secondBreathRageDecrease, 0, secondBreathRageMax);
        }
    }

    private void ResetRageTimer()
    {
        currentRageTimer = 0;
    }

    #endregion

    #region Tension

    private void CheckTensionIncreaseTimer()
    {
        ResetTensionDecreaseTimer();

        if (currentTensionIncreaseTimer >= secondBreathTensionIncreaseDelay)
        {
            ResetTensionIncreaseTimer();

            secondBreathTension = Mathf.Clamp(secondBreathTension + secondBreathTensionIncrease, 0, secondBreathTensionMax);
        }
    }

    private void ResetTensionIncreaseTimer()
    {
        currentTensionDecreaseTimer = 0;
    }

    private void CheckTensionDecreaseTimer()
    {
        ResetTensionIncreaseTimer();

        if (currentTensionDecreaseTimer >= secondBreathTensionDecreaseDelay)
        {
            ResetTensionDecreaseTimer();

            secondBreathTension = Mathf.Clamp(secondBreathTension - secondBreathTensionDecrease, 0, secondBreathTensionMax);
        }
    }

    private void ResetTensionDecreaseTimer()
    {
        currentTensionDecreaseTimer = 0;
    }

    #endregion

    #endregion
}
