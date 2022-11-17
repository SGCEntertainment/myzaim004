using UnityEngine.UI;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    public void SetData(string _name)
    {
        GetComponentInChildren<Text>().text = _name;
    }
}
