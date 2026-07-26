using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler
{
    public string statName;

    public string displayData;
    
    private Button thisButton;

    [SerializeField] private TreeSkeletonManager man;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        man.writeToPanel(statName + " " + displayData);
    }
}
