
namespace StoreManagmentSystem.Forms.Invoices.SupplyInvoices
{
    partial class AddSupplyInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplyInvoice));
            this.gb_mainInfo = new System.Windows.Forms.GroupBox();
            this.btn_cont = new System.Windows.Forms.Button();
            this.gb_SIData = new System.Windows.Forms.GroupBox();
            this.txt_currentDate = new System.Windows.Forms.TextBox();
            this.txt_invoiceNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pl_vendor = new System.Windows.Forms.Panel();
            this.cb_ven = new System.Windows.Forms.ComboBox();
            this.lb_selectVendor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_viewBy = new System.Windows.Forms.ComboBox();
            this.gb_itemData = new System.Windows.Forms.GroupBox();
            this.pl_afterStore = new System.Windows.Forms.Panel();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.nud_quantity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dp_ExpiringDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_measures = new System.Windows.Forms.ComboBox();
            this.dp_productionDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_store = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_item = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb_invoice = new System.Windows.Forms.GroupBox();
            this.pl_invoiceLabels = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_vendor = new System.Windows.Forms.Label();
            this.lb_invoiceNumber = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.dg_invoiceDetails = new System.Windows.Forms.DataGridView();
            this.gb_mainInfo.SuspendLayout();
            this.gb_SIData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pl_vendor.SuspendLayout();
            this.gb_itemData.SuspendLayout();
            this.pl_afterStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_quantity)).BeginInit();
            this.gb_invoice.SuspendLayout();
            this.pl_invoiceLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_invoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_mainInfo
            // 
            resources.ApplyResources(this.gb_mainInfo, "gb_mainInfo");
            this.gb_mainInfo.Controls.Add(this.btn_cont);
            this.gb_mainInfo.Controls.Add(this.gb_SIData);
            this.gb_mainInfo.Controls.Add(this.groupBox1);
            this.gb_mainInfo.Name = "gb_mainInfo";
            this.gb_mainInfo.TabStop = false;
            // 
            // btn_cont
            // 
            resources.ApplyResources(this.btn_cont, "btn_cont");
            this.btn_cont.Name = "btn_cont";
            this.btn_cont.UseVisualStyleBackColor = true;
            this.btn_cont.Click += new System.EventHandler(this.btn_cont_Click);
            // 
            // gb_SIData
            // 
            resources.ApplyResources(this.gb_SIData, "gb_SIData");
            this.gb_SIData.Controls.Add(this.txt_currentDate);
            this.gb_SIData.Controls.Add(this.txt_invoiceNo);
            this.gb_SIData.Controls.Add(this.label2);
            this.gb_SIData.Controls.Add(this.label1);
            this.gb_SIData.Name = "gb_SIData";
            this.gb_SIData.TabStop = false;
            // 
            // txt_currentDate
            // 
            resources.ApplyResources(this.txt_currentDate, "txt_currentDate");
            this.txt_currentDate.Name = "txt_currentDate";
            // 
            // txt_invoiceNo
            // 
            resources.ApplyResources(this.txt_invoiceNo, "txt_invoiceNo");
            this.txt_invoiceNo.Name = "txt_invoiceNo";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.pl_vendor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_viewBy);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pl_vendor
            // 
            resources.ApplyResources(this.pl_vendor, "pl_vendor");
            this.pl_vendor.Controls.Add(this.cb_ven);
            this.pl_vendor.Controls.Add(this.lb_selectVendor);
            this.pl_vendor.Name = "pl_vendor";
            // 
            // cb_ven
            // 
            resources.ApplyResources(this.cb_ven, "cb_ven");
            this.cb_ven.FormattingEnabled = true;
            this.cb_ven.Name = "cb_ven";
            // 
            // lb_selectVendor
            // 
            resources.ApplyResources(this.lb_selectVendor, "lb_selectVendor");
            this.lb_selectVendor.Name = "lb_selectVendor";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cb_viewBy
            // 
            resources.ApplyResources(this.cb_viewBy, "cb_viewBy");
            this.cb_viewBy.FormattingEnabled = true;
            this.cb_viewBy.Name = "cb_viewBy";
            this.cb_viewBy.SelectedIndexChanged += new System.EventHandler(this.cb_viewBy_SelectedIndexChanged);
            // 
            // gb_itemData
            // 
            resources.ApplyResources(this.gb_itemData, "gb_itemData");
            this.gb_itemData.Controls.Add(this.pl_afterStore);
            this.gb_itemData.Controls.Add(this.cb_store);
            this.gb_itemData.Controls.Add(this.label6);
            this.gb_itemData.Controls.Add(this.cb_item);
            this.gb_itemData.Controls.Add(this.label7);
            this.gb_itemData.Name = "gb_itemData";
            this.gb_itemData.TabStop = false;
            // 
            // pl_afterStore
            // 
            resources.ApplyResources(this.pl_afterStore, "pl_afterStore");
            this.pl_afterStore.Controls.Add(this.txt_note);
            this.pl_afterStore.Controls.Add(this.btn_add);
            this.pl_afterStore.Controls.Add(this.nud_quantity);
            this.pl_afterStore.Controls.Add(this.label10);
            this.pl_afterStore.Controls.Add(this.label8);
            this.pl_afterStore.Controls.Add(this.dp_ExpiringDate);
            this.pl_afterStore.Controls.Add(this.label4);
            this.pl_afterStore.Controls.Add(this.cb_measures);
            this.pl_afterStore.Controls.Add(this.dp_productionDate);
            this.pl_afterStore.Controls.Add(this.label9);
            this.pl_afterStore.Controls.Add(this.label5);
            this.pl_afterStore.Name = "pl_afterStore";
            // 
            // txt_note
            // 
            resources.ApplyResources(this.txt_note, "txt_note");
            this.txt_note.Name = "txt_note";
            // 
            // btn_add
            // 
            resources.ApplyResources(this.btn_add, "btn_add");
            this.btn_add.Name = "btn_add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // nud_quantity
            // 
            resources.ApplyResources(this.nud_quantity, "nud_quantity");
            this.nud_quantity.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nud_quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_quantity.Name = "nud_quantity";
            this.nud_quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // dp_ExpiringDate
            // 
            resources.ApplyResources(this.dp_ExpiringDate, "dp_ExpiringDate");
            this.dp_ExpiringDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_ExpiringDate.Name = "dp_ExpiringDate";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cb_measures
            // 
            resources.ApplyResources(this.cb_measures, "cb_measures");
            this.cb_measures.FormattingEnabled = true;
            this.cb_measures.Name = "cb_measures";
            // 
            // dp_productionDate
            // 
            resources.ApplyResources(this.dp_productionDate, "dp_productionDate");
            this.dp_productionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_productionDate.Name = "dp_productionDate";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cb_store
            // 
            resources.ApplyResources(this.cb_store, "cb_store");
            this.cb_store.FormattingEnabled = true;
            this.cb_store.Name = "cb_store";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cb_item
            // 
            resources.ApplyResources(this.cb_item, "cb_item");
            this.cb_item.FormattingEnabled = true;
            this.cb_item.Name = "cb_item";
            this.cb_item.SelectedIndexChanged += new System.EventHandler(this.cb_item_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // gb_invoice
            // 
            resources.ApplyResources(this.gb_invoice, "gb_invoice");
            this.gb_invoice.Controls.Add(this.pl_invoiceLabels);
            this.gb_invoice.Controls.Add(this.btn_save);
            this.gb_invoice.Controls.Add(this.dg_invoiceDetails);
            this.gb_invoice.Name = "gb_invoice";
            this.gb_invoice.TabStop = false;
            // 
            // pl_invoiceLabels
            // 
            resources.ApplyResources(this.pl_invoiceLabels, "pl_invoiceLabels");
            this.pl_invoiceLabels.Controls.Add(this.label11);
            this.pl_invoiceLabels.Controls.Add(this.lb_date);
            this.pl_invoiceLabels.Controls.Add(this.label12);
            this.pl_invoiceLabels.Controls.Add(this.lb_vendor);
            this.pl_invoiceLabels.Controls.Add(this.lb_invoiceNumber);
            this.pl_invoiceLabels.Controls.Add(this.label13);
            this.pl_invoiceLabels.Name = "pl_invoiceLabels";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // lb_date
            // 
            resources.ApplyResources(this.lb_date, "lb_date");
            this.lb_date.Name = "lb_date";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // lb_vendor
            // 
            resources.ApplyResources(this.lb_vendor, "lb_vendor");
            this.lb_vendor.Name = "lb_vendor";
            // 
            // lb_invoiceNumber
            // 
            resources.ApplyResources(this.lb_invoiceNumber, "lb_invoiceNumber");
            this.lb_invoiceNumber.Name = "lb_invoiceNumber";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // btn_save
            // 
            resources.ApplyResources(this.btn_save, "btn_save");
            this.btn_save.BackColor = System.Drawing.Color.Green;
            this.btn_save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_save.Name = "btn_save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dg_invoiceDetails
            // 
            resources.ApplyResources(this.dg_invoiceDetails, "dg_invoiceDetails");
            this.dg_invoiceDetails.AllowUserToAddRows = false;
            this.dg_invoiceDetails.AllowUserToDeleteRows = false;
            this.dg_invoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_invoiceDetails.Name = "dg_invoiceDetails";
            this.dg_invoiceDetails.ReadOnly = true;
            this.dg_invoiceDetails.RowTemplate.Height = 28;
            this.dg_invoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // AddSupplyInvoice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_invoice);
            this.Controls.Add(this.gb_itemData);
            this.Controls.Add(this.gb_mainInfo);
            this.Name = "AddSupplyInvoice";
            this.gb_mainInfo.ResumeLayout(false);
            this.gb_SIData.ResumeLayout(false);
            this.gb_SIData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pl_vendor.ResumeLayout(false);
            this.pl_vendor.PerformLayout();
            this.gb_itemData.ResumeLayout(false);
            this.gb_itemData.PerformLayout();
            this.pl_afterStore.ResumeLayout(false);
            this.pl_afterStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_quantity)).EndInit();
            this.gb_invoice.ResumeLayout(false);
            this.pl_invoiceLabels.ResumeLayout(false);
            this.pl_invoiceLabels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_invoiceDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_mainInfo;
        private System.Windows.Forms.Button btn_cont;
        private System.Windows.Forms.GroupBox gb_SIData;
        private System.Windows.Forms.TextBox txt_currentDate;
        private System.Windows.Forms.TextBox txt_invoiceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pl_vendor;
        private System.Windows.Forms.ComboBox cb_ven;
        private System.Windows.Forms.Label lb_selectVendor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_viewBy;
        private System.Windows.Forms.GroupBox gb_itemData;
        private System.Windows.Forms.Panel pl_afterStore;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.NumericUpDown nud_quantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dp_ExpiringDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_measures;
        private System.Windows.Forms.DateTimePicker dp_productionDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_store;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_item;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gb_invoice;
        private System.Windows.Forms.Panel pl_invoiceLabels;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_vendor;
        private System.Windows.Forms.Label lb_invoiceNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dg_invoiceDetails;
    }
}