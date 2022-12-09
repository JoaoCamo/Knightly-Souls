using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(HUD);
            Destroy(Menu);
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(floatingTextManager.gameObject);
        DontDestroyOnLoad(HUD);
        DontDestroyOnLoad(Menu);

        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public List<int> ArmorPrices;

    public List<Sprite> SwordSprites;

    public List<int> SwordPrices;

    public GameObject HUD;

    public GameObject Menu;

    public GameObject Alchemist;

    public GameObject Blacksmith;

    public Animator Pause;

    public Animator MainMenu;

    public Player player;

    public Animator deathMenu;

    public Weapon weapon;

    public FloatingTextManager floatingTextManager;

    public RectTransform HealthBar;

    public int Gold;

    public int floor;

    public bool floorUp;

    public bool finalboss = false;

    public bool FinalBossDefeated;

    public bool DemonMiniBossDefeated;

    public bool OrcMiniBossDefeated;

    public bool SkeletonMiniBossDefeated;

    public bool Level_0;

    public int enemyKills;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetTrigger("show");
        }
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public bool TryUpgradeWeapon()
    {
        if(SwordPrices.Count <= weapon.weaponLevel)
        {
            return false;
        }
        if(Gold >= SwordPrices[weapon.weaponLevel])
        {
            Gold -= SwordPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        
        return false;
    }

    public bool TryUpgradeArmor()
    {
        if(ArmorPrices.Count <= player.armorLevel)
        {
            return false;
        }
        if(Gold >= ArmorPrices[player.armorLevel])
        {
            Gold -= ArmorPrices[player.armorLevel];
            player.UpgradeArmor();
            return true;
        }

        return false;
    }

    public void HealthBarChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        HealthBar.localScale = new Vector3(ratio, 1, 1);
    }

    public void OnSceneLoaded(Scene save, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    public void StartGame()
    {
        weapon.ResetWeaponLevel();
        player.ResetArmorLevel();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Spawn");
        player.Respawn();
        HealthBarChange();
        Gold = 0;
        floor = 0;
        finalboss = false;
    }

    public void Respawn()
    {
        weapon.ResetWeaponLevel();
        player.ResetArmorLevel();
        deathMenu.SetTrigger("hide");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Spawn");
        player.Respawn();
        HealthBarChange();
        Gold = 0;
        floor = 0;
    }

    public void ReturnToMainMenu()
    {
        MainMenu.SetTrigger("show");
    }

    public void SaveState()
    {
        string save = "";

        save += FinalBossDefeated.ToString() + "|";
        save += DemonMiniBossDefeated.ToString() + "|";
        save += OrcMiniBossDefeated.ToString() + "|";
        save += SkeletonMiniBossDefeated.ToString() + "|";
        save += enemyKills.ToString();

        PlayerPrefs.SetString("SaveState", save);
    }

    public void LoadState(Scene save, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;

        if(!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split("|");

        FinalBossDefeated = bool.Parse(data[0]);
        DemonMiniBossDefeated = bool.Parse(data[1]);
        OrcMiniBossDefeated = bool.Parse(data[2]);
        SkeletonMiniBossDefeated = bool.Parse(data[3]);
        enemyKills = int.Parse(data[4]);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
