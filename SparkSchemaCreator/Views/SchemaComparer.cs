using SparkSchemaCreator.Controls.FastColoredTextBox;
using SparkSchemaCreator.Comparer;
using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using Newtonsoft.Json.Linq;

namespace SparkSchemaCreator.Views
{
    public partial class SchemaComparer : Form
    {

        private StructType left;
        private StructType right;

        private readonly List<ComparisonNode> listViewItems;
        private readonly List<ComparisonNode> listViewItemsFiltered;

        private List<ComparisonNode> SelectedList => checkBox2.Checked ? listViewItemsFiltered : listViewItems;

        private readonly MarkerStyle diffStyle = new(new SolidBrush(Color.FromArgb(50, Color.DarkOrange)));

        private readonly Color MissingFieldBackColor = Color.FromArgb(255, 182, 185);
        private readonly Color MissingFieldForeColor = Color.Firebrick;

        private readonly Color AddedFieldBackColor = Color.PaleTurquoise;
        private readonly Color AddedFieldForeColor = Color.DarkGreen;

        private readonly Color DifferenceBackColor = Color.FromArgb(255, 247, 200);
        private readonly Color MetadataDifferenceColor = Color.Navy;

        internal SchemaComparer(StructType? root)
        {
            InitializeComponent();

            left = root ?? new StructType();
            right = new StructType();

            fastTreeSchema1.Build(left);
            fastTreeSchema1.ExpandAll();
            fastTreeSchema2.Build(right);

            listViewItems = [];
            listViewItemsFiltered = [];

            splitContainer1.Panel2Collapsed = true;
        }

        private void Schema_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        private void Schema1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                StructType? imported = ImportFileFromEditor(File.ReadAllText(files[0]));

                if (imported == null)
                    return;

