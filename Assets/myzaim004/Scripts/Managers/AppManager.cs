using UnityEngine;

public class AppManager : MonoBehaviour
{
    readonly string[] contentFolders =
    {
        "��� ����� ������ �������",
        "��� �������� ��������� �������",
        "����� ����������� ���� �����������",
        "������ ��� ����, � ��� �������",
        "������ ��� �������������",
        "���������� ���������",
        "������ � ��������",
        "��� ����� �����������",
    };

    private void Start() => Init();

    private void Init()
    {
        MenuItem menuItemPrefab = Resources.Load<MenuItem>("UI/menuItem");
        Transform menuItemParent = GameObject.Find("menuItemParent").transform;

        foreach(string folder in contentFolders)
        {
            Instantiate(menuItemPrefab, menuItemParent).SetData(folder);
        }
    }
}
