using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.SceneManagement;
using Plugins;

public class GameManager : BaseSingleton<GameManager>
{
    public int PosIndex;
    public bool IsFree;
    public StickmanController StickmanActiveControllers;

    [Title("Grand Total Money Values")]
    public TextMeshProUGUI MoneyText;
    public float Money;
    public float PlusesMoney;

    [Title("Camera Values")]
    public Transform GameCamera;

    [Title("Get Object Spawn Control Values")]
    public bool IsSpawn = true;
    public int SpawnIndex;
    public int SpawnCapacity;

    [Title("Get Upgrade Buttons Values")]
    public GameObject UpgradeButtons;

    [Title("Get Fight Button Active")]
    public bool IsFight = false;
    public GameObject FightButton;
    public GameObject Masters;

    [Title("Gun List Values")]
    public List<GameObject> GunList;

    [Title("Enemy List Controller")]
    public List<Transform> EnemyList = new List<Transform>();
    public Transform WarPoint;

    [Title("Win Panel Values")]
    public GameObject WinPanel;

    [Title("Lose Panel Values")]
    public GameObject LosePanel;

    private void Update()
    {
        MoneyText.text = MathUtils.FormatNumber(Money);

        if (EnemyList.Count == 0)
        {
            GetWin();
        }

        else if (StickmanActiveControllers.Stickmans.Count == 0)
        {
            GetLose();
        }
    }

    public void GetAddMoney()
    {
        Money += PlusesMoney;
    }

    public void GetActiveFightButton()
    {
        IsFree = true;
        FightButton.SetActive(true);
        UpgradeButtons.SetActive(false);
    }

    public void GetFight()
    {
        FightButton.SetActive(false);
        IsFight = true;
        IsFree = false;
    }
    public void GetWin()
    {
        WinPanel.SetActive(true);
    }
    public void GetLose()
    {
        LosePanel.SetActive(true);
    }

    public void LevelManager()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
