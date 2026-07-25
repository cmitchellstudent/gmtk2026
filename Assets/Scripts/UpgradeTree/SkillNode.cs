using System.Drawing;
using System.Xml.Serialization;
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
    private readonly TMP_Text skillName;
    private readonly TMP_Text skillDesc;
    private readonly TMP_Text skillBloodCost;
    private int skillMaxUpgrade;

    private void Awake()
    {
        button = GetComponent<Button>();
        treeManager = FindAnyObjectByType<UpgradeTreeManager>();
        button.onClick.AddListener(() => treeManager.SelectSkill(this));
    }
    void Start()
    {
        if (skillData == null) return;
        skillId = skillData.skillId;
        skillName.SetText(skillData.skillName);
        skillDesc.SetText(skillData.skillDescription);
        skillBloodCost.SetText(skillData.vampBloodCost.ToString());
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

        skillBloodCost.text = isMaxed ? "MAX" : skillData.vampBloodCost.ToString();
    }

}