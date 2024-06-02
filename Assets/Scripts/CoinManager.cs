using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int geld; // ���������� ��� �������� ���������� ����� (�����)
    public Text money; // UI ����� ��� ����������� ���������� �����
    public PlayfabManager playfabManager; // ������ �� PlayfabManager

    // ����� Start ���������� ���� ��� ��� �������������
    void Start()
    {
       // �������� ����������� �������� ����� �� PlayerPrefs, ���� ��� ���, �� �������� �� ��������� - 0
    }

    // ����� Update ���������� ������ ����
    void Update()
    {
        money.text = geld.ToString(); // ��������� ����� UI � ������� ��������� �����
    }

    // ����� ��� ���������� ����� (�����)
    public void Addmoney()
    {
        geld++; // ����������� ���������� ����� �� 1
        PlayerPrefs.SetInt("Money", geld); // ��������� ����������� ���������� ����� � PlayerPrefs

        if (playfabManager != null)
        {
            playfabManager.SendLeaderboard(geld); // �������� ���������� ����� � ����� SendLeaderboard PlayfabManager
        }
        else
        {
            Debug.LogError("PlayfabManager reference is missing!");
        }
    }
}
