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

    public eThrowType GetEThrowType()
    {
        return throwType;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }

}

public enum eThrowType
{
    COCONUT,
}