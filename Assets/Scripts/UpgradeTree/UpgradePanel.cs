using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [Header("Skill Info Widget")]
    [SerializeField] private GameObject skillPanel;
    [SerializeField] private TextMeshProUGUI skillNameText;
    [SerializeField] private TextMeshProUGUI skillDescText;
    [SerializeField] private TextMeshProUGUI skillBloodCostText;
    [SerializeField] private Button buySkillButton;

    [HideInInspector]public UpgradeButton HoveredSkill;

    private int hoveredCost;
    //private SkillNode selectedSkill;

    [SerializeField] private Button startButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartRun);
        buySkillButton.onClick.AddListener(upgradeHoveredSkill);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartRun()
    {
        SceneManager.LoadScene("Demo");
    }

    public void writeToPanel(string title, string desc, int cost, UpgradeButton btn)
    {
        HoveredSkill = btn;
        skillNameText.text = title;
        skillDescText.text = desc;
        skillBloodCostText.text = "Cost: " + cost;
        hoveredCost = (cost);
    }
    public void upgradeHoveredSkill()
    {
        if (HoveredSkill != null && hoveredCost <= playerStats.GetVampBlood())
        {
            playerStats.SpendBlood(hoveredCost);
            HoveredSkill.Upgrade();
        }
    }
}
