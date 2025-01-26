using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform'u
    public Vector3 offset; // Kameran�n karaktere olan sabit mesafesi
    public float smoothSpeed = 0.125f; // Kameran�n hareket h�z�n� yumu�atma oran�

    void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonu hesapla
            Vector3 desiredPosition = target.position + offset;

            // Yumu�at�lm�� pozisyonu hesapla
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Kameray� yeni pozisyona ta��
            transform.position = smoothedPosition;
        }
    }
}
