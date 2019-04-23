using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    /// <summary>
    /// 名称标识
    /// </summary>
    public abstract string Name { get; }

    //事件列表
    [HideInInspector]
    public List<string> attentionList = new List<string>();

    /// <summary>
    /// 注册事件
    /// </summary>
    public abstract void RegisterAttentionEvent();

    /// <summary>
    /// 处理事件
    /// </summary>
    public abstract void HandleEvent(string eventName, object data);

    /// <summary>
    /// 发送事件
    /// </summary>
    protected void SendEvent(string eventName, object data = null)
    {
        MVCManager.SendEvent(eventName, data);
    }

    /// <summary>
    /// 获取模型
    /// </summary>
    protected T GetModel<T>() where T : Model
    {
        return MVCManager.GetModel<T>();
    }
}
