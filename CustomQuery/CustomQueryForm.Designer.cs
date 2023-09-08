﻿
namespace CustomQuery {
    partial class CustomQueryForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpProjection = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btClearSelection = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.flpProj = new System.Windows.Forms.FlowLayoutPanel();
            this.tpConditions = new System.Windows.Forms.TabPage();
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbCondСonnective = new System.Windows.Forms.ComboBox();
            this.cbCondTables = new System.Windows.Forms.ComboBox();
            this.cbCondAttribute = new System.Windows.Forms.ComboBox();
            this.cbCondOperator = new System.Windows.Forms.ComboBox();
            this.cbCondValue = new System.Windows.Forms.ComboBox();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.dtpValue = new System.Windows.Forms.DateTimePicker();
            this.btAddCondition = new System.Windows.Forms.Button();
            this.btDelCondition = new System.Windows.Forms.Button();
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btSelectDatabase = new System.Windows.Forms.Button();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btExecute = new System.Windows.Forms.Button();
            this.btShowQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tpProjection.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.tpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpProjection);
            this.tabControl.Controls.Add(this.tpConditions);
            this.tabControl.Controls.Add(this.tpOrder);
            this.tabControl.Controls.Add(this.tpResult);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(934, 569);
            this.tabControl.TabIndex = 1;
            // 
            // tpProjection
            // 
            this.tpProjection.Controls.Add(this.flowLayoutPanel4);
            this.tpProjection.Controls.Add(this.flpProj);
            this.tpProjection.Location = new System.Drawing.Point(4, 24);
            this.tpProjection.Name = "tpProjection";
            this.tpProjection.Padding = new System.Windows.Forms.Padding(3);
            this.tpProjection.Size = new System.Drawing.Size(926, 541);
            this.tpProjection.TabIndex = 0;
            this.tpProjection.Text = "Поля";
            this.tpProjection.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.btClearSelection);
            this.flowLayoutPanel4.Controls.Add(this.btSelectAll);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 507);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(920, 31);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // btClearSelection
            // 
            this.btClearSelection.AutoSize = true;
            this.btClearSelection.Location = new System.Drawing.Point(809, 3);
            this.btClearSelection.Name = "btClearSelection";
            this.btClearSelection.Size = new System.Drawing.Size(108, 25);
            this.btClearSelection.TabIndex = 0;
            this.btClearSelection.Text = "Очистить выбор";
            this.btClearSelection.UseVisualStyleBackColor = true;
            this.btClearSelection.Click += new System.EventHandler(this.btClearSelection_Click);
            // 
            // btSelectAll
            // 
            this.btSelectAll.AutoSize = true;
            this.btSelectAll.Location = new System.Drawing.Point(718, 3);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(85, 25);
            this.btSelectAll.TabIndex = 1;
            this.btSelectAll.Text = "Выбрать всё";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // flpProj
            // 
            this.flpProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProj.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProj.Location = new System.Drawing.Point(3, 3);
            this.flpProj.Name = "flpProj";
            this.flpProj.Size = new System.Drawing.Size(920, 535);
            this.flpProj.TabIndex = 0;
            // 
            // tpConditions
            // 
            this.tpConditions.Controls.Add(this.dgvConditions);
            this.tpConditions.Controls.Add(this.flowLayoutPanel3);
            this.tpConditions.Location = new System.Drawing.Point(4, 24);
            this.tpConditions.Name = "tpConditions";
            this.tpConditions.Padding = new System.Windows.Forms.Padding(3);
            this.tpConditions.Size = new System.Drawing.Size(926, 541);
            this.tpConditions.TabIndex = 1;
            this.tpConditions.Text = "Условия";
            this.tpConditions.UseVisualStyleBackColor = true;
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConditions.Location = new System.Drawing.Point(3, 3);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.ReadOnly = true;
            this.dgvConditions.RowTemplate.Height = 25;
            this.dgvConditions.Size = new System.Drawing.Size(920, 475);
            this.dgvConditions.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.cbCondСonnective);
            this.flowLayoutPanel3.Controls.Add(this.cbCondTables);
            this.flowLayoutPanel3.Controls.Add(this.cbCondAttribute);
            this.flowLayoutPanel3.Controls.Add(this.cbCondOperator);
            this.flowLayoutPanel3.Controls.Add(this.cbCondValue);
            this.flowLayoutPanel3.Controls.Add(this.nudValue);
            this.flowLayoutPanel3.Controls.Add(this.dtpValue);
            this.flowLayoutPanel3.Controls.Add(this.btAddCondition);
            this.flowLayoutPanel3.Controls.Add(this.btDelCondition);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 478);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(920, 60);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // cbCondСonnective
            // 
            this.cbCondСonnective.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondСonnective.FormattingEnabled = true;
            this.cbCondСonnective.Location = new System.Drawing.Point(3, 3);
            this.cbCondСonnective.Name = "cbCondСonnective";
            this.cbCondСonnective.Size = new System.Drawing.Size(74, 23);
            this.cbCondСonnective.TabIndex = 4;
            // 
            // cbCondTables
            // 
            this.cbCondTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondTables.FormattingEnabled = true;
            this.cbCondTables.Location = new System.Drawing.Point(83, 3);
            this.cbCondTables.Name = "cbCondTables";
            this.cbCondTables.Size = new System.Drawing.Size(121, 23);
            this.cbCondTables.TabIndex = 0;
            this.cbCondTables.SelectedIndexChanged += new System.EventHandler(this.cbCondTables_SelectedIndexChanged);
            // 
            // cbCondAttribute
            // 
            this.cbCondAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondAttribute.FormattingEnabled = true;
            this.cbCondAttribute.Location = new System.Drawing.Point(210, 3);
            this.cbCondAttribute.Name = "cbCondAttribute";
            this.cbCondAttribute.Size = new System.Drawing.Size(121, 23);
            this.cbCondAttribute.TabIndex = 1;
            this.cbCondAttribute.SelectedIndexChanged += new System.EventHandler(this.cbCondAttribute_SelectedIndexChanged);
            // 
            // cbCondOperator
            // 
            this.cbCondOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondOperator.FormattingEnabled = true;
            this.cbCondOperator.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            "<"});
            this.cbCondOperator.Location = new System.Drawing.Point(337, 3);
            this.cbCondOperator.Name = "cbCondOperator";
            this.cbCondOperator.Size = new System.Drawing.Size(121, 23);
            this.cbCondOperator.TabIndex = 2;
            // 
            // cbCondValue
            // 
            this.cbCondValue.FormattingEnabled = true;
            this.cbCondValue.Location = new System.Drawing.Point(464, 3);
            this.cbCondValue.Name = "cbCondValue";
            this.cbCondValue.Size = new System.Drawing.Size(121, 23);
            this.cbCondValue.TabIndex = 3;
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(591, 3);
            this.nudValue.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudValue.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(60, 23);
            this.nudValue.TabIndex = 6;
            // 
            // dtpValue
            // 
            this.dtpValue.Location = new System.Drawing.Point(657, 3);
            this.dtpValue.Name = "dtpValue";
            this.dtpValue.Size = new System.Drawing.Size(123, 23);
            this.dtpValue.TabIndex = 7;
            // 
            // btAddCondition
            // 
            this.btAddCondition.AutoSize = true;
            this.btAddCondition.Location = new System.Drawing.Point(786, 3);
            this.btAddCondition.Name = "btAddCondition";
            this.btAddCondition.Size = new System.Drawing.Size(69, 25);
            this.btAddCondition.TabIndex = 5;
            this.btAddCondition.Text = "Добавить";
            this.btAddCondition.UseVisualStyleBackColor = true;
            this.btAddCondition.Click += new System.EventHandler(this.btAddCondition_Click);
            // 
            // btDelCondition
            // 
            this.btDelCondition.Location = new System.Drawing.Point(3, 34);
            this.btDelCondition.Name = "btDelCondition";
            this.btDelCondition.Size = new System.Drawing.Size(63, 23);
            this.btDelCondition.TabIndex = 8;
            this.btDelCondition.Text = "Удалить";
            this.btDelCondition.UseVisualStyleBackColor = true;
            this.btDelCondition.Click += new System.EventHandler(this.btDelCondition_Click);
            // 
            // tpOrder
            // 
            this.tpOrder.Location = new System.Drawing.Point(4, 24);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(926, 541);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Порядок";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.dgvResult);
            this.tpResult.Location = new System.Drawing.Point(4, 24);
            this.tpResult.Name = "tpResult";
            this.tpResult.Size = new System.Drawing.Size(926, 541);
            this.tpResult.TabIndex = 3;
            this.tpResult.Text = "Результат";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 25;
            this.dgvResult.Size = new System.Drawing.Size(926, 541);
            this.dgvResult.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btSelectDatabase);
            this.flowLayoutPanel1.Controls.Add(this.cbDatabase);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(934, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btSelectDatabase
            // 
            this.btSelectDatabase.AutoSize = true;
            this.btSelectDatabase.Location = new System.Drawing.Point(856, 3);
            this.btSelectDatabase.Name = "btSelectDatabase";
            this.btSelectDatabase.Size = new System.Drawing.Size(75, 25);
            this.btSelectDatabase.TabIndex = 1;
            this.btSelectDatabase.Text = "Выбрать";
            this.btSelectDatabase.UseVisualStyleBackColor = true;
            this.btSelectDatabase.Click += new System.EventHandler(this.btSelectDatabase_Click);
            // 
            // cbDatabase
            // 
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(729, 3);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(121, 23);
            this.cbDatabase.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.btCancel);
            this.flowLayoutPanel2.Controls.Add(this.btExecute);
            this.flowLayoutPanel2.Controls.Add(this.btShowQuery);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 600);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(934, 31);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btCancel
            // 
            this.btCancel.AutoSize = true;
            this.btCancel.Location = new System.Drawing.Point(856, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btExecute
            // 
            this.btExecute.AutoSize = true;
            this.btExecute.Location = new System.Drawing.Point(771, 3);
            this.btExecute.Name = "btExecute";
            this.btExecute.Size = new System.Drawing.Size(79, 25);
            this.btExecute.TabIndex = 1;
            this.btExecute.Text = "Выполнить";
            this.btExecute.UseVisualStyleBackColor = true;
            this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
            // 
            // btShowQuery
            // 
            this.btShowQuery.AutoSize = true;
            this.btShowQuery.Location = new System.Drawing.Point(657, 3);
            this.btShowQuery.Name = "btShowQuery";
            this.btShowQuery.Size = new System.Drawing.Size(108, 25);
            this.btShowQuery.TabIndex = 2;
            this.btShowQuery.Text = "Показать запрос";
            this.btShowQuery.UseVisualStyleBackColor = true;
            this.btShowQuery.Click += new System.EventHandler(this.btShowQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 569);
            this.panel1.TabIndex = 4;
            // 
            // CustomQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(934, 631);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CustomQueryForm";
            this.Text = "Нестандартный запрос";
            this.tabControl.ResumeLayout(false);
            this.tpProjection.ResumeLayout(false);
            this.tpProjection.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tpConditions.ResumeLayout(false);
            this.tpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.tpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpProjection;
        private System.Windows.Forms.TabPage tpConditions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Button btSelectDatabase;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btExecute;
        private System.Windows.Forms.Button btShowQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btClearSelection;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.FlowLayoutPanel flpProj;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox cbCondTables;
        private System.Windows.Forms.ComboBox cbCondAttribute;
        private System.Windows.Forms.ComboBox cbCondOperator;
        private System.Windows.Forms.ComboBox cbCondValue;
        private System.Windows.Forms.ComboBox cbCondСonnective;
        private System.Windows.Forms.Button btAddCondition;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.DateTimePicker dtpValue;
        private System.Windows.Forms.DataGridView dgvConditions;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btDelCondition;
    }
}

