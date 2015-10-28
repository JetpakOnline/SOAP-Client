namespace JetpakSoapClientExample
{
    partial class JetpakSoapClientForm
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
            this.searchTrpAltBtn = new System.Windows.Forms.Button();
            this.flightBookingTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.courierBookingTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.transportAlternativeGroupBox = new System.Windows.Forms.GroupBox();
            this.makeBookingButton = new System.Windows.Forms.Button();
            this.bookingDataGroupBox = new System.Windows.Forms.GroupBox();
            this.bookingTypeLabel = new System.Windows.Forms.Label();
            this.deliveryLabel = new System.Windows.Forms.Label();
            this.deliveryDateTextBox = new System.Windows.Forms.TextBox();
            this.pickupLabel = new System.Windows.Forms.Label();
            this.pickupDateTextBox = new System.Windows.Forms.TextBox();
            this.consigneeLabel = new System.Windows.Forms.Label();
            this.shipperLabel = new System.Windows.Forms.Label();
            this.toAddressTextBox = new System.Windows.Forms.TextBox();
            this.fromAddressTextBox = new System.Windows.Forms.TextBox();
            this.bookingResultGroupBox = new System.Windows.Forms.GroupBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.bookingDataGroupBox.SuspendLayout();
            this.bookingResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTrpAltBtn
            // 
            this.searchTrpAltBtn.Location = new System.Drawing.Point(409, 248);
            this.searchTrpAltBtn.Name = "searchTrpAltBtn";
            this.searchTrpAltBtn.Size = new System.Drawing.Size(75, 23);
            this.searchTrpAltBtn.TabIndex = 3;
            this.searchTrpAltBtn.Text = "Transport";
            this.searchTrpAltBtn.UseVisualStyleBackColor = true;
            this.searchTrpAltBtn.Click += new System.EventHandler(this.searchTrpAltBtn_Click);
            // 
            // flightBookingTypeRadioButton
            // 
            this.flightBookingTypeRadioButton.AutoSize = true;
            this.flightBookingTypeRadioButton.Location = new System.Drawing.Point(356, 78);
            this.flightBookingTypeRadioButton.Name = "flightBookingTypeRadioButton";
            this.flightBookingTypeRadioButton.Size = new System.Drawing.Size(50, 17);
            this.flightBookingTypeRadioButton.TabIndex = 1;
            this.flightBookingTypeRadioButton.Text = global::JetpakSoapClientExample.Properties.Resources.JPSClientForm_JPSClientForm__Flight;
            this.flightBookingTypeRadioButton.UseVisualStyleBackColor = true;
            this.flightBookingTypeRadioButton.CheckedChanged += new System.EventHandler(this.flightBookingTypeRadioButton_CheckedChanged);
            // 
            // courierBookingTypeRadioButton
            // 
            this.courierBookingTypeRadioButton.AutoSize = true;
            this.courierBookingTypeRadioButton.Checked = true;
            this.courierBookingTypeRadioButton.Location = new System.Drawing.Point(356, 55);
            this.courierBookingTypeRadioButton.Name = "courierBookingTypeRadioButton";
            this.courierBookingTypeRadioButton.Size = new System.Drawing.Size(58, 17);
            this.courierBookingTypeRadioButton.TabIndex = 0;
            this.courierBookingTypeRadioButton.TabStop = true;
            this.courierBookingTypeRadioButton.Text = global::JetpakSoapClientExample.Properties.Resources.JPSClientForm_JPSClientForm__Courier;
            this.courierBookingTypeRadioButton.UseVisualStyleBackColor = true;
            this.courierBookingTypeRadioButton.CheckedChanged += new System.EventHandler(this.courierBookingTypeRadioButton_CheckedChanged);
            // 
            // transportAlternativeGroupBox
            // 
            this.transportAlternativeGroupBox.Location = new System.Drawing.Point(31, 277);
            this.transportAlternativeGroupBox.Name = "transportAlternativeGroupBox";
            this.transportAlternativeGroupBox.Size = new System.Drawing.Size(453, 154);
            this.transportAlternativeGroupBox.TabIndex = 3;
            this.transportAlternativeGroupBox.TabStop = false;
            this.transportAlternativeGroupBox.Text = "Transport alternatives";
            // 
            // makeBookingButton
            // 
            this.makeBookingButton.Enabled = false;
            this.makeBookingButton.Location = new System.Drawing.Point(378, 437);
            this.makeBookingButton.Name = "makeBookingButton";
            this.makeBookingButton.Size = new System.Drawing.Size(106, 23);
            this.makeBookingButton.TabIndex = 4;
            this.makeBookingButton.Text = "Make booking";
            this.makeBookingButton.UseVisualStyleBackColor = true;
            this.makeBookingButton.Click += new System.EventHandler(this.makeBookingBtn_Click);
            // 
            // bookingDataGroupBox
            // 
            this.bookingDataGroupBox.Controls.Add(this.bookingTypeLabel);
            this.bookingDataGroupBox.Controls.Add(this.deliveryLabel);
            this.bookingDataGroupBox.Controls.Add(this.deliveryDateTextBox);
            this.bookingDataGroupBox.Controls.Add(this.pickupLabel);
            this.bookingDataGroupBox.Controls.Add(this.pickupDateTextBox);
            this.bookingDataGroupBox.Controls.Add(this.consigneeLabel);
            this.bookingDataGroupBox.Controls.Add(this.shipperLabel);
            this.bookingDataGroupBox.Controls.Add(this.toAddressTextBox);
            this.bookingDataGroupBox.Controls.Add(this.fromAddressTextBox);
            this.bookingDataGroupBox.Controls.Add(this.flightBookingTypeRadioButton);
            this.bookingDataGroupBox.Controls.Add(this.courierBookingTypeRadioButton);
            this.bookingDataGroupBox.Location = new System.Drawing.Point(31, 24);
            this.bookingDataGroupBox.Name = "bookingDataGroupBox";
            this.bookingDataGroupBox.Size = new System.Drawing.Size(453, 218);
            this.bookingDataGroupBox.TabIndex = 4;
            this.bookingDataGroupBox.TabStop = false;
            this.bookingDataGroupBox.Text = "Booking Data";
            // 
            // bookingTypeLabel
            // 
            this.bookingTypeLabel.AutoSize = true;
            this.bookingTypeLabel.Location = new System.Drawing.Point(353, 29);
            this.bookingTypeLabel.Name = "bookingTypeLabel";
            this.bookingTypeLabel.Size = new System.Drawing.Size(73, 13);
            this.bookingTypeLabel.TabIndex = 12;
            this.bookingTypeLabel.Text = "Booking Type";
            // 
            // deliveryLabel
            // 
            this.deliveryLabel.AutoSize = true;
            this.deliveryLabel.Location = new System.Drawing.Point(180, 155);
            this.deliveryLabel.Name = "deliveryLabel";
            this.deliveryLabel.Size = new System.Drawing.Size(77, 13);
            this.deliveryLabel.TabIndex = 11;
            this.deliveryLabel.Text = "Latest Delivery";
            // 
            // deliveryDateTextBox
            // 
            this.deliveryDateTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.deliveryDateTextBox.Location = new System.Drawing.Point(180, 171);
            this.deliveryDateTextBox.Multiline = true;
            this.deliveryDateTextBox.Name = "deliveryDateTextBox";
            this.deliveryDateTextBox.ReadOnly = true;
            this.deliveryDateTextBox.Size = new System.Drawing.Size(158, 30);
            this.deliveryDateTextBox.TabIndex = 10;
            // 
            // pickupLabel
            // 
            this.pickupLabel.AutoSize = true;
            this.pickupLabel.Location = new System.Drawing.Point(16, 155);
            this.pickupLabel.Name = "pickupLabel";
            this.pickupLabel.Size = new System.Drawing.Size(74, 13);
            this.pickupLabel.TabIndex = 9;
            this.pickupLabel.Text = "Pickup Ready";
            // 
            // pickupDateTextBox
            // 
            this.pickupDateTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.pickupDateTextBox.Location = new System.Drawing.Point(16, 171);
            this.pickupDateTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.pickupDateTextBox.Multiline = true;
            this.pickupDateTextBox.Name = "pickupDateTextBox";
            this.pickupDateTextBox.ReadOnly = true;
            this.pickupDateTextBox.Size = new System.Drawing.Size(158, 30);
            this.pickupDateTextBox.TabIndex = 8;
            // 
            // consigneeLabel
            // 
            this.consigneeLabel.AutoSize = true;
            this.consigneeLabel.Location = new System.Drawing.Point(180, 29);
            this.consigneeLabel.Name = "consigneeLabel";
            this.consigneeLabel.Size = new System.Drawing.Size(57, 13);
            this.consigneeLabel.TabIndex = 7;
            this.consigneeLabel.Text = "Consignee";
            // 
            // shipperLabel
            // 
            this.shipperLabel.AutoSize = true;
            this.shipperLabel.Location = new System.Drawing.Point(16, 29);
            this.shipperLabel.Name = "shipperLabel";
            this.shipperLabel.Size = new System.Drawing.Size(43, 13);
            this.shipperLabel.TabIndex = 6;
            this.shipperLabel.Text = "Shipper";
            // 
            // toAddressTextBox
            // 
            this.toAddressTextBox.Location = new System.Drawing.Point(183, 45);
            this.toAddressTextBox.Multiline = true;
            this.toAddressTextBox.Name = "toAddressTextBox";
            this.toAddressTextBox.ReadOnly = true;
            this.toAddressTextBox.Size = new System.Drawing.Size(158, 107);
            this.toAddressTextBox.TabIndex = 5;
            // 
            // fromAddressTextBox
            // 
            this.fromAddressTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.fromAddressTextBox.Location = new System.Drawing.Point(16, 45);
            this.fromAddressTextBox.Multiline = true;
            this.fromAddressTextBox.Name = "fromAddressTextBox";
            this.fromAddressTextBox.ReadOnly = true;
            this.fromAddressTextBox.Size = new System.Drawing.Size(158, 107);
            this.fromAddressTextBox.TabIndex = 4;
            // 
            // bookingResultGroupBox
            // 
            this.bookingResultGroupBox.Controls.Add(this.resultTextBox);
            this.bookingResultGroupBox.Location = new System.Drawing.Point(31, 474);
            this.bookingResultGroupBox.Name = "bookingResultGroupBox";
            this.bookingResultGroupBox.Size = new System.Drawing.Size(453, 110);
            this.bookingResultGroupBox.TabIndex = 5;
            this.bookingResultGroupBox.TabStop = false;
            this.bookingResultGroupBox.Text = "Booking Result";
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.Location = new System.Drawing.Point(16, 19);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(429, 80);
            this.resultTextBox.TabIndex = 2;
            // 
            // JetpakSoapClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 610);
            this.Controls.Add(this.bookingResultGroupBox);
            this.Controls.Add(this.makeBookingButton);
            this.Controls.Add(this.bookingDataGroupBox);
            this.Controls.Add(this.transportAlternativeGroupBox);
            this.Controls.Add(this.searchTrpAltBtn);
            this.Name = "JetpakSoapClientForm";
            this.Text = "JetpakSoapClientForm";
            this.bookingDataGroupBox.ResumeLayout(false);
            this.bookingDataGroupBox.PerformLayout();
            this.bookingResultGroupBox.ResumeLayout(false);
            this.bookingResultGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton flightBookingTypeRadioButton;
        private System.Windows.Forms.RadioButton courierBookingTypeRadioButton;
        private System.Windows.Forms.Button searchTrpAltBtn;
        private System.Windows.Forms.GroupBox transportAlternativeGroupBox;
        private System.Windows.Forms.Button makeBookingButton;
        private System.Windows.Forms.GroupBox bookingDataGroupBox;
        private System.Windows.Forms.TextBox toAddressTextBox;
        private System.Windows.Forms.TextBox fromAddressTextBox;
        private System.Windows.Forms.Label consigneeLabel;
        private System.Windows.Forms.Label shipperLabel;
        private System.Windows.Forms.Label pickupLabel;
        private System.Windows.Forms.TextBox pickupDateTextBox;
        private System.Windows.Forms.Label deliveryLabel;
        private System.Windows.Forms.TextBox deliveryDateTextBox;
        private System.Windows.Forms.Label bookingTypeLabel;
        private System.Windows.Forms.GroupBox bookingResultGroupBox;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

