using System;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Nui.Vsix.Xaml;

namespace XamlEditor
{
    class XamlPreview : View
    {
        private Loader loader;
        private View added = null;

        public XamlPreview()
        {
            IList<Assembly> assemblies = new List<Assembly> { Assembly.GetEntryAssembly() };
            loader = new Loader(assemblies);
        }

        public void ShowPreview(string xaml)
        {
            View newView;

            try
            {
                newView = (View) loader.Load(xaml);
            }
            catch (Exception)
            {
                return;
            }

            if (added)
            {
                Remove(added);
            }

            Add(newView);
            added = newView;

        }
    }
}
