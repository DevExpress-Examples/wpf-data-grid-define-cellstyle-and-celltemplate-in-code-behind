using DevExpress.Xpf.Grid;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace fGrid11 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void AddCellTemplateButton_Click_1(object sender, RoutedEventArgs e) {
            string ageBinding = "IsReadOnly=\"{Binding RowData.EvenRow}\"";
            string nameBinding = "FontSize=\"{Binding RowData.Row.NameFontSize}\"";
            DataTemplate ageCellDataTemplate = CreateDataTemplate(ageBinding);
            if (ageCellDataTemplate != null)
                gridControl1.Columns["Age"].CellTemplate = ageCellDataTemplate;
            DataTemplate nameCellDataTemplate = CreateDataTemplate(nameBinding);
            if (nameCellDataTemplate != null)
                gridControl1.Columns["LastName"].CellTemplate = nameCellDataTemplate;
        }

        private void AddStyleButton_Click_1(object sender, RoutedEventArgs e) {
            Style style = new Style();
            style.TargetType = typeof(LightweightCellEditor);
            style.Setters.Add(new Setter(LightweightCellEditor.BackgroundProperty, new SolidColorBrush(Colors.LightGreen)));
            gridControl1.Columns["LastName"].CellStyle = style;
        }

        string myCellTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +
            "xmlns:dxe=\"http://schemas.devexpress.com/winfx/2008/xaml/editors\">" +
            "<dxe:TextEdit Name=\"PART_Editor\" HorizontalContentAlignment=\"Center\" REPLACE/></DataTemplate>";

        DataTemplate CreateDataTemplate(string markupPart) {
            string template = myCellTemplate.Replace("REPLACE", markupPart);
            DataTemplate dataTemplate = XamlReader.Load(GetStreamFromString(template)) as DataTemplate;
            return dataTemplate;
        }

        public static Stream GetStreamFromString(string s) {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
