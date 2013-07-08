namespace HCSAnalyzer.Classes.Machine_Learning.ClusteringInfo
{
    partial class PanelForParamManual
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.comboBoxForDescriptorManualClustering = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.comboBoxForDescriptorManualClustering);
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(3, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(231, 264);
            this.panel.TabIndex = 1;
            // 
            // comboBoxForDescriptorManualClustering
            // 
            this.comboBoxForDescriptorManualClustering.FormattingEnabled = true;
            this.comboBoxForDescriptorManualClustering.Location = new System.Drawing.Point(92, 37);
            this.comboBoxForDescriptorManualClustering.Name = "comboBoxForDescriptorManualClustering";
            this.comboBoxForDescriptorManualClustering.Size = new System.Drawing.Size(112, 21);
            this.comboBoxForDescriptorManualClustering.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descriptor";
            // 
            // PanelForParamManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "PanelForParamManual";
            this.Size = new System.Drawing.Size(237, 268);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.ComboBox comboBoxForDescriptorManualClustering;
    }
}
