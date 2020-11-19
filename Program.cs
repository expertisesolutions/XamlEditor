using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace XamlEditor
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            StyleManager.Get().ApplyTheme("c:/work/dali-env/share/com.samsung.dali-demo/res/style/demo-theme.json");

            var margin = new Extents(10, 10, 10, 10);

            var editor = new TextEditor();
            var preview = new XamlPreview();
            var layout = new LinearLayout();

            editor.Margin = margin;
            editor.Weight = 0.75f;
            editor.WidthSpecification = LayoutParamPolicies.MatchParent;
            editor.HeightSpecification = LayoutParamPolicies.MatchParent;
            editor.PointSize = 5.0f;

            preview.Margin = margin;
            preview.Weight = 0.25f;
            preview.WidthSpecification = LayoutParamPolicies.MatchParent;
            preview.HeightSpecification = LayoutParamPolicies.MatchParent;

            layout.LinearOrientation = LinearLayout.Orientation.Vertical;

            var border = new BorderVisual();
            border.Color = Color.Black;
            border.BorderSize = 1.0f;
            editor.Background = border.OutputVisualMap;

            editor.TextChanged += (o, e) =>
            {
                preview.ShowPreview(e.TextEditor.Text);
            };

            var view = new View();
            view.BackgroundColor = Color.White;
            view.WidthSpecification = LayoutParamPolicies.MatchParent;
            view.HeightSpecification = LayoutParamPolicies.MatchParent;
            view.Layout = layout;
            view.Add(preview);
            view.Add(editor);
            Window.Instance.GetDefaultLayer().Add(view);

            editor.Text = @"<TextLabel  xmlns=""http://tizen.org/Tizen.NUI/2018/XAML""
                Text=""Hello World"" PointSize=""12.0"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"" TextColor=""Blue""/>";
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
        }
    }
}
