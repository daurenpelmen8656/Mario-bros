using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int geld; // ���������� ��� �������� ���������� ����� (�����)
    public Text money; // UI ����� ��� ����������� ���������� �����

    // ����� Start ���������� ���� ��� ��� �������������
    void Start()
    {
        geld = PlayerPrefs.GetInt("Money", 0); // �������� ����������� �������� ����� �� PlayerPrefs, ���� ��� ���, �� �������� �� ��������� - 0
    }

    // ����� Update ���������� ������ ����
    void Update()
    {
        money.text = PlayerPrefs.GetInt("Money", 0).ToString(); // ��������� ����� UI � ������� ��������� ����� �� PlayerPrefs
    }

    // ����� ��� ���������� ����� (�����)
    public void Addmoney()
    {
        geld++; // ����������� ���������� ����� �� 1
        PlayerPrefs.SetInt("Money", geld); // ��������� ����������� ���������� ����� � PlayerPrefs
    }
}
