using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillNode : MonoBehaviour
{
    public SkillData skillData;

    private UpgradeTreeManager treeManager;
    private Button button;
    private int skillId;
    [SerializeField] private System.Drawing.Image skillIcon;
    [SerializeField] private TMP_Text skillName;
    [SerializeField] private TMP_Text skillDesc;
    [SerializeField] private TMP_Text skillBloodCost;
    private int skillMaxUpgrade;

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
        skillMaxUpgrade = skillData.maxLevel;
    }

    public void UpdateVisuals(int currentLevel, bool isMaxed)
    {
        if (skillData == null) return;


        // should change visuals based on level and 
        if (isMaxed)
        {
            //discolor the icon
        }
        else if (currentLevel > 0)
        {
           // visible
        }
        else
        {
            // if visible but not obtained
        }

        if (skillBloodCost != null) skillBloodCost.text = isMaxed ? "MAX" : skillData.vampBloodCost.ToString();
    }

}