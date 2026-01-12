using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Controls
{
    public class ButtonWithNoCue : Button
    {
        protected override bool ShowFocusCues => false;
        protected override void OnGotFocus(EventArgs e)
        {
            NotifyDefault(false);
        }
    }
}
