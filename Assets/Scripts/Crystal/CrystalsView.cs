using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalsView : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private TextMeshPro _crystalText;

    private void OnEnable()
    {
        _collector.CrystalsCountChange += ChangeCrystalsCoutn;
    }

    private void OnDisable()
    {
        _collector.CrystalsCountChange -= ChangeCrystalsCoutn;
    }

    private void ChangeCrystalsCoutn(int crystalCount)
    {
        _crystalText.text = crystalCount.ToString();
    }
}