# how-to-sort-the-treeview-nodes-in-.net-maui-treeview
This example demonstrates about how to sort the treeview nodes in .NET MAUI TreeView (SfTreeView).

In [.NET MAUI TreeView](https://www.syncfusion.com/maui-controls/maui-treeview), we can able to sort the [TreeViewNode](https://help.syncfusion.com/cr/maui/Syncfusion.TreeView.Engine.TreeViewNode.html) based on the node properties. 
XAML

Creating the button and bind the command to perform sort operation

``` xaml
<StackLayout>
    <Button Text="Sort"
            Command="{Binding SortCommand}" />

    <syncfusion:SfTreeView x:Name="treeView"
                           ExpandActionTarget="Node"
                           ItemsSource="{Binding Folders}"
                           ChildPropertyName="Files">
    </syncfusion:SfTreeView>
</StackLayout>
```
To sort the collection, create a new collection and sort the ViewModel collection based on the model property using OrderBy linq method. Assign the new collection to the ViewModel collection in the command execute method.

``` csharp
private void SortTreeView(object obj)
{
    this.Folders = new ObservableCollection<Folder>(this.folders.OrderBy(x => x.ItemName));
}
```
To notify the collection changed, implement INotifyPropertyChanged for ViewModel and raise PropertyChanged event for collection.

``` csharp
public class FileManagerViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Folder> folders;
    public ObservableCollection<Folder> Folders
    {
        get
        {
            return folders;
        }
        set
        {
            folders = value;
            OnPropertyChanged(nameof(Folders));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

[View sample in Github](https://github.com/SyncfusionExamples/how-to-sort-the-treeview-nodes-in-.net-maui-treeview)

**Conclusion**
I hope you enjoyed learning about How to sort the TreeViewNode in .NET MAUI TreeView.
You can refer to our [.NET MAUI TreeView](https://www.syncfusion.com/maui-controls/maui-treeview) feature tour page to know about its other groundbreaking feature representations and documentation, and how to quickly get started for configuration specifications. You can also explore our .NET MAUI TreeView example to understand how to create and present data. For current customers, you can check out our components from the License and Downloads page. If you are new to Syncfusion, you can try our 30-day free trial to check out our other controls.
If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our support forums, Direct-Trac, or feedback portal. We are always happy to assist you!
