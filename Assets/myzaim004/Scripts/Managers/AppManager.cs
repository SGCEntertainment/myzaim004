using UnityEngine;
using System.Collections;
using System.Linq;

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

    private void Start() => StartCoroutine(nameof(InitMenu));

    private IEnumerator InitMenu()
    {
        MenuItem menuItemPrefab = Resources.Load<MenuItem>("UI/menuItem");
        Transform menuItemParent = GameObject.Find("contentParent").transform;

        foreach(string folder in contentFolders)
        {
            Instantiate(menuItemPrefab, menuItemParent).SetData(folder, () =>
            {
                StartCoroutine(InitFolderItems(Resources.LoadAll<TextAsset>($"Content/{folder}")));
            });

            yield return new WaitForSeconds(0.25f);
        }
    }

    private IEnumerator InitFolderItems(TextAsset[] files)
    {
        MenuItem menuItemPrefab = Resources.Load<MenuItem>("UI/menuItem");
        Transform menuItemParent = GameObject.Find("menuItemParent").transform;

        foreach (TextAsset textAsset in files)
        {
            //Instantiate(menuItemPrefab, menuItemParent).SetData(folder);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
