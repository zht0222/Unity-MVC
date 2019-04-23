using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MVCManager
{
    public static Dictionary<string, Model> models = new Dictionary<string, Model>();
    public static Dictionary<string, View> views = new Dictionary<string, View>();
    public static Dictionary<string, Type> commanMap = new Dictionary<string, Type>();//事件名字 -- 类型

    /// <summary>
    /// 注册模型
    /// </summary>
    /// <param name="model"></param>
    public static void RegisterModel(Model model)
    {
        models[model.Name] = model;
    }

    /// <summary>
    /// 注册视图
    /// </summary>
    /// <param name="view"></param>
    public static void RegisterView(View view)
    {
        view.RegisterAttentionEvent();
        views[view.name] = view;
    }

    /// <summary>
    /// 注册控制器
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    public static void RegisterController(string eventName, Type controllerType)
    {
        commanMap[eventName] = controllerType;
    }

    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetModel<T>() where T : Model
    {
        foreach (var item in models.Values)
        {
            if (item is T)
            {
                return item as T;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取视图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetView<T>() where T : View
    {
        foreach (var item in views.Values)
        {
            if (item is T)
            {
                return item as T;
            }
        }
        return null;
    }

    /// <summary>
    /// 向控制器和视图分发事件
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    public static void SendEvent(string eventName, object data = null)
    {
        if (commanMap.ContainsKey(eventName))
        {
            Type t = commanMap[eventName];
            Controller c = Activator.CreateInstance(t) as Controller;
            c.Execute(data);
        }

        foreach (var v in views.Values)
        {
            if (v.attentionList.Contains(eventName))
            {
                v.HandleEvent(eventName, data);
            }
        }
    }


}