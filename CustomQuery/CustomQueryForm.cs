using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace CustomQuery
{
    public partial class CustomQueryForm : Form
    {
        private string _templateConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Username = "postgres",
            Password = "postgres"
        }.ConnectionString;

        private string connStr;
        private int? goodDB;

        private DBModel _dbModel;
        private QueryBuilder query;

        private BindingList<Condition> Conditions=new BindingList<Condition>();
        private List<Tuple<string,string>> Fields = new();

        public CustomQueryForm()
        {
            InitializeComponent();

            InitializeDatabaseList();

            tabControl.Enabled = false;
            btExecute.Enabled = false;
            btSelectAll.Enabled = false;
            btShowQuery.Enabled = false;
            btClearSelection.Enabled = false;
            btDelCondition.Enabled = false;

            //connStr = new NpgsqlConnectionStringBuilder(_templateConnStr) { Database = "DVDRental" }.ConnectionString;

            //_dbModel = new DBModel(connStr);
            //query = new QueryBuilder(_dbModel);

            //InitializeFieldTab();
            //InitializeConditionTab();
        }

        private void InitializeFieldTab()
        {
            flpProj.Controls.Clear();

            var data = new Dictionary<string, List<string>>();
            using(var conn=new NpgsqlConnection(connStr))
            {
                conn.Open();

                using(var command=new NpgsqlCommand()
                {
                    Connection=conn,
                    CommandText= @"select table_name, column_name from information_schema.columns
                                    join pg_tables on table_name=tablename
                                    where table_schema='public'
                                    ORDER BY table_name,column_name, ordinal_position;"
                })
                {
                    var reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        if(!data.ContainsKey(reader[0].ToString()))
                            data.Add(reader[0].ToString(),new List<string>());

                        data[reader[0].ToString()].Add(reader[1].ToString());
                    }
                }
            }

            foreach(var table in data)
            {
                var column = table.Value;

                var groupBox = new System.Windows.Forms.GroupBox();
                groupBox.Text = table.Key;
                var flp = new FlowLayoutPanel();
                flp.AutoSize = true;
                flp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flp.WrapContents = false;
                flp.Dock = DockStyle.Fill;
                flp.FlowDirection = FlowDirection.TopDown;

                groupBox.Controls.Add(flp);

                foreach(var i in column)
                {
                    var checkBox = new CheckBox();
                    checkBox.Text = i;
                    checkBox.AutoSize = true;
                    checkBox.Dock = DockStyle.Top;
                    flp.Controls.Add(checkBox);
                }

                groupBox.AutoSize = true;
                groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flpProj.Controls.Add(groupBox);
            }
        }

        private void InitializeDatabaseList()
        {
            var _connStr = new NpgsqlConnectionStringBuilder(_templateConnStr) { Database = "postgres" }.ConnectionString;

            using(var conn=new NpgsqlConnection(_connStr))
            {
                conn.Open();

                using (var command = new NpgsqlCommand()
                {
                    Connection = conn,
                    CommandText = @"select datname from pg_catalog.pg_database
                                    where datistemplate=false
                                    order by datname;"
                })
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cbDatabase.Items.Add(reader[0]);
                    }

                    cbDatabase.SelectedIndex = 0;
                }
            }
        }

        private void InitializeConditionTab()
        {
            Conditions.Clear();
            dgvConditions.DataSource = Conditions;

            cbCondTables.Items.Clear();
            cbCondTables.Items.AddRange(_dbModel.Tables.ToArray());
            cbCondTables.SelectedIndex = 0;

            cbCondOperator.SelectedIndex = 0;
        }

        private void cbCondTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTable = (string)cbCondTables.SelectedItem;

            if (selectedTable is null)
                return;

            cbCondAttribute.Items.Clear();
            cbCondAttribute.Items.AddRange(_dbModel.GetTableAttributes(selectedTable).ToArray());
            cbCondAttribute.SelectedIndex = 0;
        }

        private void btAddCondition_Click(object sender, EventArgs e)
        {
            var str = cbCondAttribute.SelectedItem.ToString();

            var type = str.Substring(str.IndexOf('<') + 1, 1);

            if (type == "S")
            {
                Conditions.Add(new Condition
                {
                    TableName = cbCondTables.Text,
                    AttributeName = (cbCondAttribute.SelectedItem as Attribute)?.Name,
                    Operator = cbCondOperator.Text,
                    Value = "'"+cbCondValue.Text+"'"
                });
            }

            if(type=="N")
            {
                Conditions.Add(new Condition
                {
                    TableName = cbCondTables.Text,
                    AttributeName = (cbCondAttribute.SelectedItem as Attribute)?.Name,
                    Operator = cbCondOperator.Text,
                    Value = nudValue.Value
                });
            }

            if(type=="D")
            {
                Conditions.Add(new Condition
                {
                    TableName = cbCondTables.Text,
                    AttributeName = (cbCondAttribute.SelectedItem as Attribute)?.Name,
                    Operator = cbCondOperator.Text,
                    Value = "'"+dtpValue.Value.ToString("yyyy-MM-dd")+"'"
                }) ;
            }

            btAddCondition.Enabled = true;
        }

        private void btShowQuery_Click(object sender, EventArgs e)
        {
            Fields = FillFields();
            MessageBox.Show(query.BuildQuery(Conditions.ToList(),Fields));
        }

        private List<Tuple<string,string>> FillFields()
        {
            List<Tuple<string,string>> fields = new();

            foreach (var i in flpProj.Controls)
            {
                GroupBox gr = (GroupBox)i;
                FlowLayoutPanel panel = (FlowLayoutPanel)gr.Controls[0];
                foreach (var j in panel.Controls)
                {
                    CheckBox checkBox = (CheckBox)j;
                    if (checkBox.Checked)
                        fields.Add(new Tuple<string, string>(gr.Text, checkBox.Text));
                }
            }

            return fields;
        }

        private void btExecute_Click(object sender, EventArgs e)
        {
            if(Fields.Count==0&&Conditions.Count==0)
            {
                return;
            }    

            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string com = query.BuildQuery(Conditions.ToList(), Fields);

                if(com.Contains("Нет связи между таблицами"))
                {
                    MessageBox.Show("Нет связи между таблицами");
                    return;
                }

                using (var command=new NpgsqlCommand(com,conn))
                {

                    var reader = command.ExecuteReader();

                    for (int i = 0; i < reader.FieldCount; ++i)
                        dgvResult.Columns.Add(reader.GetName(i), reader.GetName(i));

                    while (reader.Read())
                    {
                        DataGridViewRow dgvRow = new DataGridViewRow();

                        for(int i=0;i<reader.FieldCount;++i)
                            dgvRow.Cells.Add(new DataGridViewTextBoxCell() { Value=reader[i]});

                        dgvResult.Rows.Add(dgvRow);
                    }

                    tabControl.SelectTab("tpResult");
                }
            }
        }

        private void btSelectDatabase_Click(object sender, EventArgs e)
        {
            connStr = new NpgsqlConnectionStringBuilder(_templateConnStr) { Database = cbDatabase.Text }.ConnectionString;

            _dbModel = new DBModel(connStr);
            query = new QueryBuilder(_dbModel);

            if (_dbModel.Attributes.Count != 0)
            {
                tabControl.Enabled = true;
                btExecute.Enabled = true;
                btSelectAll.Enabled = true;
                btShowQuery.Enabled = true;
                btClearSelection.Enabled = true;
                goodDB = cbDatabase.SelectedIndex;
                btDelCondition.Enabled = true;
            }
            else
            {
                if (goodDB.HasValue)
                {
                    cbDatabase.SelectedIndex = (int)goodDB;
                    btSelectDatabase_Click(null, null);
                }
                else
                {
                    return;
                }
            }
            InitializeFieldTab();
            InitializeConditionTab();
        }

        private void btDelCondition_Click(object sender, EventArgs e)
        {
            Conditions.RemoveAt(dgvConditions.CurrentRow.Index);
            if (dgvConditions.Rows.Count == 0)
                btDelCondition.Enabled = false;
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            foreach(var i in flpProj.Controls)
            {
                GroupBox gr = (GroupBox)i;
                FlowLayoutPanel panel = (FlowLayoutPanel)gr.Controls[0];
                foreach(var j in panel.Controls)
                {
                    CheckBox checkBox = (CheckBox)j;
                    checkBox.Checked = true;
                }
            }
        }

        private void btClearSelection_Click(object sender, EventArgs e)
        {
            foreach (var i in flpProj.Controls)
            {
                GroupBox gr = (GroupBox)i;
                FlowLayoutPanel panel = (FlowLayoutPanel)gr.Controls[0];
                foreach (var j in panel.Controls)
                {
                    CheckBox checkBox = (CheckBox)j;
                    checkBox.Checked = false;
                }
            }
        }

        private void cbCondAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            var str = cbCondAttribute.SelectedItem.ToString();

            var type = str.Substring(str.IndexOf('<')+1, 1);

            MuteConditionButtons(type);

            if(type=="S")
            {
                var column = str.Substring(0, str.IndexOf('<') - 1);
                var table = cbCondTables.SelectedItem.ToString();
                using(var conn=new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    using (var command = new NpgsqlCommand()
                    {
                        Connection = conn,
                        CommandText = $"select distinct {column} from {table} order by {column}"
                    })
                    {
                        command.Parameters.AddWithValue("@column", column);

                        var reader = command.ExecuteReader();

                        var values = new List<string>();

                        while(reader.Read())
                        {
                            values.Add(reader[0].ToString());
                        }

                        cbCondValue.Items.AddRange(values.ToArray());
                    }
                }
            }
        }

        private void MuteConditionButtons(string type)
        {
            if(type=="N")
            {
                cbCondValue.Enabled = false;
                cbCondValue.Visible = false;

                nudValue.Enabled = true;
                nudValue.Visible = true;

                dtpValue.Enabled = false;
                dtpValue.Visible = false;
            }

            if(type=="S")
            {
                cbCondValue.Enabled = true;
                cbCondValue.Visible =true;

                nudValue.Enabled = false;
                nudValue.Visible = false;

                dtpValue.Enabled = false;
                dtpValue.Visible = false;
            }

            if(type=="D")
            {
                cbCondValue.Enabled = false;
                cbCondValue.Visible = false;

                nudValue.Enabled = false;
                nudValue.Visible = false;

                dtpValue.Enabled = true;
                dtpValue.Visible = true;
            }
        }
    }
}