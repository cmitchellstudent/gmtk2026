using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillNode : MonoBehaviour
{
    public SkillData skillData;

    [SerializeField] PlayerStats playerStats;

    private UpgradeTreeManager treeManager;
    private Button button;
    private int skillId;
    [SerializeField] private System.Drawing.Image skillIcon;
    [SerializeField] private TMP_Text skillName;
    [SerializeField] private TMP_Text skillDesc;
    [SerializeField] private TMP_Text skillBloodCost;
    [SerializeField] private TMP_Text skillMaxUpgrade;

    private static readonly Color disabledSkillColor = Color.grey;
    private static readonly Color maxedOutColor = Color.red;

    private static readonly Color normalSkillColor = Color.azure;

    private void Awake()
    {
        // components for button and tree manager
        button = GetComponent<Button>();
        treeManager = FindAnyObjectByType<UpgradeTreeManager>();

        // color check for visuals
        UpdateVisuals();
        button.onClick.AddListener(() => treeManager.SelectSkill(this));

        if (skillData == null) return;
        skillId = skillData.skillId;
        if (skillName != null) skillName.text = skillData.skillName.ToString();
        if (skillDesc != null) skillDesc.text = skillData.skillDescription.ToString();
        if (skillBloodCost != null) skillBloodCost.text = skillData.vampBloodCost.ToString();
        skillMaxUpgrade.text = skillData.maxLevel.ToString();
    }

    public void UpdateVisuals()
    {
        int playerVampBlood = playerStats.GetVampBlood();
        int playerSkillLevel = playerStats.GetSkillLevel(skillId);


        if (skillData == null) return;


        // if player cant afford skill
        if (playerVampBlood < skillData.vampBloodCost)
        {
            //discolor the icon
            button.image.color = disabledSkillColor;
        }// if player has maxed out the skill
        else if (playerSkillLevel > skillData.maxLevel)
        {
           // visible
            button.image.color = maxedOutColor;
        }
        // if visible but not obtained
        else
        {
            button.image.color = normalSkillColor;
        }

        if (skillBloodCost != null) skillBloodCost.text = playerSkillLevel > skillData.maxLevel ? "MAX" : skillData.vampBloodCost.ToString();
    }

}