                left = imported;
                fastTreeSchema1.Build(left);
                fastTreeSchema1.ExpandAll();
            }
        }

        private void Schema2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                StructType? imported = ImportFileFromEditor(File.ReadAllText(files[0]));

                if (imported == null)
                    return;

                right = imported;
                fastTreeSchema2.Build(right);
                fastTreeSchema2.ExpandAll();
            }
        }

        private StructType? ImportFileFromEditor(string value)
        {
            StructType? imported = null;

            using (Editor editor = new(value))
            {
                if (editor.ShowDialog(this) == DialogResult.OK)
                    imported = editor.Value;
            }

            return imported;
        }

        private void CompareButtonClick(object sender, EventArgs e)
        {
            StructType root1 = left;
            StructType root2 = right;

            JsonSparkComparer comparer = new();

            ComparisonNodeCollection resul = comparer.CompareStructsToNodes(root1, root2);

            fastTreeSchema1.Build(resul);
            fastTreeSchema2.Build(resul);

            fastTreeSchema1.ExpandAll();
            fastTreeSchema2.ExpandAll();

            listViewItems.Clear();
            listViewItemsFiltered.Clear();

            AddRecursivelyToListView(resul);
            UpdateListViewResults(checkBox2.Checked);

            if (resul.Equal)
                MessageBox.Show("Both schemas are equal.", "Schema Comparer", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void UpdateListViewResults(bool filtered)
        {
            int listCount = filtered ? listViewItemsFiltered.Count : listViewItems.Count;
            listView1.VirtualListSize = listCount;

            if (listCount > 0)
            {
                splitContainer1.Panel2Collapsed = false;
                listView1.Columns[0].Width = -2;
                listView1.Columns[1].Width = -2;
            }
            else
                splitContainer1.Panel2Collapsed = true;
        }

        private void AddRecursivelyToListView(ComparisonNodeCollection? collection)
        {
            if (collection == null)
                return;

            foreach (var item in collection)
            {
                if (item.ComparisonResult >= ComparisonResult.MetadataDifference)
                {
                    listViewItems.Add(item);

                    if (item.ComparisonResult < ComparisonResult.MissingField)
                        listViewItemsFiltered.Add(item);
                }
                if (item.ComparisonResult.HasFlag(ComparisonResult.ChildDifference) || item.ComparisonResult.HasFlag(ComparisonResult.ChildMetadataDifference) || item.ComparisonResult.HasFlag(ComparisonResult.ChildMissingFieldDifference))
                    AddRecursivelyToListView(item.Children);
            }
        }

        private void FastTreeSchema_NodeTextNeeded(object sender, StringNodeEventArgs e)
        {
            _ = ReferenceEquals(sender, fastTreeSchema1);
            if (e.Node is ComparisonNodeCollection)
                e.Result = "<Root>";
            else if (e.Node is ComparisonNode node)
                e.Result = node.Name;
            else
                SchemaJsonTree.NodeTextNeeded(e);

        }

        private void FastTreeSchema_NodeChildrenNeeded(object sender, NodeChildrenNeededEventArgs e)
        {
            if (e.Node is ComparisonNodeCollection comparisonRoot)
                e.Children = comparisonRoot;
            else if (e.Node is ComparisonNode node)
                e.Children = node.Children;
            else
                SchemaJsonTree.NodeChildrenNeeded(e);
        }

        private void FastTreeSchema_NodeIconNeeded(object sender, ImageNodeEventArgs e)
        {
            if (e.Node is ComparisonNodeCollection)
                e.Result = imageList1.Images[0];

            else if (e.Node is ComparisonNode node)
            {

                if (!node.ComparisonResult.HasFlag(ComparisonResult.TypeDifference))
                {
                    if (node.Left is StructType || node.Right is StructType)
                        e.Result = imageList1.Images[1];
                    else if (node.Left is ArrayType || node.Right is ArrayType)
                        e.Result = imageList1.Images[2];
                    else if (node.Left is MapType || node.Right is MapType)
                        e.Result = imageList1.Images[0];
                    else if (node.Left is StructField field1 && node.Right is StructField field2)
                    {
                        if (field1.DataType is StructType || field2.DataType is StructType)
                            e.Result = imageList1.Images[1];
                        else if (field1.DataType is ArrayType || field2.DataType is ArrayType)
                            e.Result = imageList1.Images[2];
                        else if (field1.DataType is MapType || field2.DataType is MapType)
                            e.Result = imageList1.Images[0];
                        else
                            e.Result = imageList1.Images[3];
                    }
                    else
                        e.Result = imageList1.Images[3];

                }
                else
                {

                    bool left = ReferenceEquals(sender, fastTreeSchema1);

                    if ((left && node.Left is StructType) || (!left && node.Right is StructType))
                        e.Result = imageList1.Images[1];
                    else if ((left && node.Left is ArrayType) || (!left && node.Right is ArrayType))
                        e.Result = imageList1.Images[2];
                    else if ((left && node.Left is MapType) || (!left && node.Right is MapType))
                        e.Result = imageList1.Images[0];
                    else if (node.Left is StructField field1 && node.Right is StructField field2)
                    {
                        if ((left && field1.DataType is StructType) || (!left && field2.DataType is StructType))
                            e.Result = imageList1.Images[1];
                        else if ((left && field1.DataType is ArrayType) || (!left && field2.DataType is ArrayType))
                            e.Result = imageList1.Images[2];
                        else if ((left && field1.DataType is MapType) || (!left && field2.DataType is MapType))
                            e.Result = imageList1.Images[0];
                        else
                            e.Result = imageList1.Images[3];
                    }
                    else
                        e.Result = imageList1.Images[3];
                }
            }
            else
                SchemaJsonTree.NodeIconNeeded(e, imageList1);
        }

        private void FastTreeSchema_NodeBackColorNeeded(object sender, ColorNodeEventArgs e)
        {
            if (e.Node is ComparisonNode node)
            {
                if (node.ComparisonResult == ComparisonResult.MissingField)
                {
                    if ((ReferenceEquals(sender, fastTreeSchema1) && node.Left == null) || (ReferenceEquals(sender, fastTreeSchema2) && node.Right == null))
                        e.Result = MissingFieldBackColor;
                    else
                        e.Result = AddedFieldBackColor;
                }
                else if (node.ComparisonResult >= ComparisonResult.TypeDifference)
                    e.Result = DifferenceBackColor;
            }
        }

        private void FastTreeSchema_NodeForeColorNeeded(object sender, ColorNodeEventArgs e)
        {
            if (e.Node is ComparisonNode node)
            {
                if (node.ComparisonResult == ComparisonResult.MissingField)
                {
                    if ((ReferenceEquals(sender, fastTreeSchema1) && node.Left == null) || (ReferenceEquals(sender, fastTreeSchema2) && node.Right == null))
                        e.Result = MissingFieldForeColor;
                    else
                        e.Result = AddedFieldForeColor;
                }
                else if (node.ComparisonResult.HasFlag(ComparisonResult.MetadataDifference))
                    e.Result = MetadataDifferenceColor;
                else
                    e.Result = fastTreeSchema1.ForeColor;
            }
        }

        private void FastTreeSchema_NodeVisibilityNeeded(object sender, BoolNodeEventArgs e)
        {
            if (e.Node is ComparisonNode node)
            {
                if (checkBox1.Checked)
                {
                    e.Result = node.ComparisonResult != ComparisonResult.Equal;

                    if (checkBox2.Checked)
                        e.Result &= !node.ComparisonResult.HasFlag(ComparisonResult.ChildMissingFieldDifference);

                }
                else
                    e.Result = true;

                if (checkBox2.Checked)
                    e.Result &= !node.ComparisonResult.HasFlag(ComparisonResult.MissingField);

            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fastTreeSchema1.Rebuild();
            fastTreeSchema2.Rebuild();
            fastTreeSchema1.ExpandAll();
            fastTreeSchema2.ExpandAll();

            if (ReferenceEquals(sender, checkBox2))
            {
                UpdateListViewResults(checkBox2.Checked);
            }
        }

        private void FastTreeSchema_NodeSelectedStateChanged(object sender, NodeSelectedStateChangedEventArgs e)
        {
            if (ReferenceEquals(sender, fastTreeSchema1) && e.Selected && e.Node != null)
            {
                if (!fastTreeSchema2.SelectNode(e.Node))
                    fastTreeSchema2.UnselectAll();

                if (e.Node is ComparisonNode node2 && node2.ComparisonResult >= ComparisonResult.MetadataDifference)
                {
                    listView1.SelectedIndices.Clear();
                    listView1.SelectedIndices.Add(SelectedList.IndexOf(node2));
                }
            }
            else if (ReferenceEquals(sender, fastTreeSchema2) && e.Selected && e.Node != null)
            {
                if (!fastTreeSchema1.SelectNode(e.Node))
                    fastTreeSchema1.UnselectAll();
            }

            if (e.Node is ComparisonNode node)
                ProcessComparisonNode(node);
        }


        private void Process(Lines lines, FastColoredTextBox fctb1, FastColoredTextBox fctb2)
        {
            foreach (var line in lines)
            {
                string margin = new([.. line.line.TakeWhile(x => x == ' ')]);

                switch (line.state)
                {
                    case DiffType.None:
                        fctb1.AppendText(line.line + Environment.NewLine);
                        fctb2.AppendText(line.line + Environment.NewLine);
                        break;
                    case DiffType.Inserted:

                        fctb2.AppendText(margin);
                        fctb2.AppendText(line.line.TrimStart() + Environment.NewLine, diffStyle);
                        break;
                    case DiffType.Deleted:

                        fctb1.AppendText(margin);
                        fctb1.AppendText(line.line.TrimStart() + Environment.NewLine, diffStyle);
                        break;
                }
                if (line.subLines != null)
                    Process(line.subLines, fctb1, fctb2);
            }
        }

        private static void ProcessComparisonNodeArray(JObject objectArray)
        {

            if (objectArray["elementType"] is JObject objectArrayElement)
                objectArray["elementType"] = objectArrayElement["type"];
        }

        private static void ProcessComparisonNodeMap(JObject objectMap)
        {

            if (objectMap["keyType"] is JObject objectMapKey)
                objectMap["keyType"] = objectMapKey["type"];

            if (objectMap["valueType"] is JObject objectMapValue)
                objectMap["valueType"] = objectMapValue["type"];
        }

        private static void ProcessComparisonNodeStruct(JObject objectStruct)
        {
            objectStruct.Remove("fields");
        }

        private static void ProcessComparisonNodeStructField(JObject objectStructField)
        {
            if (objectStructField["type"] is JObject complexType)
            {
                if (complexType["type"]?.ToString() == "struct")
                    ProcessComparisonNodeStruct(complexType);

                else if (complexType["type"]?.ToString() == "array")
                    ProcessComparisonNodeArray(complexType);

                else if (complexType["type"]?.ToString() == "map")
                    ProcessComparisonNodeMap(complexType);

            }
        }

        private void ProcessComparisonNode(ComparisonNode comparisonNode)
        {

            JToken? leftToken = comparisonNode.Left?.ToJsonObject();
            JToken? rightToken = comparisonNode.Right?.ToJsonObject();



            if (leftToken is JObject leftObject)
            {
                if (comparisonNode.Left is StructField)
                    ProcessComparisonNodeStructField(leftObject);

                else if (comparisonNode.Left is MapType)
                    ProcessComparisonNodeMap(leftObject);

                else if (comparisonNode.Left is ArrayType)
                    ProcessComparisonNodeArray(leftObject);

                else if (comparisonNode.Left is StructType)
                    ProcessComparisonNodeStruct(leftObject);
            }

            if (rightToken is JObject rightObject)
            {
                if (comparisonNode.Right is StructField)
                    ProcessComparisonNodeStructField(rightObject);

                else if (comparisonNode.Right is MapType)
                    ProcessComparisonNodeMap(rightObject);

                else if (comparisonNode.Right is ArrayType)
                    ProcessComparisonNodeArray(rightObject);

                else if (comparisonNode.Right is StructType)
                    ProcessComparisonNodeStruct(rightObject);
            }

            fastColoredTextBoxLeft.Text = leftToken?.ToString(Newtonsoft.Json.Formatting.Indented) ?? string.Empty;
            fastColoredTextBoxRight.Text = rightToken?.ToString(Newtonsoft.Json.Formatting.Indented) ?? string.Empty;

            var source1 = Lines.Load(fastColoredTextBoxLeft.Lines);
            var source2 = Lines.Load(fastColoredTextBoxRight.Lines);

            fastColoredTextBoxLeft.Clear();
            fastColoredTextBoxRight.Clear();

            source1.Merge(source2);
            Process(source1, fastColoredTextBoxLeft, fastColoredTextBoxRight);
        }
        private void ListBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ComparisonNode comparisonNode)
                e.Value = $"{comparisonNode.Name} <{comparisonNode.ComparisonResult}>";
        }

        private void ButtonClear1_Click(object sender, EventArgs e)
        {
            left = new StructType();
            fastTreeSchema1.Build(left);
            splitContainer1.Panel2Collapsed = true;
        }

        private void ButtonClear2_Click(object sender, EventArgs e)
        {
            right = new StructType();
            fastTreeSchema2.Build(right);
            splitContainer1.Panel2Collapsed = true;
        }

        private void ButtonEdit1_Click(object sender, EventArgs e)
        {
            using Editor editor = new(left.ToJsonString(false, true, true));
            if (editor.ShowDialog(this) == DialogResult.OK && editor.Value != null)
            {
                left = editor.Value;
                fastTreeSchema1.Build(left);
                fastTreeSchema1.ExpandAll();
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void ButtonEdit2_Click(object sender, EventArgs e)
        {
            using Editor editor = new(right.ToJsonString(false, true, true));
            if (editor.ShowDialog(this) == DialogResult.OK && editor.Value != null)
            {
                right = editor.Value;
                fastTreeSchema2.Build(right);
                fastTreeSchema2.ExpandAll();
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void ButtonOpen1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();
            StructType? imported = ImportFileFromEditor(File.ReadAllText(dialog.FileName));

            if (imported == null)
                return;

            left = imported;
            fastTreeSchema1.Build(left);
            fastTreeSchema1.ExpandAll();
            splitContainer1.Panel2Collapsed = true;
        }

        private void ButtonOpen2_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();
            StructType? imported = ImportFileFromEditor(File.ReadAllText(dialog.FileName));

            if (imported == null)
                return;

            right = imported;
            fastTreeSchema2.Build(right);
            fastTreeSchema2.ExpandAll();
            splitContainer1.Panel2Collapsed = true;
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
                SelectNode(sender, SelectedList[listView1.SelectedIndices[0]]);

        }

        private void SelectNode(object sender, ComparisonNode node)
        {

            if (ReferenceEquals(sender, fastTreeSchema1))
                fastTreeSchema2.SelectNode(node);
            else
                fastTreeSchema1.SelectNode(node);

            if (node.ComparisonResult >= ComparisonResult.MetadataDifference)
                ProcessComparisonNode(node);
        }

        private void ListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ComparisonNode node = SelectedList[e.ItemIndex];
            e.Item = new ListViewItem([node.GetComparisonResultString(), node.FullName]);
        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewVisualStyles.DibujarCabeceras(sender, e);
        }

        private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color backColor = Color.White;
            Color foreColor = Color.Black;

            ComparisonNode node = SelectedList[e.ItemIndex];
            ComparisonResult comparisonResult = node.ComparisonResult;

            if (comparisonResult.HasFlag(ComparisonResult.MetadataDifference))
                foreColor = MetadataDifferenceColor;

            if (comparisonResult >= ComparisonResult.MissingField)
            {
                backColor = e.Item?.SubItems[0].Text == "MissingField" ? MissingFieldBackColor : AddedFieldBackColor;
                foreColor = e.Item?.SubItems[0].Text == "MissingField" ? MissingFieldForeColor : AddedFieldForeColor;
            }

            else if (comparisonResult >= ComparisonResult.TypeDifference)
                backColor = DifferenceBackColor;

            if (e.ColumnIndex == 0 && (listView1.SelectedIndices.Count == 0 || e.ItemIndex != listView1.SelectedIndices[0]))
                ListViewVisualStyles.DibujarSubItemListView(e, backColor, foreColor);
            else
                ListViewVisualStyles.DibujarSubItemListView(sender, e);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void Button2_Paint(object sender, PaintEventArgs e)
        {
            using Pen p = new(Color.FromArgb(81, 90, 103));
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.DrawLine(p, 5, 5, 14, 14);
            e.Graphics.DrawLine(p, 14, 5, 5, 14);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            e.Graphics.DrawLine(p, 5, 5, 14, 14);
            e.Graphics.DrawLine(p, 14, 5, 5, 14);
        }

        private void CopyToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
