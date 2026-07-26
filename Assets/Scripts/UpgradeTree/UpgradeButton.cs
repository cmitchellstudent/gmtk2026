using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private UpgradeProgression prog;
    [SerializeField] private UpgradePanel upgradePanel;

    [SerializeField]
    private PlayerStats playerStats;

    private Button thisbutton;
    private int currentTier;
    public string title;
    //public string desc;
    public int cost;
    private bool showCondition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisbutton = GetComponent<Button>();
        switch (title.ToString())
        {
            case "Speed":
                currentTier = playerStats.speedTier;
                break;
            case "Health":
                currentTier = playerStats.healthTier;
                break;
            case "Strength":
                currentTier = playerStats.strengthTier;
                break;
            case "Timer":
                currentTier = playerStats.timerTier;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var str = "Current Tier: " + currentTier;
        if (thisbutton.interactable) upgradePanel.writeToPanel(title, str, cost, this);
    }

    public void Upgrade()
    {
        switch (title.ToString())
        {
            case "Speed":
                if (currentTier == 0)
                {
                    playerStats.SetStat(StatType.speed, 3);
                    
                } else if (currentTier == 1)
                {
                    playerStats.SetStat(StatType.speed, 6);
                } else if (currentTier == 2)
                {
                    playerStats.SetStat(StatType.speed, 8);
                }
                else
                {
                    currentTier--;
                    playerStats.GainBlood(cost);
                    thisbutton.interactable = false;
                }
                
                currentTier++;
                playerStats.speedTier = currentTier;
                break;
            case "Health":
                playerStats.SetStat(StatType.maxHealth, (playerStats.GetMaxHealth()+10));
                currentTier++;
                playerStats.healthTier = currentTier;
                break;
            case "Strength":
                if (currentTier <= 10)
                {
                    playerStats.SetStat(StatType.attackPower, playerStats.GetAttackPower()+5);
                    currentTier++;
                    playerStats.strengthTier = currentTier;
                }
                else
                {
                    thisbutton.interactable = false;
                }
                break;
            case "Timer":
                playerStats.SetStat(StatType.timeToLive, (playerStats.GetTimeToLive()+10));
                currentTier++;
                playerStats.timerTier = currentTier;
                break;
            
        }
        var str = "Current Tier: " + currentTier;
        if (thisbutton.interactable) upgradePanel.writeToPanel(title, str, cost, this);

        
        
    }
}
