using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public Collider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public SphereCollider e_sphereCollider;
    [HideInInspector] public MeshRenderer e_meshRenderer;
    [HideInInspector] public ObjectPool e_objectPool;
    [HideInInspector] public FinishController finishController;
    [HideInInspector] public StickmanController e_stickmanActive;
    [HideInInspector] public ObjectSpawnController e_objectSpawn;
    [HideInInspector] public SwordMasterController swordMaster;
    [HideInInspector] public ArrowMasterController arrowMaster;
    [HideInInspector] public StickmanFightController stickmanFight;
    [HideInInspector] public UpgradeController e_upgradeController;
    [HideInInspector] public SwordHitSystem e_swordSystem;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<Collider>()) ? GetComponent<Collider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_meshRenderer = GetComponent<MeshRenderer>() ? GetComponent<MeshRenderer>() : null;
        e_sphereCollider = GetComponent<SphereCollider>() ? GetComponent<SphereCollider>() : null;
        e_objectPool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        finishController = (FindObjectOfType<FinishController>()) ? FindObjectOfType<FinishController>() : null;
        e_stickmanActive = (FindObjectOfType<StickmanController>()) ? FindObjectOfType<StickmanController>() : null;
        e_objectSpawn = (FindObjectOfType<ObjectSpawnController>()) ? FindObjectOfType<ObjectSpawnController>() : null;
        swordMaster = (FindObjectOfType<SwordMasterController>()) ? FindObjectOfType<SwordMasterController>() : null;
        arrowMaster = (FindObjectOfType<ArrowMasterController>()) ? FindObjectOfType<ArrowMasterController>() : null;
        stickmanFight = (FindObjectOfType<StickmanFightController>()) ? FindObjectOfType<StickmanFightController>() : null;
        e_upgradeController = (FindObjectOfType<UpgradeController>()) ? FindObjectOfType<UpgradeController>() : null;
        e_swordSystem = (FindObjectOfType<SwordHitSystem>()) ? FindObjectOfType<SwordHitSystem>() : null;
    }
}
