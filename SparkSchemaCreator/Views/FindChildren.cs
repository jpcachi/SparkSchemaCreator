using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using System.Data;

namespace SparkSchemaCreator.Views
{
    public partial class FindChildren : Form
    {
        private List<string> Children { get; }
        internal FindChildren(StructType structNode)
        {
            InitializeComponent();

            textBox2.BackColor = textBox2.BackColor;
            textBox2.ForeColor = Color.DarkGreen;

            textBox3.BackColor = textBox3.BackColor;
            textBox3.ForeColor = Color.Firebrick;

            Children = [];

            Children.AddRange(structNode.Fields.Select(f => f.Name));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StringEqualityComparer comparer = new(!checkBox1.Checked);

            textBox2.Lines = [.. textBox1.Lines.Select(x => x.Replace("\"", "")).Where(x => !string.IsNullOrWhiteSpace(x)).Intersect(Children, comparer)];
            textBox3.Lines = [.. textBox1.Lines.Select(x => x.Replace("\"", "")).Where(x => !string.IsNullOrWhiteSpace(x)).Except(Children, comparer)];
        }
    }
}
