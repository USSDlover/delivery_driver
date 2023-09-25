using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage;
    private GameObject package;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float DestroyDelay = 0.5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package Loaded");
            hasPackage = true;
            package = other.gameObject;
            _spriteRenderer.color = hasPackageColor;
        }

        if (other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package Dropped");
            other.transform.localScale = new Vector3(1.5F, 1.5f, 1.5f);
            hasPackage = false;
            _spriteRenderer.color = noPackageColor;
            Destroy(package, DestroyDelay);
        }
    }
}
