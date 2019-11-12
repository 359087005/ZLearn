using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZButton : Button 
{
    public override void OnSelect(BaseEventData eventData)
    {
        //当当前按钮被选择的时候
        base.OnSelect(eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        //当点击其他界面的时候
        base.OnDeselect(eventData);
    }
}