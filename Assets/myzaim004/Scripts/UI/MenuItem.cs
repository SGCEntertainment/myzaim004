using UnityEngine.UI;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    public void SetData(string _name, UnityEngine.Events.UnityAction OnPressAction)
    {
        GetComponentInChildren<Text>().text = _name;
        GetComponentInChildren<Button>().onClick.AddListener(OnPressAction);
    }
}
