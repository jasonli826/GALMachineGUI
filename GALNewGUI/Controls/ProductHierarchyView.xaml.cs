using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Windows.Documents;
using System.Diagnostics;
using System.Text.Json;
using GALNewGUI.Entity;

namespace GALNewGUI.Controls
{

    public partial class ProductHierarchyView : UserControl
    {
        public string ParentTag { get; set; }
        public  ObservableCollection<TreeItem> Items { get; set; } = new ObservableCollection<TreeItem>();
        private Dictionary<string, int> controlCounters = new Dictionary<string, int>();
        private Point _dragStartPoint;
        private TreeItem _draggedItem;
        private TreeItem _selectedItem;

        public ObservableCollection<TreeItem> GetCurrentTableData()
        {

            ExportModel exportModel = ConstructExportObject();
            Items = exportModel.Items;
            return Items;
        
        }
        private void TreeViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragStartPoint = e.GetPosition(null);
        }
        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.CommandParameter is TreeItem itemToDelete)
            {
                if (itemToDelete.Name.ToUpper().Contains("TABLE"))
                {
                    ShowModernMessage("Delete Blocked", "Cannot delete Table.", MessageBoxMode.Alert, MessageType.Error);
                    return;
                }

                bool confirm = ShowDeleteConfirmation("Confirm Delete", $"Are you sure you want to delete '{itemToDelete.Name}'?", MessageBoxMode.Confirmation);
                if (!confirm) return;

                bool removed = RemoveItemFromParent(itemToDelete, Items);
                if (removed)
                {
                    ShowModernMessage("Deleted", $"{itemToDelete.Name} was removed.", MessageBoxMode.Alert, MessageType.Success);
                }
            }
        }
        private void TreeViewItem_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = 0;
            if (ParentTag == "LEFT")
            {
                i = 1;
            }
            else
                i = 2;

            string type = string.Empty;
            if (_selectedItem != null)
            {
                type = _selectedItem.Type;
                if (type != null)
                {
                    if (type.ToUpper() == "BARCODE") // match the node name in your TreeView
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.Barcode(_selectedItem.Name,i); // load your user control

                    }
                    else if (type.ToUpper() == "INTERFACERESULT")
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.InterfaceResult(_selectedItem.Name,i);

                    }
                    else if (type.ToUpper() == "FIDUCIAL")
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.Fiducial(_selectedItem.Name,i);
                    }
                    else if (type.ToUpper() == "PALLET")
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.Pallet(_selectedItem.Name,i);
                    }
                    else if (type.ToUpper() == "LINE")
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.Line(_selectedItem.Name,i);
                    }
                    else if (type.ToUpper() == "LIST")
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.List(_selectedItem.Name,i);
                    }
                    else if (type.ToUpper() == "GRIPPERPLACE")
                    {
                        UserControlContainer.Content = new GALNewGUI.Controls.GripperPlace(_selectedItem.Name,i);
                    }
                    else
                    {
                        UserControlContainer.Content = null; // clear it for other selections
                    }
                }
            }
        }
        private void TreeViewItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePos = e.GetPosition(null);
                Vector diff = _dragStartPoint - mousePos;

                if (e.LeftButton == MouseButtonState.Pressed &&
                    (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    TreeViewItem treeViewItem = FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);
                    if (treeViewItem == null) return;

                    TreeItem data = treeViewItem.DataContext as TreeItem;
                    if (data != null)
                    {
                        DragDrop.DoDragDrop(treeViewItem, new DataObject(typeof(TreeItem), data), DragDropEffects.Move);
                        _draggedItem = data;
                    }
                }
            }
            catch (Exception ex)
            {

                ShowModernMessage("Exception Message TreeViewItem_PreviewMouseMove", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            try
            {
                while (current != null)
                {
                    if (current is T)
                    {
                        return (T)current;
                    }
                    current = VisualTreeHelper.GetParent(current);
                }
                return null;
            }
            catch (Exception ex)
            {
                ShowModernMessageForStaticMethod("Exception Message FindAncestor", ex.Message, MessageBoxMode.Alert, MessageType.Error);
                return null;
            }
        }
        public ProductHierarchyView()
        {
            InitializeComponent();

            if (Items == null)
            {

                var table = new TreeItem("Table 1", "Table");
                Items.Add(table);

                TreeViewPalletList.ItemsSource = Items;

                controlCounters["Table"] = 1;
                controlCounters["List"] = 1;
                controlCounters["Pallet"] = 1;
                controlCounters["Fiducial"] = 2;
                controlCounters["Barcode"] = 1;
                controlCounters["Line"] = 1;
                controlCounters["InterfaceResult"] = 1;
                controlCounters["GripperPlace"] = 1;
            }
            else 
            {

                    if (Items.Count == 0)
                    {

                        var table = new TreeItem("Table 1", "Table");
                        Items.Add(table);

                        TreeViewPalletList.ItemsSource = Items;

                        controlCounters["Table"] = 1;
                        controlCounters["List"] = 1;
                        controlCounters["Pallet"] = 1;
                        controlCounters["Fiducial"] = 2;
                        controlCounters["Barcode"] = 1;
                        controlCounters["Line"] = 1;
                        controlCounters["InterfaceResult"] = 1;
                        controlCounters["GripperPlace"] = 1;

                    }
            
                    
            }
               

            
        }
        public ProductHierarchyView(string parenttag)
        {
            InitializeComponent();

            if (Items == null)
            {

                var table = new TreeItem("Table 1", "Table");
                Items.Add(table);

                TreeViewPalletList.ItemsSource = Items;

                controlCounters["Table"] = 1;
                controlCounters["List"] = 1;
                controlCounters["Pallet"] = 1;
                controlCounters["Fiducial"] = 2;
                controlCounters["Barcode"] = 1;
                controlCounters["Line"] = 1;
                controlCounters["InterfaceResult"] = 1;
                controlCounters["GripperPlace"] = 1;
            }
            else
            {

                if (Items.Count == 0)
                {

                    var table = new TreeItem("Table 1", "Table");
                    Items.Add(table);

                    TreeViewPalletList.ItemsSource = Items;

                    controlCounters["Table"] = 1;
                    controlCounters["List"] = 1;
                    controlCounters["Pallet"] = 1;
                    controlCounters["Fiducial"] = 2;
                    controlCounters["Barcode"] = 1;
                    controlCounters["Line"] = 1;
                    controlCounters["InterfaceResult"] = 1;
                    controlCounters["GripperPlace"] = 1;

                }


            }

            this.ParentTag = parenttag;

        }
        private void TreeViewPalletList_Loaded(object sender, RoutedEventArgs e)
        {
            ExpandAllTreeViewItems();
        }
        private void ExpandAllTreeViewItems()
        {
            foreach (var rootItem in TreeViewPalletList.Items)
            {
                TreeViewItem tvi = TreeViewPalletList.ItemContainerGenerator.ContainerFromItem(rootItem) as TreeViewItem;
                ExpandAll(tvi);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AttachContextMenuHandler();
            if (Items != null)
            {
                if (Items.Count > 0)
                {
                    TreeViewPalletList.ItemsSource = Items;

                    ExpandAllTreeViewItems(); // optional UI helper

                    // Save each item's settings to individual files
                    WriteSettingsFromTreeItems(Items);

                }
            
            }

        }
        private void ExpandAll(TreeViewItem item)
        {
            if (item == null) return;

            item.IsExpanded = true;

            foreach (var child in item.Items)
            {
                TreeViewItem childContainer = item.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;

                // Ensure it’s generated
                if (childContainer == null)
                {
                    item.UpdateLayout();
                    childContainer = item.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;
                }

                ExpandAll(childContainer);
            }
        }

        private void ToolboxItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button && button.Tag is string tag)
            {
                tag = tag.Replace("../../Images/", string.Empty);
                tag = tag.Replace(".png", string.Empty);
                DragDrop.DoDragDrop(button, new DataObject("TreeItemType", tag), DragDropEffects.Copy);
            }
        }

        private void TreeView_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point pos = e.GetPosition(TreeViewPalletList);
                TreeViewItem container = GetNearestContainer(TreeViewPalletList, pos);
                TreeItem target = container?.DataContext as TreeItem;


                if (e.Data.GetDataPresent("TreeItemType"))
                {
                    string type = e.Data.GetData("TreeItemType") as string;

                    if (target == null && (type == "Table" || type == "List"))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else if (target != null && (target.Name.StartsWith("List") || target.Name.StartsWith("Pallet") || target.Name.StartsWith("Table")))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.None;
                    }
                }
                else if (e.Data.GetDataPresent(typeof(TreeItem)))
                {
                    TreeItem dragged = e.Data.GetData(typeof(TreeItem)) as TreeItem;
                    if (target != null)
                    {
                        TreeItem parent = FindParent(target, Items);
                        if (parent != null && (parent.Name.StartsWith("List") || parent.Name.StartsWith("Pallet") || parent.Name.StartsWith("Table")))
                        {
                            e.Effects = DragDropEffects.Move;
                        }
                        else if (target.Name.StartsWith("List") || target.Name.StartsWith("Pallet") || target.Name.StartsWith("Table"))
                        {
                            e.Effects = DragDropEffects.Move;
                        }
                        else if (target == null && dragged.Name.StartsWith("Table"))
                        {
                            e.Effects = DragDropEffects.Move;
                        }
                        else
                        {
                            e.Effects = DragDropEffects.None;
                        }
                    }
                    else
                    {
                        e.Effects = DragDropEffects.None;
                    }
                }
                else
                {
                    e.Effects = DragDropEffects.None;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                ShowModernMessage("Exception Message TreeView_DragOver", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
        }


        private TreeViewItem GetContainerFromItem(ItemsControl parent, object item)
        {
            if (parent == null)
                return null;

            TreeViewItem container = parent.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            if (container != null)
                return container;

            foreach (object childItem in parent.Items)
            {
                TreeViewItem parentContainer = parent.ItemContainerGenerator.ContainerFromItem(childItem) as TreeViewItem;
                if (parentContainer != null)
                {
                    container = GetContainerFromItem(parentContainer, item);
                    if (container != null)
                        return container;
                }
            }

            return null;
        }


        private void TreeView_Drop(object sender, DragEventArgs e)
        {
            try
            {
                //start Get which one is target node
                Point pos = e.GetPosition(TreeViewPalletList);
                TreeViewItem container = GetNearestContainer(TreeViewPalletList, pos);
                TreeItem target = container?.DataContext as TreeItem;
                //End 
                TreeItem droppedItem = null;
                bool isNewItem = false;
                string type = string.Empty;
                if (target != null)
                {
                    // Get the respective TreeViewItem Container
                    TreeViewItem targetContainer = GetContainerFromItem(TreeViewPalletList, target);//Make the parent node expand
                    if (targetContainer != null)
                    {
                        targetContainer.IsExpanded = true;
                    }
                }
                if (e.Data.GetDataPresent("TreeItemType"))
                {
                    type = e.Data.GetData("TreeItemType") as string;
                    int nextIndex = GetNextAvailableIndex(type, Items);
                    droppedItem = new TreeItem($"{type} {nextIndex}", type);
                    isNewItem = true;
                }
                else if (e.Data.GetDataPresent(typeof(TreeItem)))
                {
                    droppedItem = e.Data.GetData(typeof(TreeItem)) as TreeItem;
                }

                if (droppedItem == null || droppedItem == target || IsDescendantOf(target, droppedItem))
                    return;

                if (!isNewItem)
                {
                    RemoveItemFromParent(droppedItem, Items);
                }

                Point dropPos = e.GetPosition(container);
                double itemHeight = container?.ActualHeight ?? 0;

                TreeItem parentOfTarget = FindParent(target, Items);
                TreeItem parentOfDropped = FindParent(droppedItem, Items);

                // "If the target and droppedItem have the same parent node, perform 'sibling reordering'."
                if (parentOfTarget != null && parentOfTarget == parentOfDropped)
                {
                    int targetIndex = parentOfTarget.Children.IndexOf(target);
                    if (dropPos.Y < itemHeight / 2)
                        parentOfTarget.Children.Insert(targetIndex, droppedItem);
                    else
                        parentOfTarget.Children.Insert(targetIndex + 1, droppedItem);
                }
                // 如果 target 是 List/Pallet/Table 且不是 droppedItem 的父节点，作为子节点添加
                else if (target.Name.StartsWith("List") || target.Name.StartsWith("Pallet") || target.Name.StartsWith("Table"))
                {
                    target.Children.Add(droppedItem);
                }
                // 否则插入为同层
                else if (parentOfTarget != null)
                {
                    int targetIndex = parentOfTarget.Children.IndexOf(target);
                    if (dropPos.Y < itemHeight / 2)
                        parentOfTarget.Children.Insert(targetIndex, droppedItem);
                    else
                        parentOfTarget.Children.Insert(targetIndex + 1, droppedItem);
                }
                // 处理根节点排序
                else if (target != null && Items.Contains(target))
                {
                    int targetIndex = Items.IndexOf(target);
                    if (dropPos.Y < itemHeight / 2)
                        Items.Insert(targetIndex, droppedItem);
                    else
                        Items.Insert(targetIndex + 1, droppedItem);
                }
                else if (target == null && droppedItem.Name.StartsWith("Table"))
                {
                    Items.Add(droppedItem);
                }
            }
            catch (Exception ex)
            {
                ShowModernMessage("Exception Message TreeView_Drop", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        void AttachContextMenuHandler()
        {

            foreach (var item in FindVisualChildren<TreeViewItem>(TreeViewPalletList))
            {
                if (item.ContextMenu != null)
                {
                    foreach (var menuItem in item.ContextMenu.Items.OfType<MenuItem>())
                    {
                        if (menuItem.Header.ToString() == "Delete")
                        {
                            menuItem.Click -= MenuItem_Delete_Click; // 避免重复绑定
                            menuItem.Click += MenuItem_Delete_Click;
                        }
                        if (menuItem.Header.ToString() == "Rename")
                        {
                            menuItem.Click -= MenuItem_Rename_Click; // 避免重复绑定
                            menuItem.Click += MenuItem_Rename_Click;
                        }
                    }
                }
            }
        }
        private bool CheckDuplicateNameInTreeView(string name)
        {
            return !ContainsNameRecursive(Items, name);
        }

        private bool ContainsNameRecursive(ObservableCollection<TreeItem> items, string name)
        {
            foreach (var item in items)
            {
                if (item.Name.ToUpper() == name.ToUpper())
                    return true;

                if (item.Children != null && item.Children.Count > 0)
                {
                    if (ContainsNameRecursive(item.Children, name))
                        return true;
                }
            }
            return false;
        }


        private void MenuItem_Rename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is MenuItem menuItem && menuItem.CommandParameter is TreeItem itemToRename)
                {
                    // Prompt input dialog (custom or standard)
                    string input = ShowInputDialog("Rename", $"Enter new name for '{itemToRename.Name}':", itemToRename.Name);


                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        if (!CheckDuplicateNameInTreeView(input))
                        {
                            ShowModernMessage("Duplicate Name", "This name has already exists", MessageBoxMode.Alert, MessageType.Error);
                            return;
                        }

                        if (itemToRename.Type.ToUpper() == "BARCODE")
                        {
                            if (File.Exists("barcode_" + itemToRename.Name + ".json"))
                            {
                                FileInfo fileInfo = new FileInfo("barcode_" + itemToRename.Name + ".json");
                                fileInfo.MoveTo("barcode_" + input + ".json");

                            }
                        }
                        if (itemToRename.Type.ToUpper() == "INTERFACERESULT")
                        {
                            if (File.Exists("interfaceresult_" + itemToRename.Name + ".json"))
                            {
                                FileInfo fileInfo = new FileInfo("interfaceresult_" + itemToRename.Name + ".json");
                                fileInfo.MoveTo("interfaceresult_" + input + ".json");

                            }
                        }
                        itemToRename.Name = input;

                    }
                }
            }
            catch (Exception ex)
            {
                ShowModernMessage("Exception Message", ex.Message, MessageBoxMode.Alert, MessageType.Error);

            }
        }

        public string ShowInputDialog(string title, string message, string defaultValue = "")
        {
            Window inputWindow = new Window
            {
                Title = title,
                Width = 400,
                Height = 160,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.ToolWindow
               // Owner = this
            };

            StackPanel panel = new StackPanel { Margin = new Thickness(10) };

            panel.Children.Add(new TextBlock
            {
                Text = message,
                Margin = new Thickness(0, 0, 0, 10),
                FontSize = 14
            });

            TextBox inputBox = new TextBox { Text = defaultValue, Margin = new Thickness(0, 0, 0, 10), FontSize = 14 };
            panel.Children.Add(inputBox);

            var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };

            var okButton = new Button { Content = "OK", Width = 75, Margin = new Thickness(5) };
            var cancelButton = new Button { Content = "Cancel", Width = 75, Margin = new Thickness(5) };

            string result = null;

            okButton.Click += (_, __) =>
            {
                result = inputBox.Text;
                inputWindow.DialogResult = true;
                inputWindow.Close();
            };

            cancelButton.Click += (_, __) =>
            {
                inputWindow.DialogResult = false;
                inputWindow.Close();
            };

            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);

            panel.Children.Add(buttonPanel);
            inputWindow.Content = panel;
            inputWindow.ShowDialog();

            return result;
        }
        private bool IsDescendantOf(TreeItem node, TreeItem possibleAncestor)
        {
            if (possibleAncestor == null || node == null) return false;
            if (possibleAncestor.Children.Contains(node)) return true;

            foreach (var child in possibleAncestor.Children)
            {
                if (IsDescendantOf(node, child))
                    return true;
            }
            return false;
        }

        private void ShowLoading()
        {
            //LoadingPanel.Visibility = Visibility.Visible;
        }

        private void HideLoading()
        {
           // LoadingPanel.Visibility = Visibility.Collapsed;
        }

        private int GetNextAvailableIndex(string type, ObservableCollection<TreeItem> items)
        {

            int maxIndex = 0;
            TraverseItems(type, items, ref maxIndex);
            return maxIndex + 1;
        }
        private void TraverseItems(string type, IEnumerable<TreeItem> children, ref int maxIndex)
        {
            foreach (var item in children)
            {
                if (item.Name.StartsWith(type + " "))
                {
                    string[] parts = item.Name.Split(' ');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int number))
                    {
                        if (number > maxIndex)
                            maxIndex = number;
                    }
                }

                if (item.Children != null && item.Children.Count > 0)
                    TraverseItems(type, item.Children, ref maxIndex);
            }
        }
        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItem == null) return;

            var parent = FindParent(_selectedItem, Items);
            ObservableCollection<TreeItem> collection = parent?.Children ?? Items;

            int index = collection.IndexOf(_selectedItem);
            if (index > 0)
            {
                collection.Move(index, index - 1);
            }
        }

        private ExportModel ConstructExportObject()
        {
            ExportModel model = null;
            foreach (var item in Items)
            {
                AttachConfigDataRecursively(item);
            }
            model = new ExportModel
            {
                Items = this.Items
            };

            return model;

        }
        private void ExportToJson(string filePath)
        {
            try
            {
                ExportModel exportModel = null;
                if (File.Exists(filePath))
                    File.Delete(filePath);
                exportModel = ConstructExportObject();
                //string json = System.Text.Json.JsonSerializer.Serialize(exportModel, new System.Text.Json.JsonSerializerOptions
                //{
                //    WriteIndented = true
                //});

                string json = JsonConvert.SerializeObject(exportModel);
                File.WriteAllText(filePath, json);

                ShowModernMessage("Export Successful", "The product file was saved to disk.", MessageBoxMode.Alert, MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowModernMessage("Export Failed", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
        }
        private void ExportToXml(string filePath)
        {
            try
            {
                ExportModel exportModel = null;
                if (File.Exists(filePath))
                    File.Delete(filePath);

                exportModel = ConstructExportObject();

                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ExportModel));
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, exportModel);
                }

                ShowModernMessage("Export Successful", "The product file was saved to disk.", MessageBoxMode.Alert, MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowModernMessage("❌ Export failed:", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
        }


        private async void Export_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                ShowLoading();
                string filePath = string.Empty;
                ExportButton.IsEnabled = false;
                bool isJson = RbtnJson.IsChecked == true ? true : false;
                Microsoft.Win32.SaveFileDialog dialog = null;


                await Task.Run(() =>
                {
                    // Dummy FileDialog to trigger shell loading (won't show)
                    var dummy = new Microsoft.Win32.SaveFileDialog();
                    dummy.FileName = "init";
                    dummy.CheckPathExists = false;
                });

                dialog = new Microsoft.Win32.SaveFileDialog
                {
                    Title = "Export File",
                    Filter = RbtnJson.IsChecked == true ? "JSON files (*.json)|*.json" : "XML files (*.xml)|*.xml"
                };

                HideLoading();

                if (dialog.ShowDialog() == true)
                {
                    filePath = dialog.FileName;
                    if (isJson)
                        ExportToJson(filePath);
                    else
                        ExportToXml(filePath);
                }
            }
            catch (Exception ex)
            {
                ShowModernMessage("Export Product File Failed", ex.Message, MessageBoxMode.Alert, MessageType.Error);

            }
            finally
            {
                ExportButton.IsEnabled = true;

            }

        }
        private void ImportJsonFile(string filePath)
        {
       
            try
            {

                string json = File.ReadAllText(filePath);
                // var model = System.Text.Json.JsonSerializer.Deserialize<Entity.ExportModel>(json);
                var model = JsonConvert.DeserializeObject<ExportModel>(json);
                if (model?.Items != null)
                {
                    // Replace current TreeItems
                    Items.Clear();
                    foreach (var item in model.Items)
                        Items.Add(item);

                    TreeViewPalletList.ItemsSource = Items;

                    ExpandAllTreeViewItems(); // optional UI helper

                    // Save each item's settings to individual files
                    WriteSettingsFromTreeItems(model.Items);

                    ShowModernMessage("Import Successful", "The product file was imported successfully.", MessageBoxMode.Alert, MessageType.Success);
                }
                else
                {
                    ShowModernMessage("Import Failed", "Invalid or empty JSON file.", MessageBoxMode.Alert, MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                ShowModernMessage("Import Failed", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
      
        }

        private void ImportXMLFile(string filePath)
        {
            try
            {
                // Step 1: Deserialize ExportModel from XML
                var serializer = new XmlSerializer(typeof(ExportModel));
                ExportModel model;

                using (var reader = new StreamReader(filePath))
                {
                    model = (ExportModel)serializer.Deserialize(reader);
                }

                // Step 2: Replace in-memory TreeItems
                if (model?.Items != null)
                {
                    Items.Clear();
                    foreach (var item in model.Items)
                        Items.Add(item);

                    TreeViewPalletList.ItemsSource = Items;

                    ExpandAllTreeViewItems(); // Optional

                    // Step 3: Write barcode/interface settings as JSON files (optional)
                    WriteSettingsFromTreeItems(model.Items);

                    ShowModernMessage("Import Successful", "The XML file was imported successfully.", MessageBoxMode.Alert, MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                ShowModernMessage("Import Failed", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }

        }
        private void WriteSettingsFromTreeItems(ObservableCollection<TreeItem> items)
        {
            string table = string.Empty;
            if (ParentTag == "LEFT")
            {
                table = "LEFT";
            }
            else
                table = "RIGHT";
            foreach (var item in items)
            {
                if (item.Type == "Barcode" && item.BarcodeData != null)
                {
                    string path = table+"_"+ $"barcode_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.BarcodeData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.BarcodeData);
                    File.WriteAllText(path, json);
                }
                else if (item.Type == "InterfaceResult" && item.InterfaceResultData != null)
                {
                    string path = table + "_"+ $"interfaceresult_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.InterfaceResultData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.InterfaceResultData);
                    File.WriteAllText(path, json);
                }
                if (item.Type == "Fiducial" && item.Fiducial != null)
                {
                    string path = table+"_"+ $"faducial_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.BarcodeData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.Fiducial);
                    File.WriteAllText(path, json);
                }
                else if (item.Type == "Line" && item.Line != null)
                {
                    string path = table + "_"+ $"line_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.InterfaceResultData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.Line);
                    File.WriteAllText(path, json);
                }
                if (item.Type == "Pallet" && item.Pallet != null)
                {
                    string path = table + "_" + $"Pallet_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.BarcodeData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.Pallet);
                    File.WriteAllText(path, json);
                }
                else if (item.Type == "List" && item.List != null)
                {
                    string path = table + "_" + $"list_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.InterfaceResultData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.List);
                    File.WriteAllText(path, json);
                }
                else if (item.Type == "GripperPlace" && item.GripperPlace != null)
                {
                    string path = table + "_" + $"gripperplace_{item.Name}.json";
                    //var json = System.Text.Json.JsonSerializer.Serialize(item.InterfaceResultData, new JsonSerializerOptions { WriteIndented = true });
                    var json = JsonConvert.SerializeObject(item.GripperPlace);
                    File.WriteAllText(path, json);
                }
                // Recursively save children
                if (item.Children != null && item.Children.Count > 0)
                    WriteSettingsFromTreeItems(item.Children);
            }
        }

        private void AttachConfigDataRecursively(TreeItem item)
        {
            string key = item.Name;
            string table = string.Empty;
            if (ParentTag.ToUpper() == "LEFT")
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";

            if (item.Type == "Barcode")
            {
                string barcodePath =table+$"barcode_{key}.json";
                if (File.Exists(barcodePath))
                {
                    var json = File.ReadAllText(barcodePath);
                    item.BarcodeData = JsonConvert.DeserializeObject<Entity.Barcode>(json);
                }
            }
            else if (item.Type == "Line")
            {
                string linePath = table + $"line_{key}.json";
                if (File.Exists(linePath))
                {
                    var json = File.ReadAllText(linePath);
                    item.Line = JsonConvert.DeserializeObject<Entity.Line>(json);
                }
            }
            else if (item.Type == "Pallet")
            {
                string palletPath = table + $"pallet_{key}.json";
                if (File.Exists(palletPath))
                {
                    var json = File.ReadAllText(palletPath);
                    item.Pallet = JsonConvert.DeserializeObject<Entity.Pallet>(json);
                }
            }
           else if (item.Type == "List")
            {
                string palletPath = table + $"list_{key}.json";
                if (File.Exists(palletPath))
                {
                    var json = File.ReadAllText(palletPath);
                    item.List = JsonConvert.DeserializeObject<Entity.List>(json);
                }
            }
            else if (item.Type == "GripperPlace")
            {
                string palletPath = table + $"gripperplace_{key}.json";
                if (File.Exists(palletPath))
                {
                    var json = File.ReadAllText(palletPath);
                    item.List = JsonConvert.DeserializeObject<Entity.List>(json);
                }
            }
            else if (item.Type == "Fiducial")
            {
                string palletPath = table + $"fiducial_{key}.json";
                if (File.Exists(palletPath))
                {
                    var json = File.ReadAllText(palletPath);
                    item.List = JsonConvert.DeserializeObject<Entity.List>(json);
                }
            }

            else if (item.Type == "InterfaceResult")
            {
                string path = table + $"interfaceresult_{key}.json";
                if (File.Exists(path))
                {
                    var json = File.ReadAllText(path);
                    item.InterfaceResultData = JsonConvert.DeserializeObject<Entity.InterfaceResult>(json);
                }
            }

            foreach (var child in item.Children)
            {
                AttachConfigDataRecursively(child);
            }
        }
        private async void Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowLoading();
                string filePath = string.Empty;
                ImportButton.IsEnabled = false;
                bool isJson = RbtnJson.IsChecked == true ? true : false;
                Microsoft.Win32.OpenFileDialog dialog = null;
                await Task.Run(() =>
                {
                    // Dummy FileDialog to trigger shell loading (won't show)
                    var dummy = new Microsoft.Win32.OpenFileDialog();
                    dummy.FileName = "init";
                    dummy.CheckPathExists = false;
                });
                if (isJson)
                {
                    HideLoading();
                    dialog = new OpenFileDialog
                    {
                        Filter = "JSON files (*.json)|*.json",
                        Title = "Import Product File"
                    };

                    if (dialog.ShowDialog() == true)
                    {
                        ImportJsonFile(dialog.FileName);
                    }
                }
                else
                {

                    dialog = new OpenFileDialog
                    {
                        Filter = "XML files (*.xml)|*.xml",
                        Title = "Import Product File"
                    };
                    HideLoading();
                    if (dialog.ShowDialog() == true)
                    {
                        ImportXMLFile(dialog.FileName);
                    }

                }

            }
            catch (Exception ex)
            {
                ShowModernMessage("Import Product File Failed", ex.Message, MessageBoxMode.Alert, MessageType.Error);

            }
            finally
            {

                ImportButton.IsEnabled = true;
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItem == null) return;

            var parent = FindParent(_selectedItem, Items);
            ObservableCollection<TreeItem> collection = parent?.Children ?? Items;

            int index = collection.IndexOf(_selectedItem);
            if (index < collection.Count - 1)
            {
                collection.Move(index, index + 1);
            }
        }
        private TreeItem FindParent(TreeItem target, ObservableCollection<TreeItem> collection)
        {
            foreach (var item in collection)
            {
                if (item.Children.Contains(target))
                    return item;

                var found = FindParent(target, item.Children);
                if (found != null)
                    return found;
            }
            return null;
        }
        private void DeleteBarcodeFile(TreeItem item,int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";

         
            if (!string.IsNullOrEmpty(item.Name))
                filePath =table+"barcode_" + item.Name + ".json";
            else
                filePath = table+"barcode.json";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private void DeleteInterfaceFile(TreeItem item,int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";
            if (!string.IsNullOrEmpty(item.Name))
                filePath = table+"interfaceresult_" + item.Name + ".json";
            else
                filePath = table+"interfaceresult.json";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private void DeleteLineFile(TreeItem item, int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";
            if (!string.IsNullOrEmpty(item.Name))
                filePath = table + "line_" + item.Name + ".json";
            else
                filePath = table + "line.json";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private void DeleteListFile(TreeItem item, int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";
            if (!string.IsNullOrEmpty(item.Name))
                filePath = table + "list_" + item.Name + ".json";
            else
                filePath = table + "list.json";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private void DeletePalletFile(TreeItem item, int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";
            if (!string.IsNullOrEmpty(item.Name))
                filePath = table + "pallet_" + item.Name + ".json";
            else
                filePath = table + "pallet.json";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private void DeleteFiducialFile(TreeItem item, int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";
            if (!string.IsNullOrEmpty(item.Name))
                filePath = table + "fiducial_" + item.Name + ".json";
            else
                filePath = table + "fiducial.json";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private void DeleteGripperPlaceFile(TreeItem item, int i)
        {
            string filePath = string.Empty;
            string table = string.Empty;
            if (i == 1)
            {
                table = "LEFT_";
            }
            else
                table = "RIGHT_";
            if (!string.IsNullOrEmpty(item.Name))
                filePath = table + "gripperplace_" + item.Name + ".json";
            else
                filePath = table + "gripperplace.json";


            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
        private bool RemoveItemFromParent(TreeItem item, ObservableCollection<TreeItem> collection)
        {
            try
            {
                int i = 0;

                if (ParentTag.ToUpper() == "LEFT")
                    i = 1;
                else
                    i = 2;

                string type = string.Empty;

                if (collection.Remove(item))
                {
                    if (item.Type.ToUpper() == "BARCODE")
                    {
                        DeleteBarcodeFile(item,i);

                    }
                    if (item.Type.ToUpper() == "LINE")
                    {
                        DeleteLineFile(item, i);
                    }
                    if (item.Type.ToUpper() == "LIST")
                    {
                        DeleteListFile(item, i);
                    }
                    if (item.Type.ToUpper() == "PALLET")
                    {
                        DeletePalletFile(item, i);
                    }
                    if (item.Type.ToUpper() == "FIDUCIAL")
                    {
                        DeleteFiducialFile(item, i);
                    }
                    if (item.Type.ToUpper() == "GRIPPERPLACE")
                    {
                        DeleteGripperPlaceFile(item, i);
                    }
                    if (item.Type.ToUpper() == "INTERFACERESULT")
                    {
                        DeleteInterfaceFile(item,i);
                    }
                    foreach (var child in item.Children)
                    {
                        type = child.Type;
                        if (controlCounters.ContainsKey(type))
                        {
                            if (controlCounters[type] >= 1)
                                controlCounters[type]--;
                        }
                    }
                    return true;
                }

                foreach (var parent in collection)
                {
                    if (RemoveItemFromParent(item, parent.Children))
                    {
                        type = item.Type;
                        if (controlCounters.ContainsKey(type))
                        {
                            if (controlCounters[type] >= 1)

                                controlCounters[type]--;
                        }
                        if (item.Type.ToUpper() == "BARCODE")
                        {
                            DeleteBarcodeFile(item,i);

                        }
                        if (item.Type.ToUpper() == "LINE")
                        {
                            DeleteLineFile(item, i);

                        }
                        if (item.Type.ToUpper() == "LIST")
                        {
                            DeleteListFile(item, i);

                        }
                        if (item.Type.ToUpper() == "FIDUCIAL")
                        {
                            DeleteFiducialFile(item, i);

                        }
                        if (item.Type.ToUpper() == "PALLET")
                        {
                            DeletePalletFile(item, i);

                        }
                        if (item.Type.ToUpper() == "INTERFACERESULT")
                        {
                            DeleteInterfaceFile(item,i);
                        }
                        if (item.Type.ToUpper() == "GRIPPERPLACE")
                        {
                            DeleteGripperPlaceFile(item, i);
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                ShowModernMessage("Find Parent Failed", ex.Message, MessageBoxMode.Alert, MessageType.Error);
            }
            return false;
        }


        private TreeViewItem GetNearestContainer(UIElement reference, Point position)
        {
            DependencyObject element = reference.InputHitTest(position) as DependencyObject;

            while (element != null && !(element is TreeViewItem))
            {
                element = VisualTreeHelper.GetParent(element);
            }

            return element as TreeViewItem;
        }
        private void TreeViewPalletList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _selectedItem = e.NewValue as TreeItem;
            if (_selectedItem == null)
                return;

                UserControlContainer.Content = null; // clear it for other selections
                
            

        }
        public enum MessageType { Info, Success, Warning, Error }
        public bool ShowDeleteConfirmation(string title, string message, MessageBoxMode mode)
        {
            var dialog = new GALNewGUI.Controls.ModernMessageDialog
            {
                Title = title,
                Message = message,
                Mode = mode,
                BackgroundColor = Brushes.DarkOrange
            };

            Window window = new Window
            {
                Title = "",
                Content = dialog,
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Background = Brushes.Transparent,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
                //Owner = this
            };

            window.ShowDialog();

            return dialog.Result == true;
        }

        public void ShowModernMessage(string title, string message, MessageBoxMode mode, MessageType type)
        {
            var dialog = new GALNewGUI.Controls.ModernMessageDialog
            {
                Title = title,
                Message = message,
                Mode = mode
            };

            Brush brush = Brushes.Gray;

            switch (type)
            {
                case MessageType.Info:
                    brush = Brushes.DodgerBlue;
                    break;
                case MessageType.Success:
                    brush = Brushes.SeaGreen;
                    break;
                case MessageType.Warning:
                    brush = Brushes.DarkOrange;
                    break;
                case MessageType.Error:
                    brush = Brushes.DarkRed;
                    break;
            }

            dialog.BackgroundColor = brush;

            Window window = new Window
            {
                Title = "",
                Content = dialog,
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Background = Brushes.Transparent,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
                // Owner = this
            };

            window.ShowDialog();
        }
        public static void ShowModernMessageForStaticMethod(string title, string message, MessageBoxMode mode, MessageType type)
        {
            var dialog = new GALNewGUI.Controls.ModernMessageDialog
            {
                Title = title,
                Message = message,
                Mode = mode
            };

            Brush brush = Brushes.Gray;

            switch (type)
            {
                case MessageType.Info:
                    brush = Brushes.DodgerBlue;
                    break;
                case MessageType.Success:
                    brush = Brushes.SeaGreen;
                    break;
                case MessageType.Warning:
                    brush = Brushes.DarkOrange;
                    break;
                case MessageType.Error:
                    brush = Brushes.DarkRed;
                    break;
            }

            dialog.BackgroundColor = brush;

            Window window = new Window
            {
                Title = "",
                Content = dialog,
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Background = Brushes.Transparent,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner

            };

            window.ShowDialog();
        }

    }

}