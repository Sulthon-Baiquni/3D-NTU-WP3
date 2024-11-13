using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFocus : MonoBehaviour
{
    public Camera mainCamera;        // Kamera yang akan berpindah fokus
    public Transform targetObject;   // Objek yang akan difokuskan kamera
    public float focusSpeed = 2.0f;  // Kecepatan kamera menuju target
    public Vector3 offset;           // Offset tambahan jika diperlukan

    private bool shouldFocus = false; // Flag untuk mengaktifkan fokus

    void Update()
    {
        if (shouldFocus && mainCamera != null && targetObject != null)
        {
            // Pindahkan posisi kamera secara halus ke target
            Vector3 targetPosition = targetObject.position + offset;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, focusSpeed * Time.deltaTime);

            // Rotasi kamera ke arah target
            Vector3 direction = targetObject.position - mainCamera.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetRotation, focusSpeed * Time.deltaTime);

            // Jika kamera cukup dekat ke target, matikan fokus
            if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.1f)
            {
                shouldFocus = false;
            }
        }
    }

    // Fungsi untuk memulai fokus kamera
    public void StartFocus()
    {
        shouldFocus = true;
    }
}
