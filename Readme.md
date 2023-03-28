<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128649710/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5102)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Define a CellStyle and CellTemplate in Code Behind 

This example demonstrates how to define a custom [ColumnBase.CellStyle](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellStyle) and [ColumnBase.CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate) in the code behind. You can compare this code-behind implementation with the XAML code in the **MainWindow.xaml** file.

![image](https://user-images.githubusercontent.com/65009440/228149184-655da4d6-899a-4510-b4d6-1a91591488b7.png)

You can also use [Conditional Formatting](https://docs.devexpress.com/WPF/17130/controls-and-libraries/data-grid/conditional-formatting) instead of the `CellStyle` to change the cell appearance based on conditions.

## Implementation Details

### Code-Behind Style

1. Create a [Style](https://learn.microsoft.com/en-us/dotnet/api/system.windows.style) object.
2. Define the style's `TargetType` and `Setters` properties.
3. Assign this style to the [ColumnBase.CellStyle](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellStyle) property.

```cs
Style style = new Style();
style.TargetType = typeof(LightweightCellEditor);
style.Setters.Add(new Setter(LightweightCellEditor.BackgroundProperty, new SolidColorBrush(Colors.LightGreen)));
gridControl1.Columns["LastName"].CellStyle = style;
```

### Code-Behind Template

1. Specify a string that contains the template's XAML code.
2. Use the [XamlReader](https://learn.microsoft.com/en-us/dotnet/api/system.windows.markup.xamlreader) to convert this string to a [DataTemplate](https://learn.microsoft.com/en-us/dotnet/api/system.windows.datatemplate) object.
3. Assign the template to the [ColumnBase.CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate) property.

```cs
string myCellTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +
    "xmlns:dxe=\"http://schemas.devexpress.com/winfx/2008/xaml/editors\">" +
    "<dxe:TextEdit Name=\"PART_Editor\" HorizontalContentAlignment=\"Center\" " + 
    "FontSize=\"{Binding RowData.Row.NameFontSize}\"/></DataTemplate>";
DataTemplate dataTemplate = XamlReader.Load(GetStreamFromString(myCellTemplate)) as DataTemplate;
gridControl1.Columns["LastName"].CellTemplate = dataTemplate;
```

## Files to Review

* [MainWindow.xaml.cs](./CS/fGrid11/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/fGrid11/MainWindow.xaml.vb))
* [MainWindow.xaml](./CS/fGrid11/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/fGrid11/MainWindow.xaml))

## Documentation

* [ColumnBase.CellStyle](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellStyle)
* [ColumnBase.CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate)
* [Assign Editors to Cells](https://docs.devexpress.com/WPF/401011/controls-and-libraries/data-grid/data-editing-and-validation/modify-cell-values/assign-an-editor-to-a-cell)

## More Examples

* [WPF Data Grid - Change a Cell Template Based on Custom Logic](https://github.com/DevExpress-Examples/wpf-data-grid-change-cell-template-based-on-custom-logic)
* [WPF Data Grid - Change the Appearance of Focused and Selected Cells](https://github.com/DevExpress-Examples/how-to-change-selected-cells-appearance-when-gridcontrols-multi-cell-selection-is-enabled-e2568)
* [Data Grid for WPF - Display Hyperlinks in Cells](https://github.com/DevExpress-Examples/wpf-data-grid-display-hyperlinks)
* [WPF Data Grid - Apply Conditional Formatting](https://github.com/DevExpress-Examples/wpf-data-grid-apply-conditional-formatting)
