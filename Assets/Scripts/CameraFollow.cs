using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform'u
    public Vector3 offset; // Kameranýn karaktere olan sabit mesafesi
    public float smoothSpeed = 0.125f; // Kameranýn hareket hýzýný yumuþatma oraný

    void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonu hesapla
            Vector3 desiredPosition = target.position + offset;

            // Yumuþatýlmýþ pozisyonu hesapla
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Kamerayý yeni pozisyona taþý
            transform.position = smoothedPosition;
        }
    }
}
