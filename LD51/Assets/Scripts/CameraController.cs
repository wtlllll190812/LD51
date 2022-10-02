using UnityEngine;
using DG.Tweening;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public float duration;
    public float strength = 3f;
    public int vibrato = 10;

    [Button("屏幕震动")]
    public void CameraShake()
    {
        GetComponent<Camera>().DOShakePosition(duration, strength, vibrato);
    }
}
