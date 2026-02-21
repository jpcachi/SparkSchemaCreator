using SparkSchemaCreator.Actions;
using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Controls.FastColoredTextBox;
using SparkSchemaCreator.Json;
using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using SparkSchemaCreator.Views;
using System.CodeDom;

namespace SparkSchemaCreator
{
    public partial class SchemaCreator : Form
    {
        private readonly ModelData model;

        private readonly Stack<IAction> undo;
        private readonly Stack<IAction> redo;

        private ITreeElement? SelectedElement => fastTree1.SelectedNode as ITreeElement;

        private StructField? SelectedField => SelectedElement as StructField;

        private readonly SyntaxHighlightning syntaxHighlightning = new();

        private readonly SearchEngine searchEngine;
        private readonly Find search;

        public SchemaCreator()
        {
            InitializeComponent();

            customTabControl1.TabLanguages = [Language.JSON, Language.Custom, Language.Custom, Language.Custom];

            menuStrip1.Renderer = new NativeToolStripRenderer(ToolbarTheme.HelpBar);
            toolStrip1.Renderer = new NativeToolStripRenderer(ToolbarTheme.HelpBar);
            contextMenuStrip1.Renderer = new NativeToolStripRenderer(ToolbarTheme.HelpBar);

            model = new ModelData();

            undo = new Stack<IAction>();
            redo = new Stack<IAction>();

            searchEngine = new SearchEngine(model, ExpandNodesUntilStructField, x => fastTree1.SelectNode(x));
            search = new Find(searchEngine);

            fastTree1.Build(model.Root);

        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            using Pen p = new(Color.FromArgb(186, 197, 207));
            Rectangle rect = e.ClipRectangle;

            rect.Inflate(new Size(-11, -11));
            e.Graphics.DrawRectangle(p, rect);
        }

        private StructType? GetParentOfSelectedField()
        {
            if (fastTree1.SelectedNode is StructType root)
                return root;

            if(SelectedElement is StructField field)
                return field.StructParent;

            if(SelectedElement is NameWithDataType pairNode && pairNode.DataType is StructType structParent)
                return structParent;

            return null;
        }

        private void AddNodeButtonClick(object sender, EventArgs e)
        {
            using AddOrEditField addForm = new(null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                StructType? parent = GetParentOfSelectedField();

                if (parent != null)
                {
                    AddField addAction = new(parent, (addForm.Value as StructField)!);
                    DoActionAndAddItToStack(addAction);
                }
            }
        }

        private void EditNodeButtonClick(object sender, EventArgs e)
        {
            if(SelectedElement != null)
            {
                using AddOrEditField editForm = new(SelectedElement);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    IAction? editAction = null;

                    if (SelectedElement is StructField field)
                        editAction = new EditField(field, (editForm.Value as StructField)!);

                    else if (SelectedElement is NameWithDataType pairNode)
                        editAction = new EditElement(pairNode, (editForm.Value as DataType)!);

                    if(editAction != null)
                        DoActionAndAddItToStack(editAction);
                }
            }
        }

        private void DeleteNodeButtonClick(object sender, EventArgs e)
        {

            if (SelectedField != null && SelectedField.StructParent is StructType parent)
            {
                DeleteField deleteAction = new(parent, SelectedField);
                DoActionAndAddItToStack(deleteAction);
            }
        }

        private void MoveNodeUpButtonClick(object sender, EventArgs e)
        {

            if (SelectedField != null && SelectedField.StructParent is StructType parent)
            {
                MoveFieldUp moveUpAction = new(parent, SelectedField);
                DoActionAndAddItToStack(moveUpAction);
            }
        }

        private void MoveNodeDownButtonClick(object sender, EventArgs e)
        {

            if (SelectedField != null && SelectedField.StructParent is StructType parent)
            {
                MoveFieldDown moveDownAction = new(parent, SelectedField);
                DoActionAndAddItToStack(moveDownAction);
            }
        }

