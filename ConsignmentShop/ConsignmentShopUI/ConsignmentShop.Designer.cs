namespace ConsignmentShopUI
{
    partial class ConsignmentForm
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
            this.headerText = new System.Windows.Forms.Label();
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.itemListBoxLabel = new System.Windows.Forms.Label();
            this.addToCart = new System.Windows.Forms.Button();
            this.shoppingCartListBoxLabel = new System.Windows.Forms.Label();
            this.shoppingCartListBox = new System.Windows.Forms.ListBox();
            this.makePurchase = new System.Windows.Forms.Button();
            this.vendorListBoxLabel = new System.Windows.Forms.Label();
            this.vendorListBox = new System.Windows.Forms.ListBox();
            this.storeProfitLabel = new System.Windows.Forms.Label();
            this.storeProfitAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Font = new System.Drawing.Font("Poplar Std", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerText.Location = new System.Drawing.Point(9, 9);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(204, 57);
            this.headerText.TabIndex = 0;
            this.headerText.Text = "Test Store Z";
            // 
            // itemListBox
            // 
            this.itemListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.ItemHeight = 16;
            this.itemListBox.Location = new System.Drawing.Point(16, 103);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(215, 132);
            this.itemListBox.TabIndex = 1;
            // 
            // itemListBoxLabel
            // 
            this.itemListBoxLabel.AutoSize = true;
            this.itemListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemListBoxLabel.Location = new System.Drawing.Point(12, 80);
            this.itemListBoxLabel.Name = "itemListBoxLabel";
            this.itemListBoxLabel.Size = new System.Drawing.Size(103, 20);
            this.itemListBoxLabel.TabIndex = 2;
            this.itemListBoxLabel.Text = "Store Items";
            this.itemListBoxLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // addToCart
            // 
            this.addToCart.Location = new System.Drawing.Point(237, 158);
            this.addToCart.Name = "addToCart";
            this.addToCart.Size = new System.Drawing.Size(139, 31);
            this.addToCart.TabIndex = 3;
            this.addToCart.Text = "Add To Cart ->";
            this.addToCart.UseVisualStyleBackColor = true;
            this.addToCart.Click += new System.EventHandler(this.addToCart_Click);
            // 
            // shoppingCartListBoxLabel
            // 
            this.shoppingCartListBoxLabel.AutoSize = true;
            this.shoppingCartListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingCartListBoxLabel.Location = new System.Drawing.Point(399, 80);
            this.shoppingCartListBoxLabel.Name = "shoppingCartListBoxLabel";
            this.shoppingCartListBoxLabel.Size = new System.Drawing.Size(124, 20);
            this.shoppingCartListBoxLabel.TabIndex = 5;
            this.shoppingCartListBoxLabel.Text = "Shopping Cart";
            this.shoppingCartListBoxLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // shoppingCartListBox
            // 
            this.shoppingCartListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingCartListBox.FormattingEnabled = true;
            this.shoppingCartListBox.ItemHeight = 16;
            this.shoppingCartListBox.Location = new System.Drawing.Point(382, 103);
            this.shoppingCartListBox.Name = "shoppingCartListBox";
            this.shoppingCartListBox.Size = new System.Drawing.Size(215, 132);
            this.shoppingCartListBox.TabIndex = 4;
            this.shoppingCartListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // makePurchase
            // 
            this.makePurchase.Location = new System.Drawing.Point(507, 241);
            this.makePurchase.Name = "makePurchase";
            this.makePurchase.Size = new System.Drawing.Size(90, 32);
            this.makePurchase.TabIndex = 6;
            this.makePurchase.Text = "Purchase";
            this.makePurchase.UseVisualStyleBackColor = true;
            this.makePurchase.Click += new System.EventHandler(this.makePurchase_Click);
            // 
            // vendorListBoxLabel
            // 
            this.vendorListBoxLabel.AutoSize = true;
            this.vendorListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorListBoxLabel.Location = new System.Drawing.Point(12, 312);
            this.vendorListBoxLabel.Name = "vendorListBoxLabel";
            this.vendorListBoxLabel.Size = new System.Drawing.Size(76, 20);
            this.vendorListBoxLabel.TabIndex = 8;
            this.vendorListBoxLabel.Text = "Vendors";
            // 
            // vendorListBox
            // 
            this.vendorListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorListBox.FormattingEnabled = true;
            this.vendorListBox.ItemHeight = 16;
            this.vendorListBox.Location = new System.Drawing.Point(16, 335);
            this.vendorListBox.Name = "vendorListBox";
            this.vendorListBox.Size = new System.Drawing.Size(215, 132);
            this.vendorListBox.TabIndex = 7;
            // 
            // storeProfitLabel
            // 
            this.storeProfitLabel.AutoSize = true;
            this.storeProfitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeProfitLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.storeProfitLabel.Location = new System.Drawing.Point(378, 312);
            this.storeProfitLabel.Name = "storeProfitLabel";
            this.storeProfitLabel.Size = new System.Drawing.Size(101, 20);
            this.storeProfitLabel.TabIndex = 9;
            this.storeProfitLabel.Text = "Store Profit";
            // 
            // storeProfitAmount
            // 
            this.storeProfitAmount.AutoSize = true;
            this.storeProfitAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeProfitAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.storeProfitAmount.Location = new System.Drawing.Point(514, 312);
            this.storeProfitAmount.Name = "storeProfitAmount";
            this.storeProfitAmount.Size = new System.Drawing.Size(54, 20);
            this.storeProfitAmount.TabIndex = 10;
            this.storeProfitAmount.Text = "$0.00";
            // 
            // ConsignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 523);
            this.Controls.Add(this.storeProfitAmount);
            this.Controls.Add(this.storeProfitLabel);
            this.Controls.Add(this.vendorListBoxLabel);
            this.Controls.Add(this.vendorListBox);
            this.Controls.Add(this.makePurchase);
            this.Controls.Add(this.shoppingCartListBoxLabel);
            this.Controls.Add(this.shoppingCartListBox);
            this.Controls.Add(this.addToCart);
            this.Controls.Add(this.itemListBoxLabel);
            this.Controls.Add(this.itemListBox);
            this.Controls.Add(this.headerText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConsignmentForm";
            this.Text = "Consignment Shop";
            this.Load += new System.EventHandler(this.ConsignmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerText;
        private System.Windows.Forms.ListBox itemListBox;
        private System.Windows.Forms.Label itemListBoxLabel;
        private System.Windows.Forms.Button addToCart;
        private System.Windows.Forms.Label shoppingCartListBoxLabel;
        private System.Windows.Forms.ListBox shoppingCartListBox;
        private System.Windows.Forms.Button makePurchase;
        private System.Windows.Forms.Label vendorListBoxLabel;
        private System.Windows.Forms.ListBox vendorListBox;
        private System.Windows.Forms.Label storeProfitLabel;
        private System.Windows.Forms.Label storeProfitAmount;
    }
}

