using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using WeaponCore;

public class GameVariables : MonoBehaviourSingleton<GameVariables>
{
    [SerializeField] public WeaponConfig[] WeaponConfigs;


    public WeaponConfig GetWeaponConfig(WeaponType weaponType)
    {
        for (int i = 0; i < WeaponConfigs.Length; i++)
        {
            WeaponConfig weaponConfig = WeaponConfigs[i];
            if (weaponConfig.WeaponType == weaponType)
            {
                return weaponConfig;
            }
        }

#if UNITY_EDITOR
        Debug.LogError("WeaponConfig not found: " + weaponType);
#endif

        return WeaponConfigs[0];
    }

}
