using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeTreeManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [Header("Skill Info Widget")]
    [SerializeField] private GameObject skillPanel;
    [SerializeField] private TMP_Text skillNameText;
    [SerializeField] private TMP_Text skillDescText;
    [SerializeField] private TMP_Text skillBloodCostText;
    [SerializeField] private TMP_Text skillMaxUpgradeText;
    [SerializeField] private Button buySkillButton;

    private SkillNode selectedSkill;

    [SerializeField] private Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartRun);
        buySkillButton.onClick.AddListener(BuySkill);
    }

    private void Update()
    {
        if (skillBloodCostText != null)
        {
            skillBloodCostText.text = $"Vamp Blood: {playerStats.GetVampBlood()}";
        }
        if (skillMaxUpgradeText != null && selectedSkill != null)
        {
            int playerSkillLevel = playerStats.GetSkillLevel(selectedSkill.skillData.skillId);
            if (playerSkillLevel == 0)
            {
                skillMaxUpgradeText.text = $"unequiped/{selectedSkill.skillData.maxLevel}";
            }
            else
            {
                skillMaxUpgradeText.text = $"{playerSkillLevel}/{selectedSkill.skillData.maxLevel}";
            }
        }
    }

    private void StartRun()
    {
        SceneManager.LoadScene("Demo");
    }

    public void SelectSkill(SkillNode node)
    {
        selectedSkill = node;

        var currSkill = node.skillData;
        skillPanel.SetActive(true);
        skillNameText.text = currSkill.skillName;
        skillDescText.text = currSkill.skillDescription;

        bool maxed = playerStats.IsSkillMaxed(currSkill.skillId, currSkill.maxLevel);

        skillBloodCostText.text = maxed ? "MAX" : currSkill.vampBloodCost.ToString();
        buySkillButton.interactable = !maxed && playerStats.CanAfford(currSkill.vampBloodCost);

        node.UpdateVisuals();
    }

    private void BuySkill()
    {
        if (selectedSkill == null) return;

        var currSkill = selectedSkill.skillData;

        if (playerStats.IsSkillMaxed(currSkill.skillId, currSkill.maxLevel))
            return;

        playerStats.SpendBlood(currSkill.vampBloodCost);

        playerStats.SetSkill(
            currSkill.skillId,
            playerStats.GetSkillLevel(currSkill.skillId) + 1
        );

        currSkill.Apply(playerStats);

        // Refresh node visuals and info panel
        selectedSkill.UpdateVisuals();
        SelectSkill(selectedSkill);
    }
}