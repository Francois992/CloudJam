using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ThrowThing : MonoBehaviour
{
    #region Script Parameters

    [SerializeField]
    private eThrowType throwType;

    #endregion

    public eThrowType GetEThrowType()
    {
        return throwType;
    }
}

public enum eThrowType
{
    COCONUT,
}
