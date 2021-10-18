using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int _ammoAmount { get;  private set; } = 25 ;
    // Start is called before the first frame update
    
    public int GetCurrentAmmo()
    {
        return _ammoAmount;
    }

    public void DecreaseCurrentAmmo()
    {
        _ammoAmount--;
    }
}
