using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteShake : MonoBehaviour
{
    public float shakeFactor;
    public float shakeSpeed;

    private Vector3 originalScale;
    private bool alphaAdd = true;
    private float alpha;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(originalScale, originalScale * shakeFactor, alpha);

        alpha += shakeSpeed * Time.deltaTime;

        if (alpha >= 1f || alpha <= 0f)
            shakeSpeed *= -1;

        if (GameManager.instance.level <= 10)
            originalScale = Vector3.one * (2f - (GameManager.instance.level - 1) * 0.15f);
    }
}