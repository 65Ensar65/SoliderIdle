using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IGrandMoneyable
{
    void GetGrandMoneyController();
    void SetGrandMoneyParameters(TextMeshProUGUI moneyText, float money, float plusesMoney);
}

public interface IArrowWorkable
{
    void GetArrowWorkController();
    void GetArrowWoodAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool, ObjectController objectController);
    void GetArrowIronAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool, ObjectController objectController);
    void SetArrowWorkParameters(ObjectController objectController, MasterRequestSystem masterRequest, List<GameObject> woodList, List<GameObject> ironList, Transform masterPos, Collider masterCollider, ObjectPool objectPool, float workRepeating, float repeating, Image workSlider);
}