        private static List<int> GetExpandedItems(FastTree tree)
        {
            List<int> items = [];

            foreach (int i in tree.GetItemExpandedChildren(0, false))
                if (tree.GetItemExpandedChildren(i).Any())
                    items.Add(i);

            return items;
        }

        private static void ExpandedItems(ref FastTree tree, IEnumerable<int> items)
        {
            foreach (int item in items)
                tree.ExpandItem(item);
        }

        private static object? CollectNode(ComplexType typeParent)
        {
            if (typeParent.FieldOfWhichItIsType != null)
                return typeParent.FieldOfWhichItIsType;

            else if (typeParent.ArrayParent is not null)
                return new NameWithDataType("<element>", typeParent);

            else if (typeParent.MapParent is not null)
                return new NameWithDataType(typeParent.IsKeyOfMapParent ? "<key>" : "<value>", typeParent);

            return null;
        }

        private static void CollectNodesRecursively(List<object> parents, object? node)
        {
            if (node == null)
                return;

            parents.Add(node);
            object? iter = node;

            if (iter is StructField field)
            {
                StructType? parent = field.StructParent;

                if (parent?.FieldOfWhichItIsType != null)
                    iter = parent.FieldOfWhichItIsType;

                else if (parent != null && parent?.MapParent != null && parent?.IsKeyOfMapParent is bool key)
                    iter = new NameWithDataType(key ? "<key>" : "<value>", parent);

                else if (parent != null && parent?.ArrayParent != null)
                    iter = new NameWithDataType("<element>", parent);
                else
                    return;

                CollectNodesRecursively(parents, iter);
            }

            else if (iter is NameWithDataType pairNode)
            {
                if ((pairNode.Name == "<key>" || pairNode.Name == "<value>") && pairNode.DataType.MapParent is MapType mapParent)
                    iter = CollectNode(mapParent);

                else if (pairNode.Name == "<element>" && pairNode.DataType.ArrayParent is ArrayType arrayParent)
                    iter = CollectNode(arrayParent);

                else
                    return;

                CollectNodesRecursively(parents, iter);
            }
        }

        private void ExpandNodesUntilStructField(object structField)
        {
            List<object> parents = [];

            CollectNodesRecursively(parents, structField);

            parents.Reverse();

            fastTree1.ExpandNode(model.Root);
            foreach (object parent in parents)
            {
                fastTree1.ExpandNode(parent);
            }

            parents.Reverse();
            foreach (object parent in parents)
            {
                if (fastTree1.SelectNode(parent))
                    break;
            }

            fastTree1.ScrollToNode(structField);
        }

        private void RebuildSchemaTreeAfterAction(object structField)
        {
            IEnumerable<object> expandedNodesBefore = fastTree1.ExpandedNodes;
            fastTree1.Rebuild();
            fastTree1.ExpandNodesUnsafe(expandedNodesBefore);

            ExpandNodesUntilStructField(structField);
            structFieldInfo1.LoadValuesRaw(fastTree1.SelectedNode);
        }

        private void RebuildTreesAfterAction(IAction action)
        {
            if (action.AffectedNode is StructField || action.AffectedNode is NameWithDataType)
                RebuildSchemaTreeAfterAction(action.AffectedNode);

            else if (action.AffectedNode is (StructField structField2, Metadata))
            {
                RebuildSchemaTreeAfterAction(structField2);
                RefreshMetadataTree();
            }
            else if (action.AffectedNode is ModelData model)
            {
                IEnumerable<int> expandedNodesBefore = GetExpandedItems(fastTree1);
                fastTree1.Build(model.Root);
                fastTree1.ExpandItem(0);
                ExpandedItems(ref fastTree1, expandedNodesBefore);

                if (action.NeedsToExpandAllNodes)
                    fastTree1.ExpandAll();

                fastTree1.ScrollToNode(model.Root);
                structFieldInfo1.LoadValuesRaw(null);
            }
        }

        private void DoActionAndAddItToStack(IAction action)
        {
            action.Do();
            undo.Push(action);
            redo.Clear();

            RebuildTreesAfterAction(action);

            EnableUndo(undo.Count > 0);
            EnableRedo(redo.Count > 0);

            CheckActionButtonsEnabling();
        }

