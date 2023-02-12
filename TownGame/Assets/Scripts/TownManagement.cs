using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManagement : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private int numOfInhabitants;

    [SerializeField] private TownUI townUi;

    bool testBool = true;

    Town town;// Can change to list later if there is possible to create multiple towns

    // Start is called before the first frame update
    void Start() {
        money = 10000000;
        numOfInhabitants = 0;
        townUi.UpdateMoneyText(money);
        townUi.UpdateInhabitantsText(numOfInhabitants);

        town = new Town(money);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
