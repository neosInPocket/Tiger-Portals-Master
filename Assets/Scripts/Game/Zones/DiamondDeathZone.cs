using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondDeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<DiamondGem>(out DiamondGem gem))
        {
            Destroy(gem.gameObject);
        }
    }
}
