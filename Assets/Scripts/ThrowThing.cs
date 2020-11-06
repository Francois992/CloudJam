using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ThrowThing : MonoBehaviour
{
    public float speed;

    #region Script Parameters

    [SerializeField]
    private eThrowType throwType;

    #endregion

    #region Fields

    private BoxCollider2D _bc2D;

    #endregion

    private void Start()
    {
        _bc2D = GetComponent<BoxCollider2D>();
        Invoke("CanCollide", 0.3f);
    }

    public eThrowType GetEThrowType()
    {
        return throwType;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }

    private void CanCollide()
    {
        _bc2D.enabled = true;
    }

}

public enum eThrowType
{
    COCONUT,
}