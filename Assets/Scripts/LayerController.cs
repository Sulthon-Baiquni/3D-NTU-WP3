using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerController : MonoBehaviour
{
    // Reference untuk button
    [SerializeField] private Button mapButton;
    [SerializeField] private Button environmentButton;

    // Reference untuk layer
    [SerializeField] private GameObject mapLayer;
    [SerializeField] private GameObject threeDLayer;

    private void Start()
    {
        // Pastikan referensi tidak null
        if (mapButton != null)
            mapButton.onClick.AddListener(OnMapButtonClick);

        if (environmentButton != null)
            environmentButton.onClick.AddListener(OnEnvironmentButtonClick);
    }

    private void OnMapButtonClick()
    {
        // Menampilkan mapLayer dan menyembunyikan 3DLayer
        if (mapLayer != null)
            mapLayer.SetActive(true);

        if (threeDLayer != null)
            threeDLayer.SetActive(false);
    }

    private void OnEnvironmentButtonClick()
    {
        // Menampilkan kedua layer
        if (mapLayer != null)
            mapLayer.SetActive(true);

        if (threeDLayer != null)
            threeDLayer.SetActive(true);
    }

    
}
