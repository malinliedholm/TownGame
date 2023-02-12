using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TownUI : MonoBehaviour
{

    [SerializeField] private TMP_Text inhabitantsTxt;
    [SerializeField] private TMP_Text moneyTxt;

    private string inhabitantTxtString = "Inhabitants: ";
    private string moneyTxtString = "Money: ";

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateMoneyText(int currentNumOfMoney) {
        moneyTxt.text = moneyTxtString + currentNumOfMoney.ToString();
    }

    public void UpdateInhabitantsText(int currentNumOfInhabitants) {
        inhabitantsTxt.text = inhabitantTxtString + currentNumOfInhabitants.ToString();
    }
}
