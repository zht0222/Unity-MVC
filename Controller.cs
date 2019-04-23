using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller 
{
    /// <summary>
    /// 执行事件
    /// </summary>
    /// <param name="data"></param>
    public abstract void Execute(object data);

    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetModel<T>() where T:Model
    {
        return MVCManager.GetModel<T>();
    }

    /// <summary>
    /// 获取视图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetView<T>() where T : View
    {
        return MVCManager.GetView<T>();
    }

    /// <summary>
    /// 注册模型
    /// </summary>
    /// <param name="model"></param>
    protected void RegisterModel(Model model)
    {
        MVCManager.RegisterModel(model);
    }

    /// <summary>
    /// 注册视图
    /// </summary>
    /// <param name="view"></param>
    protected void RegisterView(View view)
    {
        MVCManager.RegisterView(view);
    }

    /// <summary>
    /// 注册控制器
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVCManager.RegisterController(eventName, controllerType);
    }

}
