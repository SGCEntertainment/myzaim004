using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    public void SetData(string content)
    {
        GetComponentInChildren<Text>().text = content;
    }
}
