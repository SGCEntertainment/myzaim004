using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class AppManager : MonoBehaviour
{
    private const float pageDelay = 0.05f;

    private int pageIndex = 0;
    private bool InitializeElements { get; set; }

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

    private Transform ContentParent { get; set; }

    public static Action OnPressAction { get; set; } = delegate { };

    private void Awake()
    {
        ContentParent = GameObject.Find("contentParent").transform;
    }

    private void Start() => StartCoroutine(nameof(InitMenu));

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pageIndex > 0)
        {
            GoBack();
        }
    }

    private void GoBack()
    {
        if (InitializeElements)
        {
            return;
        }

        pageIndex--;
        if(pageIndex < 0)
        {
            pageIndex = 0;
        }

        OnPressAction?.Invoke();
        switch (pageIndex)
        {
            case 0: StartCoroutine(nameof(InitMenu)); break;
        }
    }

    private void ClearOldElements()
    {
        foreach(Transform t in ContentParent)
        {
            Destroy(t.gameObject);
        }

        ContentParent.DetachChildren();
    }

    private IEnumerator InitMenu()
    {
        InitializeElements = true;
        ClearOldElements();

        MenuItem menuItemPrefab = Resources.Load<MenuItem>("UI/menuItem");
        foreach(string folder in contentFolders)
        {
            Instantiate(menuItemPrefab, ContentParent).SetData(folder, () =>
            {
                if(InitializeElements)
                {
                    return;
                }

                OnPressAction?.Invoke();
                StartCoroutine(InitFolderItems(Resources.LoadAll<TextAsset>($"Content/{folder}")));
            });

            yield return new WaitForSeconds(pageDelay);
        }

        InitializeElements = false;
    }

    private IEnumerator InitFolderItems(TextAsset[] files)
    {
        pageIndex++;
        ClearOldElements();

        MenuItem subItemPrefab = Resources.Load<MenuItem>("UI/subItem");
        foreach (TextAsset textAsset in files)
        {
            StringReader reader = new StringReader(textAsset.text);
            string fileName = reader.ReadLine();

            Instantiate(subItemPrefab, ContentParent).SetData(fileName, () =>
            {
                if(InitializeElements)
                {
                    return;
                }

                OnPressAction?.Invoke();
                ClearOldElements();

                TextItem textItemPrefab = Resources.Load<TextItem>("UI/textItem");
                Instantiate(textItemPrefab, ContentParent).SetData(textAsset.text);
            });

            yield return new WaitForSeconds(pageDelay);
        }
    }
}
