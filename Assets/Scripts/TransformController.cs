using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    protected Transform tf;
    protected virtual void Awake()
    {
        tf = GetComponent<Transform>();
    }
}
