using SparkSchemaCreator.Types;
using SparkSchemaCreator.Views;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;

namespace SparkSchemaCreator.Converters
{
    internal class MetadataEditor(Type type) : ArrayEditor(type)
    {
        public HashSet<string> ItemKeys { get; } = [];

        private CollectionForm? _mForm;

        public override void PaintValue(PaintValueEventArgs e)
        {
            
            base.PaintValue(e);
        }

        protected override CollectionForm CreateCollectionForm()
        {
            _mForm = base.CreateCollectionForm();
            _mForm.Text = "Metadata Editor";
            _mForm.FormClosed += MForm_FormClosed;

            Type formType = _mForm.GetType();
            PropertyInfo? pi = formType.GetProperty("CollectionEditable", BindingFlags.NonPublic | BindingFlags.Instance);
            
            pi?.SetValue(_mForm, true, null);

            return _mForm;
        }

        private void MForm_FormClosed(object? sender, EventArgs e)
        {
            if (sender is CollectionForm cf && cf.Owner is MetadataPropertyEditor mpe)
                mpe.RefreshProperties();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext? context)
        {
            if (context == null || context.Instance == null)
                return base.GetEditStyle(context);

            return UITypeEditorEditStyle.Modal;
        }

        protected override IList GetObjectsFromInstance(object? instance)
        {
            if (cancelCreation)
                return new ArrayList();

            return base.GetObjectsFromInstance(instance);
        }

        protected override object[] GetItems(object? editValue)
        {
            if (editValue is Metadata metadata)
            {
                object[] objArray = new object[metadata.Map.Count];

                int num = 0;
                ItemKeys.Clear();
                foreach (KeyValuePair<string, object?> entry in metadata.Map)
                {
                    ItemKeys.Add(entry.Key);
                    objArray[num++] = new MetadataKeyValuePair(entry.Key, entry.Value, entry.Value?.GetType() ?? typeof(string), ItemKeys);
                }

                return objArray;
            }

            return base.GetItems(editValue);
        }

        /// <summary>
        /// Gets the data type that this collection contains.
        /// </summary>
        /// <returns>The data type of the items in the collection, or an Object if no Item property can be located on the collection.</returns>
        protected override Type CreateCollectionItemType() => typeof(MetadataKeyValuePair);

        private bool cancelCreation = false;
        /// <summary>
        /// Creates a new instance of the specified collection item type.
        /// </summary>
        /// <param name="itemType">The type of item to create.</param>
        /// <returns>A new instance of the specified type.</returns>
        protected override object CreateInstance(Type itemType)
        {
            Metadata? metadata = _mForm?.EditValue as Metadata;

            if (itemType.Name == "Key-Value Complex Item" && metadata != null)
            {
                using AddMetadataComplexValue addComplex = new(ItemKeys);
                if (addComplex.ShowDialog(_mForm) == DialogResult.OK)
                {

                    cancelCreation = false;
                    if (addComplex.Value != null && !ItemKeys.Contains(addComplex.Value.Key))
                    {
                        ItemKeys.Add(addComplex.Value.Key);
                        return addComplex.Value;
                    }
                    else
                        throw new Exception("Invalid Key Detected");
                }
                else
                    cancelCreation = true;
            }

            string keyName = "key";
            int count = 0;

            if (metadata != null)
            {
                string keyFinalName;
                do
                {
                    count++;
                    keyFinalName = $"{keyName}{count}";
                }
                while (ItemKeys.Contains(keyFinalName));


                ItemKeys.Add(keyFinalName);
                return new MetadataKeyValuePair(keyFinalName, "value", typeof(string), ItemKeys);    
            }

            return base.CreateInstance(itemType);
        }

        protected override void DestroyInstance(object instance)
        {
            if (instance is MetadataKeyValuePair kvpair)
                ItemKeys.Remove(kvpair.Key);

            base.DestroyInstance(instance);
        }

        protected override Type[] CreateNewItemTypes()
        {

            return [new MetadataTypeDelegator(typeof(MetadataKeyValuePair)), new MetadataTypeDelegator(typeof(MetadataKeyComplexValuePair))];
        }

        protected override object? SetItems(object? editValue, object[]? value)
        {

            editValue ??= CollectionType.GetConstructor([])?.Invoke(null);
            ArgumentNullException.ThrowIfNull(value);

            if (editValue is Metadata metadata)
            {

                var keysToDelete = metadata.Map.Keys.Except(value.Cast<MetadataKeyValuePair>().Select(x => x.Key));

                foreach (var key in keysToDelete)
                {
                    metadata.Map.Remove(key);
                }

                foreach (object kv in value)
                {
                    if (kv is MetadataKeyValuePair kvpair)
                    {
                        if (metadata.Map.ContainsKey(kvpair.Key))
                        {
                            metadata.Map[kvpair.Key] = kvpair.Value;
                            continue;
                        }

                        metadata.Map.Add(kvpair.Key, Convert.ChangeType(kvpair.Value, kvpair.Type));
                    }
                }
                
                return metadata;
            }

            return base.SetItems(editValue, value);
        }

        protected override string GetDisplayText(object? value)
        {
            if(value is MetadataKeyValuePair kv)
            {
                string? strValue = kv.Value?.ToString();

                if (kv.Value is Array)
                    strValue = "<Array>";
                else if (kv.Value is Metadata)
                    strValue = "<Metadata>";

                    return base.GetDisplayText($"{kv.Key}: {strValue}");
            }

            return base.GetDisplayText(value);
        }
    }
}
