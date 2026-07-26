using System;
using Microsoft.SqlServer.Server;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//
public class UpgradeTreeManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [Header("Skill Info Widget")] // what will be displayed on the side view for the skill
    [SerializeField] private GameObject skillPanel;
    [SerializeField] private TMP_Text skillNameText;
    [SerializeField] private TMP_Text skillDescText;
    [SerializeField] private TMP_Text skillBloodCostText;
    [SerializeField] private TMP_Text skillMaxUpgradeText;
    [SerializeField] private Button buySkillButton;
    
    private SkillNode selectedSkill;
    
    [SerializeField] private Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //selectedSkill.UpdateVisuals();
        startButton.onClick.AddListener(StartRun);
        buySkillButton.onClick.AddListener(BuySkill);
    }

    // Update is called once per frame
    private void Update()
    {
        if (skillBloodCostText != null) {
            skillBloodCostText.text = $"Vamp Blood: {playerStats.GetVampBlood()}";
        }
        if (skillMaxUpgradeText != null && selectedSkill != null)
        {
            var playerSkillLevel = playerStats.GetSkillLevel(selectedSkill.skillData.skillId);
            if (playerSkillLevel == 0)
            {
                skillMaxUpgradeText.text = $"unequiped/{selectedSkill.skillData.maxLevel}";
            } else {
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

    } 

    private void BuySkill()
    {
        var currSkill = selectedSkill.skillData;

        // if there is no skill or its maxed dont let player buy
        if (selectedSkill == null || playerStats.IsSkillMaxed(currSkill.skillId, currSkill.maxLevel))
        {
            return;
        }
            // add skill to player and spend blood for it
            playerStats.SpendBlood(currSkill.vampBloodCost);

            playerStats.SetSkill( // checks player and adds it to there skill list and increment level
                currSkill.skillId,
                playerStats.GetSkillLevel(currSkill.skillId) + 1
                );

            //apply skill effect to player
            currSkill.Apply(playerStats);


            // show children

            // refresh UI
            selectedSkill.UpdateVisuals();
    }
}