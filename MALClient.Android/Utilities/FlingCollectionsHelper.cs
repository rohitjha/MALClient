using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.Views;
using Android.Widget;
using FFImageLoading.Extensions;
using GalaSoft.MvvmLight.Helpers;

namespace MALClient.Android
{
    public static class FlingCollectionsHelper
    {
        private static readonly Dictionary<View, bool> FlingStates = new Dictionary<View, bool>();

        public static void InjectFlingAdapter<T>(this AbsListView container, IList<T> items,
            Action<View,int, T> dataTemplateFull, Action<View,int,T> dataTemplateFling,
            Func<int,View> containerTemplate) where T : class
        {
            if(!FlingStates.ContainsKey(container))
                FlingStates.Add(container,false);
            container.MakeFlingAware(b =>
            {
                if(FlingStates[container] == b)
                    return;
                FlingStates[container] = b;
                if (!b)
                {
                    for (int i = 0; i < container.ChildCount; i++)
                    {
                        var view = container.GetChildAt(i);
                        var item = view.Tag.Unwrap<T>();
                        dataTemplateFull(view,items.IndexOf(item),item);
                    }
                }
            });
            container.Adapter = items.GetAdapter((i, arg2, arg3) =>
            {
                var root = arg3 ?? containerTemplate(i);
                root.Tag = arg2.Wrap();
                if (FlingStates[container])
                    dataTemplateFling(root,i,arg2);
                else
                    dataTemplateFull(root,i,arg2);
                return root;
            });
        }

        public static void ClearFlingAdapter(this AbsListView container)
        {
            if (FlingStates.ContainsKey(container))
                FlingStates.Remove(container);
            container.SetOnScrollListener(null);
        }
    }
}