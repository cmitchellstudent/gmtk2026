using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillNode : MonoBehaviour
{
    public SkillData skillData;

    [SerializeField] private PlayerStats playerStats;

    private UpgradeTreeManager treeManager;
    private Button button;
    private int skillId;
    [SerializeField] private Image skillIcon;
    [SerializeField] private TMP_Text skillName;
    [SerializeField] private TMP_Text skillDesc;
    [SerializeField] private TMP_Text skillBloodCost;
    [SerializeField] private TMP_Text skillMaxUpgrade;

    private static readonly Color disabledSkillColor = Color.grey;
    private static readonly Color maxedOutColor = Color.red;
    private static readonly Color normalSkillColor = Color.azure;

    private void Awake()
    {
        button = GetComponent<Button>();
        treeManager = FindAnyObjectByType<UpgradeTreeManager>();

        button.onClick.AddListener(() => treeManager.SelectSkill(this));

        if (skillData == null) return;
        skillId = skillData.skillId;
        if (skillName != null) skillName.text = skillData.skillName.ToString();
        if (skillDesc != null) skillDesc.text = skillData.skillDescription.ToString();
        if (skillBloodCost != null) skillBloodCost.text = skillData.vampBloodCost.ToString();
        if (skillMaxUpgrade != null) skillMaxUpgrade.text = skillData.maxLevel.ToString();
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        if (skillData == null) return;

        int playerSkillLevel = playerStats.GetSkillLevel(skillId);
        bool isMaxed = playerSkillLevel >= skillData.maxLevel;

        if (isMaxed)
        {
            button.image.color = maxedOutColor;
        }
        else if (playerSkillLevel > 0)
        {
            button.image.color = normalSkillColor;
        }
        else
        {
            button.image.color = disabledSkillColor;
        }

        if (skillBloodCost != null)
            skillBloodCost.text = isMaxed ? "MAX" : skillData.vampBloodCost.ToString();
    }

}