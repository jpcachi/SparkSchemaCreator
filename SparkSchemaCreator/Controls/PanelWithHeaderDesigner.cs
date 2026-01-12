using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SparkSchemaCreator.Controls
{
    public class PanelWithHeaderDesigner : ParentControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get { 
                SelectionRules rules = base.SelectionRules;
                rules &= ~SelectionRules.AllSizeable;
                return rules;
            }
        }
        protected override void PostFilterAttributes(IDictionary attributes)
        {
            base.PostFilterAttributes(attributes);
            attributes[typeof(DockingAttribute)] = new DockingAttribute(DockingBehavior.Never);
        }

        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            var propertiesToRemove = new string[]
            {
                "Dock", "Anchor", "Size", "Location", "Width", "Height",
                "MinimumSize", "MaximumSize", "AutoSize", "AutoSizeMode",
                "Visible", "Enabled"
            };

            foreach (var item in propertiesToRemove)
            {
                if (properties.Contains(item) && properties[item] is PropertyDescriptor property)
                    properties[item] = TypeDescriptor.CreateProperty(Component.GetType(),
                        property, new BrowsableAttribute(false));
            }
        }
    }

    public class MyUserControlDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            var contentsPanel = ((PanelWithHeader)Control).ContentsPanel;
            var titlePanel = ((PanelWithHeader)Control).TitlePanel;

            EnableDesignMode(contentsPanel, "ContentsPanel");
            EnableDesignMode(titlePanel, "TitlePanel");

        }
        public override bool CanParent(Control control)
        {
            return false;
        }
        protected override void OnDragOver(DragEventArgs de)
        {
            de.Effect = DragDropEffects.None;
        }
    }
}
