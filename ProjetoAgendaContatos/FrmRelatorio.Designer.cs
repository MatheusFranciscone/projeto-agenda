namespace ProjetoAgendaContatos
{
    partial class FrmRelatorio
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorio));
            this.tbcontatoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Contatos = new ProjetoAgendaContatos.DS_Contatos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbcontatoTableAdapter = new ProjetoAgendaContatos.DS_ContatosTableAdapters.tbcontatoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbcontatoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Contatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcontatoBindingSource
            // 
            this.tbcontatoBindingSource.DataMember = "tbcontato";
            this.tbcontatoBindingSource.DataSource = this.DS_Contatos;
            // 
            // DS_Contatos
            // 
            this.DS_Contatos.DataSetName = "DS_Contatos";
            this.DS_Contatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbcontatoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjetoAgendaContatos.Report_Contato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(661, 406);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbcontatoTableAdapter
            // 
            this.tbcontatoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 406);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.Load += new System.EventHandler(this.frmRelatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbcontatoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Contatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbcontatoBindingSource;
        private DS_Contatos DS_Contatos;
        private DS_ContatosTableAdapters.tbcontatoTableAdapter tbcontatoTableAdapter;
    }
}