using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public Vector3 start;
    public Transform target;
    public Vector3 targetOffset;
    public float speed = 2f;
    public float time = 0f;

    public LineRenderer line;
    internal Vector3 lastTargetPosition;

    public Color color;
}
