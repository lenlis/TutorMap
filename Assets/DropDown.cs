using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public Dropdown dTest;
    public int ChoosedValue;
    public GameObject[] Objects;
    public GameObject PrevObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Objects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        dTest.onValueChanged.AddListener(delegate {
            DropdownValue(dTest);
        });
    }

    public void DropdownValue(Dropdown change)
    {
        for (int i = 0; i < 4; i++)
        {
            Objects[i].SetActive(false);
        }
        ChoosedValue = change.value;
        Objects[ChoosedValue].SetActive(true);
    }
}
