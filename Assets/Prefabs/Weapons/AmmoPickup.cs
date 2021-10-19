using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int _amountOfAmmoToGive;
    [SerializeField] AmmoType _typeOfAmmo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER_TAG)
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_typeOfAmmo, _amountOfAmmoToGive);
            Destroy(this.gameObject);
        }
    }
}
