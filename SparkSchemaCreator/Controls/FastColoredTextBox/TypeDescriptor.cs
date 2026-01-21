using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SparkSchemaCreator.Controls.FastColoredTextBox
{
    ///
    /// These classes are required for correct data binding to Text property of FastColoredTextbox
    /// 
    class FCTBDescriptionProvider(Type type) : TypeDescriptionProvider(GetDefaultTypeProvider(type))
    {
        private static TypeDescriptionProvider GetDefaultTypeProvider(Type type)
        {
            return TypeDescriptor.GetProvider(type);
        }



        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object? instance)
        {
            ICustomTypeDescriptor? defaultDescriptor = base.GetTypeDescriptor(objectType, instance);
            return new FCTBTypeDescriptor(defaultDescriptor, instance);
        }
    }

    class FCTBTypeDescriptor(ICustomTypeDescriptor? parent, object? instance) : CustomTypeDescriptor(parent)
    {
        private readonly ICustomTypeDescriptor? parent = parent;
        private readonly object? instance = instance;

        public override string? GetComponentName()
        {
            var ctrl = (instance as Control);
            return ctrl?.Name;
        }

        public override EventDescriptorCollection GetEvents()
        {
            var coll = base.GetEvents();
            var list = new EventDescriptor[coll.Count];

            for (int i = 0; i < coll.Count; i++)
            
                if (coll[i] is EventDescriptor eventDesc)
                {
                    if (eventDesc.Name == "TextChanged")//instead of TextChanged slip BindingTextChanged for binding
                        list[i] = new FooTextChangedDescriptor(eventDesc);
                    else
                        list[i] = eventDesc;
                }

            return new EventDescriptorCollection(list);
        }
    }

    class FooTextChangedDescriptor(MemberDescriptor desc) : EventDescriptor(desc)
    {
        public override void AddEventHandler(object component, Delegate value)
        {
            (component as FastColoredTextBox)?.BindingTextChanged += value as EventHandler;
        }

        public override Type ComponentType
        {
            get { return typeof(FastColoredTextBox); }
        }

        public override Type EventType
        {
            get { return typeof(EventHandler); }
        }

        public override bool IsMulticast
        {
            get { return true; }
        }

        public override void RemoveEventHandler(object component, Delegate value)
        {
            (component as FastColoredTextBox)?.BindingTextChanged -= value as EventHandler;
        }
    }
}
