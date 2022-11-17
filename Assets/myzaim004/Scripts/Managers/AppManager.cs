using UnityEngine;
using System.Collections;

public class AppManager : MonoBehaviour
{
    readonly string[] contentFolders =
    {
        "Как взять кредит выгодно",
        "Как улучшить кредитный рейтинг",
        "Какие возможности дает микрокредит",
        "Кредит или займ, в чем разница",
        "Кредит это обязательство",
        "Начисление процентов",
        "Ставки и проценты",
        "Что такое микрокредит",
    };

    private void Start() => StartCoroutine(nameof(InitMenu));

    private IEnumerator InitMenu()
    {
        MenuItem menuItemPrefab = Resources.Load<MenuItem>("UI/menuItem");
        Transform menuItemParent = GameObject.Find("menuItemParent").transform;

        foreach(string folder in contentFolders)
        {
            Instantiate(menuItemPrefab, menuItemParent).SetData(folder);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
