using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager is NULL");
            return _instance;
        }
    }

    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _livesText;

    public int UpdateCoins
    {
        get
        {
            return UpdateCoins;
        }

        set
        {
            _coinText.text = "Coins: " + value;
        }
    }

    public int UpdateLives
    {
        get
        {
            return UpdateLives;
        }

        set
        {
            _livesText.text = "Lives: " + value;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
