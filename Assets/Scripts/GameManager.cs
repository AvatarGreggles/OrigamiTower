using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float maxMana = 100;
    public float currentMana;

    public float manaFlapRate = 2f;


    [SerializeField] public Image activeManaBar;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;


    public float manaRegenRate = 1f;
    public float manaRegenDelay = 1f;
    float manaRegenTimer = 0;
    public bool isFreefalling = false;
    public bool canRegen = true;

    public bool hasMana = true;

    public bool isGameActive = true;

    private void Awake()
    {
        currentMana = maxMana;
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateManaBar();
    }

    // Update is called once per frame
    void Update()
    {
        manaRegenTimer += Time.deltaTime;

        // Regen Manna
        if (manaRegenTimer > manaRegenDelay && canRegen)
        {
            IncreaseMana(manaRegenRate);
            manaRegenTimer = 0;
        }
    }

    public void SetHasMana()
    {
        hasMana = currentMana > 0;

        if (!hasMana)
        {
            isFreefalling = true;
            StartCoroutine(FreefallReload());
        }

    }

    IEnumerator FreefallReload()
    {
        while (currentMana < maxMana)
        {
            yield return null;
        }

        isFreefalling = false;
    }

    public void DecreaseMana(float amount)
    {
        currentMana -= amount;

        if (currentMana < 0)
        {
            currentMana = 0;
        }

        UpdateManaBar();
        SetHasMana();

    }

    public void IncreaseMana(float amount)
    {
        currentMana += amount;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        UpdateManaBar();
        SetHasMana();
    }

    void UpdateManaBar()
    {
        activeManaBar.fillAmount = currentMana / maxMana;
    }

    public void WinGame()
    {
        winScreen.gameObject.SetActive(true);

    }

    public void LoseGame()
    {
        StartCoroutine(LoseGameCoroutine());
    }

    IEnumerator LoseGameCoroutine()
    {
        isGameActive = false;
        loseScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // public bool CanCastSpell()
    // {
    //     if (currentMana > 0)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }
}
