using DbConnection;
using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class QueryBuilderForm : Form
    {
        private List<EntityProperty> _entityProperties;

        public List<List<Condition>> Conditions { get; private set; }

        public List<EntityProperty> EntityProperties { get; private set; }

        public QueryBuilderForm(List<EntityProperty> entityProperties)
        {
            InitializeComponent();

            _entityProperties = entityProperties;
        }

        private void AddColumn(EntityProperty entityProperty)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = entityProperty.HeaderText,
                Tag = entityProperty,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            };
            dataGridView.Columns.Add(column);
        }

        private void InputValue(EntityProperty entityProperty, DataGridViewCell cell)
        {
            switch (entityProperty.Specimen)
            {
                case PropertySpecimen.STRING:
                    {
                        SubstringInputDialog dialog = new SubstringInputDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (cell.Tag is Condition<string> condition)
                            {
                                condition.Value = dialog.Substring;
                                
                            }
                            else cell.Tag = new Condition<string>(dialog.Substring);
                            cell.Value = $"*{dialog.Substring}*";
                        }
                    }
                    break;

                case PropertySpecimen.QUANTITATIVE:
                    {
                        CompareConditionInputDialog dialog = new CompareConditionInputDialog(entityProperty.Type);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (cell.Tag is CompareCondition condition)
                            {
                                condition.Value = dialog.Value;
                                condition.Operator = dialog.Operator;
                                
                            }
                            else cell.Tag = new CompareCondition(dialog.Value, dialog.Operator);
                            cell.Value = (cell.Tag as CompareCondition)?.ToString();
                        }
                    }
                    break;

                case PropertySpecimen.FOREIGN_KEY:
                    {
                        ForeignKeyInputDialog dialog = new ForeignKeyInputDialog(entityProperty.Type);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (cell.Tag is Condition<int> condition)
                            {
                                condition.Value = dialog.Value;
                            }
                            else cell.Tag = new Condition<int>(dialog.Value);
                            cell.Value = dialog.View;
                        }
                    }
                    break;
            }
        }

        private void QueryBuilderForm_Load(object sender, EventArgs e)
        {
            entityPropertyBindingSource.DataSource = _entityProperties;
        }

        private void QueryBuilderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                EntityProperties = GetEntityProperties();
                Conditions = GetConditions();
            }
        }

        private void addColumnButton_Click(object sender, EventArgs e)
        {
            AddColumn((EntityProperty)entityPropertyBindingSource.Current);
            if (dataGridView.Rows.Count == 0) dataGridView.Rows.Add();
        }

        private List<EntityProperty> GetEntityProperties()
        {
            List<EntityProperty> entityProperties = new List<EntityProperty>();
            foreach (DataGridViewColumn column in dataGridView.Columns) entityProperties.Add((EntityProperty)column.Tag);
            return entityProperties;
        }

        private void deleteColumnButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null) dataGridView.Columns.Remove(dataGridView.CurrentCell.OwningColumn);
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count == 0)
            {
                AddColumn((EntityProperty)entityPropertyBindingSource.Current);
            }
            dataGridView.Rows.Add();
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null) dataGridView.Rows.Remove(dataGridView.CurrentCell.OwningRow);
        }

        private void deleteValueButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.CurrentCell.Tag = null;
                dataGridView.CurrentCell.Value = null;
            }
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null) InputValue((EntityProperty)dataGridView.CurrentCell.OwningColumn.Tag, dataGridView.CurrentCell);
        }

        private List<List<Condition>> GetConditions()
        {
            List<List<Condition>> conditions = new List<List<Condition>>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                List<Condition> rowCondition = new List<Condition>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    rowCondition.Add(cell.Tag as Condition);
                }
                conditions.Add(rowCondition);
            }
            return conditions;
        }
    }
}
