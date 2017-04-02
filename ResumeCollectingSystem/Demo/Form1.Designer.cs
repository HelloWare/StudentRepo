namespace Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.positionList = new System.Windows.Forms.ListBox();
            this.resumeCollectingSystemDataSet = new Demo.ResumeCollectingSystemDataSet();
            this.positionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.positionTableAdapter = new Demo.ResumeCollectingSystemDataSetTableAdapters.PositionTableAdapter();
            this.resumeCollectingSystemDataSet1 = new Demo.ResumeCollectingSystemDataSet1();
            this.degreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.degreeTableAdapter = new Demo.ResumeCollectingSystemDataSet1TableAdapters.DegreeTableAdapter();
            this.resumeCollectingSystemDataSet2 = new Demo.ResumeCollectingSystemDataSet2();
            this.genderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genderTableAdapter = new Demo.ResumeCollectingSystemDataSet2TableAdapters.GenderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.resumeCollectingSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumeCollectingSystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumeCollectingSystemDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get All Postions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // positionList
            // 
            this.positionList.DataSource = this.genderBindingSource;
            this.positionList.DisplayMember = "Name";
            this.positionList.FormattingEnabled = true;
            this.positionList.Location = new System.Drawing.Point(13, 56);
            this.positionList.Name = "positionList";
            this.positionList.Size = new System.Drawing.Size(442, 212);
            this.positionList.TabIndex = 3;
            // 
            // resumeCollectingSystemDataSet
            // 
            this.resumeCollectingSystemDataSet.DataSetName = "ResumeCollectingSystemDataSet";
            this.resumeCollectingSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // positionBindingSource
            // 
            this.positionBindingSource.DataMember = "Position";
            this.positionBindingSource.DataSource = this.resumeCollectingSystemDataSet;
            // 
            // positionTableAdapter
            // 
            this.positionTableAdapter.ClearBeforeFill = true;
            // 
            // resumeCollectingSystemDataSet1
            // 
            this.resumeCollectingSystemDataSet1.DataSetName = "ResumeCollectingSystemDataSet1";
            this.resumeCollectingSystemDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // degreeBindingSource
            // 
            this.degreeBindingSource.DataMember = "Degree";
            this.degreeBindingSource.DataSource = this.resumeCollectingSystemDataSet1;
            // 
            // degreeTableAdapter
            // 
            this.degreeTableAdapter.ClearBeforeFill = true;
            // 
            // resumeCollectingSystemDataSet2
            // 
            this.resumeCollectingSystemDataSet2.DataSetName = "ResumeCollectingSystemDataSet2";
            this.resumeCollectingSystemDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // genderBindingSource
            // 
            this.genderBindingSource.DataMember = "Gender";
            this.genderBindingSource.DataSource = this.resumeCollectingSystemDataSet2;
            // 
            // genderTableAdapter
            // 
            this.genderTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 281);
            this.Controls.Add(this.positionList);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resumeCollectingSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumeCollectingSystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degreeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resumeCollectingSystemDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox positionList;
        private ResumeCollectingSystemDataSet resumeCollectingSystemDataSet;
        private System.Windows.Forms.BindingSource positionBindingSource;
        private ResumeCollectingSystemDataSetTableAdapters.PositionTableAdapter positionTableAdapter;
        private ResumeCollectingSystemDataSet1 resumeCollectingSystemDataSet1;
        private System.Windows.Forms.BindingSource degreeBindingSource;
        private ResumeCollectingSystemDataSet1TableAdapters.DegreeTableAdapter degreeTableAdapter;
        private ResumeCollectingSystemDataSet2 resumeCollectingSystemDataSet2;
        private System.Windows.Forms.BindingSource genderBindingSource;
        private ResumeCollectingSystemDataSet2TableAdapters.GenderTableAdapter genderTableAdapter;
    }
}