        private void RedoActionButtonClick(object sender, EventArgs e)
        {
            if (redo.Count > 0)
            {
                IAction action = redo.Pop();
                action.Do();
                RebuildTreesAfterAction(action);
                undo.Push(action);
            }

            EnableUndo(undo.Count > 0);
            EnableRedo(redo.Count > 0);

            CheckActionButtonsEnabling();
        }

        private void UndoActionButtonClick(object sender, EventArgs e)
        {
            if (undo.Count > 0)
            {
                IAction action = undo.Pop();
                action.Undo();
                RebuildTreesAfterAction(action);
                redo.Push(action);
            }

            EnableUndo(undo.Count > 0);
            EnableRedo(redo.Count > 0);

            CheckActionButtonsEnabling();
        }

        private void PanelWithHeader1_EnabledChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !panelWithHeader1.Enabled;
        }

        private void PanelWithHeader2_EnabledChanged(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = !panelWithHeader4.Enabled;
            splitContainer3.Panel1Collapsed = !panelWithHeader2.Enabled;
            splitContainer2.Panel1Collapsed = !panelWithHeader2.Enabled && !panelWithHeader4.Enabled;
        }

        private void PanelWithHeader3_EnabledChanged(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !panelWithHeader3.Enabled;
        }

        private void PanelWithHeader4_EnabledChanged(object sender, EventArgs e)
        {
            splitContainer3.Panel1Collapsed = !panelWithHeader2.Enabled;
            splitContainer3.Panel2Collapsed = !panelWithHeader4.Enabled;
            splitContainer2.Panel1Collapsed = !panelWithHeader2.Enabled && !panelWithHeader4.Enabled;
        }

        private void ImportNewRoot(StructType newRoot)
        {
            if (!newRoot.IsEqualsTo(model.Root))
            {
                ImportFile importFile = new(model, newRoot, true);
                DoActionAndAddItToStack(importFile);
            }
        }

        private void NewSchemaButtonClick(object sender, EventArgs e)
        {
            StructType newRoot = new();
            ImportNewRoot(newRoot);
        }

        private void ImportFileFromEditor(string value)
        {
            using Editor editor = new(value);
            if (editor.ShowDialog(this) == DialogResult.OK && editor.Value is StructType newRoot)
                ImportNewRoot(newRoot);
        }

        private void EditorButtonClick(object sender, EventArgs e)
        {
            ImportFileFromEditor(model.Root.ToJsonString(false, SchemaSettings.Instance.IncludeEmptyStructAndArrayTypes, true));
        }

        private void FastTree1_NodeBackColorNeeded(object sender, ColorNodeEventArgs e)
        {
            if (fastTree1.SelectedNode != null && fastTree1.ClickedOnText && !contextMenuStrip1.Visible)
                contextMenuStrip1.Show(MousePosition);
        }

        private void FastTree1_NodeTextNeeded(object sender, StringNodeEventArgs e)
        {
            SchemaJsonTree.NodeTextNeeded(e);
        }

        private void FastTree1_NodeChildrenNeeded(object sender, NodeChildrenNeededEventArgs e)
        {
            SchemaJsonTree.NodeChildrenNeeded(e);
        }
        
        private void FastTree1_NodeIconNeeded(object sender, ImageNodeEventArgs e)
        {
            SchemaJsonTree.NodeIconNeeded(e, imageList1);
        }


        private void FastTree1_NodeSelectedStateChanged(object sender, NodeSelectedStateChangedEventArgs e)
        {
            StructField? selectedField = SelectedField;

            if(selectedField == null && e.Node is NameWithDataType pairNode)
                selectedField = pairNode.DataType.MapParent?.FieldOfWhichItIsType;
            
            structFieldInfo1.LoadValuesRaw(e.Node);
            fastTree2.Build(selectedField?.Metadata);
            fastTree2.ExpandAll();

            CheckActionButtonsEnabling();

        }

        private void CheckActionButtonsEnabling()
        {
            bool isSelectedNodeStruct  = SelectedElement?.DataType is StructType || fastTree1.SelectedNode is StructType;
            bool isSelectedNodeComplex = SelectedElement?.DataType is ComplexType || fastTree1.SelectedNode is ComplexType;

            EnableAddNode(isSelectedNodeStruct);
            VisibleExpandChildren(isSelectedNodeComplex);

            EnableEditNode(SelectedElement != null);
            EnableDeleteNode(SelectedField != null);
            EnableMoveFieldUp(SelectedField?.Index > 0);
            EnableMoveFieldDown(SelectedField?.Index < SelectedField?.StructParent?.Fields.Count - 1);
            EnableMetadataEdit(SelectedField != null);

            findChildrenToolStripMenuItem.Visible = isSelectedNodeStruct;

            copyNameFullPathToolStripMenuItem.Enabled = SelectedElement != null;
            copyNameToolStripMenuItem.Enabled = SelectedElement != null;

            copyNodeToolStripMenuItem.Enabled = SelectedField != null;
            cutNodeToolStripMenuItem.Enabled = SelectedField != null;
            pasteNodeToolStripMenuItem.Enabled = isSelectedNodeStruct;

            bool structToArrayEnabled = isSelectedNodeStruct;

            ArrayType? array = SelectedElement is ArrayType array1 ? array1 : (SelectedElement as StructField)?.DataType as ArrayType;
            bool arrayToStructEnabled = array != null && array.ElementType is StructType;

            toolStripSeparator20.Visible = structToArrayEnabled || arrayToStructEnabled;
            changeArrayTypeToStructTypeToolStripMenuItem.Visible = structToArrayEnabled || arrayToStructEnabled;
            changeStructTypeToArrayTypeToolStripMenuItem.Visible = structToArrayEnabled || arrayToStructEnabled;

            changeArrayTypeToStructTypeToolStripMenuItem.Enabled = arrayToStructEnabled;
            changeStructTypeToArrayTypeToolStripMenuItem.Enabled = structToArrayEnabled;

        }

        private void FastTree2_NodeChildrenNeeded(object sender, NodeChildrenNeededEventArgs e)
        {
            if (e.Node is Metadata metadata)
            {
                e.Children = metadata.Map;
            }
            else if (e.Node is KeyValuePair<string, object?> mapValue)
            {
                if (mapValue.Value is Metadata metadataValue)
                    e.Children = metadataValue.Map;
                else if (mapValue.Value is Array array)
                    e.Children = array;
                else if (mapValue.Value != null)
                    e.Children = new object[] { mapValue.Value };
            }
        }

        private void FastTree2_NodeTextNeeded(object sender, StringNodeEventArgs e)
        {
            if (e.Node is Metadata)
                e.Result = "<Metadata>";
            
            else if (e.Node is KeyValuePair<string, object?> mapValue)
                e.Result = mapValue.Key;
            
            else
                e.Result = e.Node?.ToString();
        }

        private void RefreshMetadataTree()
        {
            if (SelectedField != null)
            {
                fastTree2.Build(SelectedField.Metadata);
                fastTree2.ExpandAll();
            }
        }
        private void FastTree2_NodeIconNeeded(object sender, ImageNodeEventArgs e)
        {
            if (e.Node is Metadata)
                e.Result = imageList2.Images[0];
            else if (e.Node is KeyValuePair<string, object?> mapValue)
            {
                if (mapValue.Value is Metadata)
                    e.Result = imageList2.Images[0];
                else if (mapValue.Value is Array)
                    e.Result = imageList2.Images[1];
                else
                    e.Result = imageList2.Images[2];
            }
            else
                e.Result = imageList2.Images[3];
        }

        private void MetadataEditorButtonClick(object sender, EventArgs e)
        {
            if (SelectedField == null)
                return;

            using MetadataPropertyEditor editor = new(SelectedField.Metadata);
            if (editor.ShowDialog() == DialogResult.OK && editor.Value != null)
            {
                EditMetadata editMetadata = new(SelectedField, editor.Value);
                DoActionAndAddItToStack(editMetadata);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MetadataEditorButtonClick(sender, e);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            using Pen p = new(panelWithHeader4.TitleBackColor);
            e.Graphics.DrawLine(p, 0, 0, panel1.Width, 0);

        }

        private void SettingsButtonClick(object sender, EventArgs e)
        {
            using SettingsDialog settingsDialog = new();
            settingsDialog.ShowDialog(this);
        }

        private void FastTree1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        private void FastTree1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
                ImportFileFromEditor(File.ReadAllText(files[0]));
        }

        private void GenerateOutputButtonClick(object sender, EventArgs e)
        {
            customTabControl1.TabTexts =
                [
                    model.Root.ToJsonString(false, SchemaSettings.Instance.IncludeEmptyStructAndArrayTypes, customTabControl1.PrettyJsonChecked),
                    "import org.apache.spark.sql.types._\r\n\r\nval schemaObject = " + model.Root.ToScalaObjectString(false, SchemaSettings.Instance.IntegersAsLongs, SchemaSettings.Instance.WrapFieldsInAsString),
                    "import pyspark\r\nfrom pyspark.sql.types import *\r\n\r\nschemaObject = " + model.Root.ToPythonString(false, SchemaSettings.Instance.IntegersAsLongs),
                    model.Root.TreeString()

                ];

            customTabControl1.TabLanguages[0] = customTabControl1.EscapeQuotesChecked ? Language.Custom : Language.JSON;
            customTabControl1.RefreshEditorTextAndLanguage();
        }

        private void TabTextControl_EditorTextChanged(object sender, TextChangedEventArgs e)
        {
            if (customTabControl1.SelectedTab == 1)
                syntaxHighlightning.HighlightScalaCode(sender, e);

            else if (customTabControl1.SelectedTab == 2)
                syntaxHighlightning.HighlightPythonCode(sender, e);

            else if (customTabControl1.SelectedTab == 3)
                syntaxHighlightning.HighlightPrintedSchema(sender, e);
        }

        private void CustomTabControl1_SelectedTabChanged(object sender, EventArgs e)
        {
            customTabControl1.EscapeQuotesCheckboxEnabled = customTabControl1.SelectedTab == 0;
            customTabControl1.PrettyJsonCheckboxEnabled = customTabControl1.SelectedTab == 0;
        }

        private bool toolTipPopUp = true;
        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (toolTipPopUp)
                toolTipPopUp = false;
            else
                e.Cancel = true;
        }

        private void CustomTabControl1_PrettyJsonCheckboxChanged(object sender, EventArgs e)
        {
            string currentText = customTabControl1.EditorText;

            if (customTabControl1.EscapeQuotesChecked)
                currentText = currentText.Replace(@"\""", "\"");

            try
            {

                if (customTabControl1.PrettyJsonChecked)
                    currentText = JsonUtils.FormatJson(currentText, Newtonsoft.Json.Formatting.Indented);

                else
                    currentText = JsonUtils.FormatJson(currentText, Newtonsoft.Json.Formatting.None);
            }
            catch
            {
                toolTipPopUp = true;
                customTabControl1.SetErrorToolTip(toolTip1, "Invalid json.");
            }
            finally
            {

                if (customTabControl1.EscapeQuotesChecked)
                    currentText = currentText.Replace("\"", @"\""");

                customTabControl1.TabTexts[customTabControl1.SelectedTab] = currentText;
                customTabControl1.RefreshEditorTextAndLanguage();
            }
        }

        private void CustomTabControl1_EscapeQuotesCheckboxChanged(object sender, EventArgs e)
        {
            if (customTabControl1.EscapeQuotesChecked)
            {
                customTabControl1.TabLanguages[customTabControl1.SelectedTab] = Language.Custom;
                customTabControl1.TabTexts[customTabControl1.SelectedTab] = customTabControl1.EditorText.Replace("\"", @"\""");
            }
            else
            {
                customTabControl1.TabLanguages[customTabControl1.SelectedTab] = Language.JSON;
                customTabControl1.TabTexts[customTabControl1.SelectedTab] = customTabControl1.EditorText.Replace(@"\""", "\"");
            }

            customTabControl1.RefreshEditorTextAndLanguage();
        }

        private void AdvanceEditorButtonClick(object sender, EventArgs e)
        {

            StructField? fieldToEdit = fastTree1.SelectedNode is NameWithDataType pairNode && pairNode.DataType is ComplexType complex ? 
                complex.GetClosestParent() : SelectedField;

            using AdvanceEdit newEdit = new(model, fieldToEdit);
            if (newEdit.ShowDialog(this) == DialogResult.OK)
            {
                if (newEdit.Value is StructType newRoot)
                {
                    ImportFile editRoot = new(model, newRoot, false);
                    DoActionAndAddItToStack(editRoot);
                }
                else if (fieldToEdit != null && newEdit.Value is StructField field)
                {
                    EditField editSelectedField = new(fieldToEdit, field);
                    DoActionAndAddItToStack(editSelectedField);
                }
            }
        }

        private void SchemaDiffButtonClick(object sender, EventArgs e)
        {
            using SchemaComparer comparer = new(model.Root);
            comparer.ShowDialog(this);
        }


        private void EnableMetadataEdit(bool enable)
        {
            metadataLinkLabel.Enabled = enable;
            metadataEditorToolStripMenuItem.Enabled = enable;
        }

        private void EnableAddNode(bool enable)
        {
            addFieldToolStripMenuItem.Enabled = enable;
            addToolStripButton.Enabled = enable;
            addFieldToolStripMenuItem1.Enabled = enable;

        }

        private void EnableEditNode(bool enable)
        {
            editFieldToolStripMenuItem.Enabled = enable;
            editToolStripButton.Enabled = enable;
            editFieldToolStripMenuItem1.Enabled = enable;
            structFieldInfo1.EditButtonEnabled = enable;
        }

        private void EnableDeleteNode(bool enable)
        {
            deleteFieldToolStripMenuItem.Enabled = enable;
            deleteFieldToolStripMenuItem1.Enabled = enable;
            deleteToolStripButton.Enabled = enable;
        }

        private void EnableUndo(bool enable)
        {
            undoToolStripButton.Enabled = enable;
            undoToolStripMenuItem.Enabled = enable;
        }

        private void EnableRedo(bool enable)
        {
            redoToolStripButton.Enabled = enable;
            redoToolStripMenuItem.Enabled = enable;
        }

        private void EnableMoveFieldUp(bool enable)
        {
            moveFieldupToolStripMenuItem.Enabled = enable;
            moveUpToolStripButton.Enabled = enable;
            moveSelectedFieldUpToolStripMenuItem.Enabled = enable;
        }

        private void EnableMoveFieldDown(bool enable)
        {
            moveFielddownToolStripMenuItem.Enabled = enable;
            moveDownToolStripButton.Enabled = enable;
            moveSelectedFieldDownToolStripMenuItem.Enabled = enable;
        }

        private void VisibleExpandChildren(bool visible)
        {
            expandAllSelectedNodeChildrenToolStripMenuItem.Visible = visible;
            collapseAllSelectedNodeChildrenToolStripMenuItem.Visible = visible;
            toolStripSeparator12.Visible = visible;
        }

        private void ExpandAllNodesButtonClick(object sender, EventArgs args)
        {
            fastTree1.ExpandAll();
        }

        private void CollapseAllNodesButtonClick(object sender, EventArgs args)
        {
            fastTree1.CollapseAll();
        }

        private void ExpandAllSelectedNodeChildrenButtonClick(object sender, EventArgs args)
        {
            if (SelectedElement != null)
                fastTree1.ExpandNode(SelectedElement, true);
        }

        private void CollapseAllSelectedNodeChildrenButtonClick(object sender, EventArgs args)
        {
            if (SelectedElement != null)
                fastTree1.CollapseNode(SelectedElement);
        }

        private void CopyNameButtonClick(object sender, EventArgs args)
        {
            Clipboard.SetText(SelectedField?.Name ?? "<Root>");
        }

        private void CopyFullPathNameButtonClick(object sender, EventArgs args)
        {
            Clipboard.SetText(SelectedField?.GetJsonPath() ?? "<Root>");
        }

        private void CopyNodeButtonClick(object sender, EventArgs e)
        {
            if (SelectedField != null)
                Clipboard.SetDataObject(SelectedField.Clone());
        }

        private void CutNodeButtonClick(object sender, EventArgs e)
        {
            if (SelectedField != null && SelectedField.StructParent is StructType parent)
            {
                Clipboard.SetDataObject(SelectedField.Clone());
                DeleteField deleteAction = new(parent, SelectedField);
                DoActionAndAddItToStack(deleteAction);
            }
        }

        private void PasteNodeButtonClick(object sender, EventArgs e)
        {
            IDataObject? copiedNode = Clipboard.GetDataObject();

            if (copiedNode?.GetData(typeof(StructField)) is StructField nodeData)
            {
                StructType? parent = GetParentOfSelectedField();

                if (parent != null)
                {
                    AddField addAction = new(parent, nodeData);
                    DoActionAndAddItToStack(addAction);
                }
            }
        }

        private void FindButtonClick(object sender, EventArgs e)
        {
            search.Show(this);
        }

        private void OpenJsonButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                ImportFileFromEditor(File.ReadAllText(openFileDialog1.FileName));

        }

        private void ImportJsonSchemaButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                StructType? imported = StructFieldUtils.ParseStringToSchema(File.ReadAllText(openFileDialog1.FileName), false);
                if (imported != null)
                    ImportNewRoot(imported);
            }
        }

        private void ImportJsonSampleButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                StructType? imported = StructFieldUtils.ParseStringToSchema(File.ReadAllText(openFileDialog1.FileName), true);
                if (imported != null)
                    ImportNewRoot(imported);
            }
        }

        private void ExportJsonSchemaButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, model.Root.ToJsonString(false, SchemaSettings.Instance.IncludeEmptyStructAndArrayTypes, true));
                }
            }
            catch (Exception ex)
            {
                string msg = "An error occurred while exporting the JSON:\n\n{0}";
                MessageBox.Show(string.Format(msg, ex.Message), "Export Json", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutButtonClick(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }

        private void FindChildrenButtonClick(object sender, EventArgs e)
        {

            StructType? structType = SelectedElement switch
            {
                { DataType: StructType nestedStruct } => nestedStruct,
                null => model.Root,
                _ => null
            };

            if(structType != null)
                new FindChildren(structType).ShowDialog(this);

        }

        private void ChangeArrayToStructClick(object sender, EventArgs e)
        {
            if(SelectedField != null && SelectedField.DataType is ArrayType array && array.ElementType is StructType structType)
            {
                StructField newField = SelectedField.Clone();
                newField.DataType = structType;

                EditField editAction = new(SelectedField, newField);
                DoActionAndAddItToStack(editAction);
            }
            else if(fastTree1.SelectedNode is NameWithDataType pairNode && pairNode.DataType is ArrayType array2 && array2.ElementType is StructType structType1)
            {
                EditElement editElement = new(pairNode, structType1);
                DoActionAndAddItToStack(editElement);
            }
        }

        private void ChangeStructToArrayClick(object sender, EventArgs e)
        {
            if(SelectedField is StructField field && field.DataType is StructType structType)
            {
                StructField newField = SelectedField.Clone();
                newField.DataType = new ArrayType(structType);

                EditField editAction = new(field, newField);
                DoActionAndAddItToStack(editAction);
            }
            else if (fastTree1.SelectedNode is NameWithDataType pairNode && pairNode.DataType is StructType structType1)
            {
                EditElement editElement = new(pairNode, new ArrayType(structType1.Clone()));
                DoActionAndAddItToStack(editElement);
            }
        }
    }
}
