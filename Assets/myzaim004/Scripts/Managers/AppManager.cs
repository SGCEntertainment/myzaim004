using UnityEngine;

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
