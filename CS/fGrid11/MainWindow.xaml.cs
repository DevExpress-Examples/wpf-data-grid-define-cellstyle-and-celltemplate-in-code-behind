using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace fGrid11 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            CreateList();
            DataContext = this;

        }
        public ObservableCollection<Person> ListPerson { get; set; }
        void CreateList() {
            ListPerson = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++) {
                ListPerson.Add(new Person(i));
            }
        }

        private void AddCellTemplateButton_Click_1(object sender, RoutedEventArgs e) {
            DataTemplate cellTemplate = new DataTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(TextEdit));
            factory.Name = "PART_Editor";
            factory.SetValue(TextEdit.HorizontalContentAlignmentProperty, HorizontalAlignment.Center);

            cellTemplate.VisualTree = factory;

            gridControl1.Columns["Age"].CellTemplate = cellTemplate;
        }

        private void AddStyleButton_Click_1(object sender, RoutedEventArgs e) {
            Style style = new Style();

            style.TargetType = typeof(CellContentPresenter);
            style.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Colors.Green)));

            gridControl1.Columns["LastName"].CellStyle = style;
        }


    }

    public class Person {
        public Person(int i) {
        
            LastName = "LastName" + i;
            Age = i * 10;
     
        }

        public string LastName { get; set; }
        public int Age { get; set; }
     
    }

  

}
