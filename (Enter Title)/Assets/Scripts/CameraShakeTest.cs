﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTest : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-3f, 3f) * magnitude;
            float y = Random.Range(-3f, 3f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;

        }

        transform.localPosition = originalPos;
    }
}
