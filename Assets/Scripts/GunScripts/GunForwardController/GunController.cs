using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : Base
{
    private ISwordForwardable swordForwardable;
    private IWeaponizinglable weaponizinglable;

    private bool IsFree = true;
    public ObjectType GunType;

    [Title("Sword Forward Speed")]
    public GunScriptible SwordScriptible;
    void Start()
    {
        swordForwardable = new GunForwardController();
        swordForwardable.SetForwardParameters(e_rigidbody, transform, SwordScriptible.GunForwardSpeed);
        swordForwardable.GetForwardController();

        weaponizinglable = new ObjectWeaponizing();
        weaponizinglable.SetWeaponizingParameters(e_stickmanActive, transform, GunType);
    }

    void GetSelectFunch(ObjectType type, Transform objPos)
    {
        switch (type)
        {
            case ObjectType.TableFinish:
                weaponizinglable.GetWeaponizingController();
                swordForwardable.GetForwardStopController();
                break;
            case ObjectType.Enemy:
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.GetInteractController(GunType, transform, GetSelectFunch);
    }

}
