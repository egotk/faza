namespace test_faza_client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            interfaceListView = new ListView();
            interfaceId = new ColumnHeader();
            interfaceName = new ColumnHeader();
            deviceListView = new ListView();
            deviceId = new ColumnHeader();
            deviceName = new ColumnHeader();
            registerListView = new ListView();
            registerId = new ColumnHeader();
            registerName = new ColumnHeader();
            startGeneratorButton = new Button();
            stopGeneratorButton = new Button();
            addInterfaceButton = new Button();
            deleteInterfaceButton = new Button();
            updateInterfaceButton = new Button();
            addDeviceButton = new Button();
            deleteDeviceButton = new Button();
            updateDeviceButton = new Button();
            addRegisterButton = new Button();
            deleteRegisterButton = new Button();
            updateRegisterButton = new Button();
            interfaceGrid = new PropertyGrid();
            deviceGrid = new PropertyGrid();
            registerGrid = new PropertyGrid();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            updateHistoryButton = new Button();
            registerValueListView = new ListView();
            value = new ColumnHeader();
            startDateLabel = new Label();
            endDateLabel = new Label();
            addInterfacePanel = new Panel();
            cancelAddInterfaceButton = new Button();
            confirmAddInterfaceButton = new Button();
            label1 = new Label();
            interfaceDescriptionTextbox = new TextBox();
            interfaceNameTextbox = new TextBox();
            interfaceDescriptionLabel = new Label();
            interfaceNameLabel = new Label();
            addDevicePanel = new Panel();
            deviceColorButton = new Button();
            cancelAddDeviceButton = new Button();
            confirmAddDeviceButton = new Button();
            devicePosYTextBox = new TextBox();
            label10 = new Label();
            devicePosXTextBox = new TextBox();
            label9 = new Label();
            deviceSizeTextBox = new TextBox();
            label8 = new Label();
            deviceFigureTypeComboBox = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            deviceIsEnabledComboBox = new ComboBox();
            label5 = new Label();
            deviceDescriptionTextBox = new TextBox();
            deviceNameTextBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            interfaceIdComboBox = new ComboBox();
            label2 = new Label();
            addRegisterPanel = new Panel();
            registerNameTextBox = new TextBox();
            label15 = new Label();
            label14 = new Label();
            deviceIdComboBox = new ComboBox();
            cancelAddRegisterButton = new Button();
            confirmAddRegisterButton = new Button();
            label12 = new Label();
            registerDescriptionTextBox = new TextBox();
            label13 = new Label();
            isGeneratorWorkingLabel = new Label();
            registerValueLabel = new Label();
            registerNameLabel = new Label();
            devicesPanel = new Panel();
            addInterfacePanel.SuspendLayout();
            addDevicePanel.SuspendLayout();
            addRegisterPanel.SuspendLayout();
            devicesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // interfaceListView
            // 
            interfaceListView.Columns.AddRange(new ColumnHeader[] { interfaceId, interfaceName });
            interfaceListView.FullRowSelect = true;
            interfaceListView.Location = new Point(12, 12);
            interfaceListView.MultiSelect = false;
            interfaceListView.Name = "interfaceListView";
            interfaceListView.Size = new Size(244, 181);
            interfaceListView.TabIndex = 0;
            interfaceListView.UseCompatibleStateImageBehavior = false;
            interfaceListView.View = View.Details;
            interfaceListView.SelectedIndexChanged += interfaceListView_SelectedIndexChanged;
            // 
            // interfaceId
            // 
            interfaceId.Text = "ID";
            interfaceId.Width = 30;
            // 
            // interfaceName
            // 
            interfaceName.Text = "Интерфейс";
            interfaceName.TextAlign = HorizontalAlignment.Center;
            interfaceName.Width = 210;
            // 
            // deviceListView
            // 
            deviceListView.Columns.AddRange(new ColumnHeader[] { deviceId, deviceName });
            deviceListView.FullRowSelect = true;
            deviceListView.Location = new Point(12, 199);
            deviceListView.MultiSelect = false;
            deviceListView.Name = "deviceListView";
            deviceListView.Size = new Size(244, 181);
            deviceListView.TabIndex = 2;
            deviceListView.UseCompatibleStateImageBehavior = false;
            deviceListView.View = View.Details;
            deviceListView.Visible = false;
            deviceListView.SelectedIndexChanged += deviceListView_SelectedIndexChanged;
            // 
            // deviceId
            // 
            deviceId.Text = "ID";
            deviceId.Width = 30;
            // 
            // deviceName
            // 
            deviceName.Text = "Девайс";
            deviceName.TextAlign = HorizontalAlignment.Center;
            deviceName.Width = 210;
            // 
            // registerListView
            // 
            registerListView.Columns.AddRange(new ColumnHeader[] { registerId, registerName });
            registerListView.FullRowSelect = true;
            registerListView.Location = new Point(12, 386);
            registerListView.MultiSelect = false;
            registerListView.Name = "registerListView";
            registerListView.Size = new Size(244, 181);
            registerListView.TabIndex = 3;
            registerListView.UseCompatibleStateImageBehavior = false;
            registerListView.View = View.Details;
            registerListView.Visible = false;
            registerListView.SelectedIndexChanged += registerListView_SelectedIndexChanged;
            // 
            // registerId
            // 
            registerId.Text = "ID";
            registerId.Width = 30;
            // 
            // registerName
            // 
            registerName.Text = "Регистр";
            registerName.TextAlign = HorizontalAlignment.Center;
            registerName.Width = 210;
            // 
            // startGeneratorButton
            // 
            startGeneratorButton.Location = new Point(12, 618);
            startGeneratorButton.Name = "startGeneratorButton";
            startGeneratorButton.Size = new Size(244, 23);
            startGeneratorButton.TabIndex = 4;
            startGeneratorButton.Text = "Включить генератор";
            startGeneratorButton.UseVisualStyleBackColor = true;
            startGeneratorButton.Click += startGeneratorButton_Click;
            // 
            // stopGeneratorButton
            // 
            stopGeneratorButton.Enabled = false;
            stopGeneratorButton.Location = new Point(343, 618);
            stopGeneratorButton.Name = "stopGeneratorButton";
            stopGeneratorButton.Size = new Size(244, 23);
            stopGeneratorButton.TabIndex = 5;
            stopGeneratorButton.Text = "Выключить генератор";
            stopGeneratorButton.UseVisualStyleBackColor = true;
            stopGeneratorButton.Click += stopGeneratorButton_Click;
            // 
            // addInterfaceButton
            // 
            addInterfaceButton.Location = new Point(262, 12);
            addInterfaceButton.Name = "addInterfaceButton";
            addInterfaceButton.Size = new Size(75, 23);
            addInterfaceButton.TabIndex = 6;
            addInterfaceButton.Text = "Добавить";
            addInterfaceButton.UseVisualStyleBackColor = true;
            addInterfaceButton.Click += addInterfaceButton_Click;
            // 
            // deleteInterfaceButton
            // 
            deleteInterfaceButton.Enabled = false;
            deleteInterfaceButton.Location = new Point(262, 41);
            deleteInterfaceButton.Name = "deleteInterfaceButton";
            deleteInterfaceButton.Size = new Size(75, 23);
            deleteInterfaceButton.TabIndex = 7;
            deleteInterfaceButton.Text = "Удалить";
            deleteInterfaceButton.UseVisualStyleBackColor = true;
            deleteInterfaceButton.Click += deleteInterfaceButton_Click;
            // 
            // updateInterfaceButton
            // 
            updateInterfaceButton.Enabled = false;
            updateInterfaceButton.Location = new Point(262, 70);
            updateInterfaceButton.Name = "updateInterfaceButton";
            updateInterfaceButton.Size = new Size(75, 23);
            updateInterfaceButton.TabIndex = 8;
            updateInterfaceButton.Text = "Изменить";
            updateInterfaceButton.UseVisualStyleBackColor = true;
            updateInterfaceButton.Click += updateInterfaceButton_Click;
            // 
            // addDeviceButton
            // 
            addDeviceButton.Location = new Point(262, 199);
            addDeviceButton.Name = "addDeviceButton";
            addDeviceButton.Size = new Size(75, 23);
            addDeviceButton.TabIndex = 9;
            addDeviceButton.Text = "Добавить";
            addDeviceButton.UseVisualStyleBackColor = true;
            addDeviceButton.Visible = false;
            addDeviceButton.Click += addDeviceButton_Click;
            // 
            // deleteDeviceButton
            // 
            deleteDeviceButton.Enabled = false;
            deleteDeviceButton.Location = new Point(262, 228);
            deleteDeviceButton.Name = "deleteDeviceButton";
            deleteDeviceButton.Size = new Size(75, 23);
            deleteDeviceButton.TabIndex = 10;
            deleteDeviceButton.Text = "Удалить";
            deleteDeviceButton.UseVisualStyleBackColor = true;
            deleteDeviceButton.Visible = false;
            deleteDeviceButton.Click += deleteDeviceButton_Click;
            // 
            // updateDeviceButton
            // 
            updateDeviceButton.Enabled = false;
            updateDeviceButton.Location = new Point(262, 257);
            updateDeviceButton.Name = "updateDeviceButton";
            updateDeviceButton.Size = new Size(75, 23);
            updateDeviceButton.TabIndex = 11;
            updateDeviceButton.Text = "Изменить";
            updateDeviceButton.UseVisualStyleBackColor = true;
            updateDeviceButton.Visible = false;
            updateDeviceButton.Click += updateDeviceButton_Click;
            // 
            // addRegisterButton
            // 
            addRegisterButton.Location = new Point(262, 386);
            addRegisterButton.Name = "addRegisterButton";
            addRegisterButton.Size = new Size(75, 23);
            addRegisterButton.TabIndex = 12;
            addRegisterButton.Text = "Добавить";
            addRegisterButton.UseVisualStyleBackColor = true;
            addRegisterButton.Visible = false;
            addRegisterButton.Click += addRegisterButton_Click;
            // 
            // deleteRegisterButton
            // 
            deleteRegisterButton.Enabled = false;
            deleteRegisterButton.Location = new Point(262, 415);
            deleteRegisterButton.Name = "deleteRegisterButton";
            deleteRegisterButton.Size = new Size(75, 23);
            deleteRegisterButton.TabIndex = 13;
            deleteRegisterButton.Text = "Удалить";
            deleteRegisterButton.UseVisualStyleBackColor = true;
            deleteRegisterButton.Visible = false;
            deleteRegisterButton.Click += deleteRegisterButton_Click;
            // 
            // updateRegisterButton
            // 
            updateRegisterButton.Enabled = false;
            updateRegisterButton.Location = new Point(262, 444);
            updateRegisterButton.Name = "updateRegisterButton";
            updateRegisterButton.Size = new Size(75, 23);
            updateRegisterButton.TabIndex = 14;
            updateRegisterButton.Text = "Изменить";
            updateRegisterButton.UseVisualStyleBackColor = true;
            updateRegisterButton.Visible = false;
            updateRegisterButton.Click += updateRegisterButton_Click;
            // 
            // interfaceGrid
            // 
            interfaceGrid.HelpVisible = false;
            interfaceGrid.Location = new Point(343, 12);
            interfaceGrid.Name = "interfaceGrid";
            interfaceGrid.PropertySort = PropertySort.NoSort;
            interfaceGrid.Size = new Size(244, 181);
            interfaceGrid.TabIndex = 15;
            interfaceGrid.ToolbarVisible = false;
            interfaceGrid.Visible = false;
            interfaceGrid.PropertyValueChanged += interfaceGrid_PropertyValueChanged;
            // 
            // deviceGrid
            // 
            deviceGrid.HelpVisible = false;
            deviceGrid.Location = new Point(343, 199);
            deviceGrid.Name = "deviceGrid";
            deviceGrid.PropertySort = PropertySort.NoSort;
            deviceGrid.Size = new Size(244, 181);
            deviceGrid.TabIndex = 16;
            deviceGrid.ToolbarVisible = false;
            deviceGrid.Visible = false;
            deviceGrid.PropertyValueChanged += deviceGrid_PropertyValueChanged;
            // 
            // registerGrid
            // 
            registerGrid.HelpVisible = false;
            registerGrid.Location = new Point(343, 386);
            registerGrid.Name = "registerGrid";
            registerGrid.PropertySort = PropertySort.NoSort;
            registerGrid.Size = new Size(244, 181);
            registerGrid.TabIndex = 17;
            registerGrid.ToolbarVisible = false;
            registerGrid.Visible = false;
            registerGrid.PropertyValueChanged += registerGrid_PropertyValueChanged;
            // 
            // startDatePicker
            // 
            startDatePicker.Location = new Point(900, 622);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(141, 23);
            startDatePicker.TabIndex = 18;
            startDatePicker.Visible = false;
            startDatePicker.ValueChanged += startDatePicker_ValueChanged;
            // 
            // endDatePicker
            // 
            endDatePicker.Location = new Point(1078, 622);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(141, 23);
            endDatePicker.TabIndex = 19;
            endDatePicker.Visible = false;
            endDatePicker.ValueChanged += endDatePicker_ValueChanged;
            // 
            // updateHistoryButton
            // 
            updateHistoryButton.Location = new Point(1225, 622);
            updateHistoryButton.Name = "updateHistoryButton";
            updateHistoryButton.Size = new Size(75, 23);
            updateHistoryButton.TabIndex = 20;
            updateHistoryButton.Text = "Обновить";
            updateHistoryButton.UseVisualStyleBackColor = true;
            updateHistoryButton.Visible = false;
            updateHistoryButton.Click += updateHistoryButton_Click;
            // 
            // registerValueListView
            // 
            registerValueListView.Columns.AddRange(new ColumnHeader[] { value });
            registerValueListView.FullRowSelect = true;
            registerValueListView.Location = new Point(870, 431);
            registerValueListView.MultiSelect = false;
            registerValueListView.Name = "registerValueListView";
            registerValueListView.Size = new Size(430, 181);
            registerValueListView.TabIndex = 21;
            registerValueListView.UseCompatibleStateImageBehavior = false;
            registerValueListView.View = View.Details;
            registerValueListView.Visible = false;
            // 
            // value
            // 
            value.Text = "Значение регистра";
            value.TextAlign = HorizontalAlignment.Center;
            value.Width = 425;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(870, 630);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(24, 15);
            startDateLabel.TabIndex = 22;
            startDateLabel.Text = "От:";
            startDateLabel.Visible = false;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Location = new Point(1047, 628);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(25, 15);
            endDateLabel.TabIndex = 23;
            endDateLabel.Text = "До:";
            endDateLabel.Visible = false;
            // 
            // addInterfacePanel
            // 
            addInterfacePanel.BorderStyle = BorderStyle.FixedSingle;
            addInterfacePanel.Controls.Add(cancelAddInterfaceButton);
            addInterfacePanel.Controls.Add(confirmAddInterfaceButton);
            addInterfacePanel.Controls.Add(label1);
            addInterfacePanel.Controls.Add(interfaceDescriptionTextbox);
            addInterfacePanel.Controls.Add(interfaceNameTextbox);
            addInterfacePanel.Controls.Add(interfaceDescriptionLabel);
            addInterfacePanel.Controls.Add(interfaceNameLabel);
            addInterfacePanel.Location = new Point(3, 122);
            addInterfacePanel.Name = "addInterfacePanel";
            addInterfacePanel.Size = new Size(285, 181);
            addInterfacePanel.TabIndex = 24;
            addInterfacePanel.Visible = false;
            // 
            // cancelAddInterfaceButton
            // 
            cancelAddInterfaceButton.Location = new Point(186, 151);
            cancelAddInterfaceButton.Name = "cancelAddInterfaceButton";
            cancelAddInterfaceButton.Size = new Size(94, 23);
            cancelAddInterfaceButton.TabIndex = 6;
            cancelAddInterfaceButton.Text = "Отмена";
            cancelAddInterfaceButton.UseVisualStyleBackColor = true;
            cancelAddInterfaceButton.Click += cancelAddInterfaceButton_Click;
            // 
            // confirmAddInterfaceButton
            // 
            confirmAddInterfaceButton.Location = new Point(3, 151);
            confirmAddInterfaceButton.Name = "confirmAddInterfaceButton";
            confirmAddInterfaceButton.Size = new Size(94, 23);
            confirmAddInterfaceButton.TabIndex = 5;
            confirmAddInterfaceButton.Text = "Подтвердить";
            confirmAddInterfaceButton.UseVisualStyleBackColor = true;
            confirmAddInterfaceButton.Click += confirmAddInterfaceButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 8);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 4;
            label1.Text = "Создайте интерфейс";
            // 
            // interfaceDescriptionTextbox
            // 
            interfaceDescriptionTextbox.Location = new Point(84, 81);
            interfaceDescriptionTextbox.Name = "interfaceDescriptionTextbox";
            interfaceDescriptionTextbox.Size = new Size(179, 23);
            interfaceDescriptionTextbox.TabIndex = 3;
            // 
            // interfaceNameTextbox
            // 
            interfaceNameTextbox.Location = new Point(84, 52);
            interfaceNameTextbox.Name = "interfaceNameTextbox";
            interfaceNameTextbox.Size = new Size(179, 23);
            interfaceNameTextbox.TabIndex = 2;
            // 
            // interfaceDescriptionLabel
            // 
            interfaceDescriptionLabel.AutoSize = true;
            interfaceDescriptionLabel.Location = new Point(13, 89);
            interfaceDescriptionLabel.Name = "interfaceDescriptionLabel";
            interfaceDescriptionLabel.Size = new Size(65, 15);
            interfaceDescriptionLabel.TabIndex = 1;
            interfaceDescriptionLabel.Text = "Описание:";
            // 
            // interfaceNameLabel
            // 
            interfaceNameLabel.AutoSize = true;
            interfaceNameLabel.Location = new Point(13, 60);
            interfaceNameLabel.Name = "interfaceNameLabel";
            interfaceNameLabel.Size = new Size(34, 15);
            interfaceNameLabel.TabIndex = 0;
            interfaceNameLabel.Text = "Имя:";
            // 
            // addDevicePanel
            // 
            addDevicePanel.BorderStyle = BorderStyle.FixedSingle;
            addDevicePanel.Controls.Add(deviceColorButton);
            addDevicePanel.Controls.Add(cancelAddDeviceButton);
            addDevicePanel.Controls.Add(confirmAddDeviceButton);
            addDevicePanel.Controls.Add(devicePosYTextBox);
            addDevicePanel.Controls.Add(label10);
            addDevicePanel.Controls.Add(devicePosXTextBox);
            addDevicePanel.Controls.Add(label9);
            addDevicePanel.Controls.Add(deviceSizeTextBox);
            addDevicePanel.Controls.Add(label8);
            addDevicePanel.Controls.Add(deviceFigureTypeComboBox);
            addDevicePanel.Controls.Add(label7);
            addDevicePanel.Controls.Add(label6);
            addDevicePanel.Controls.Add(deviceIsEnabledComboBox);
            addDevicePanel.Controls.Add(label5);
            addDevicePanel.Controls.Add(deviceDescriptionTextBox);
            addDevicePanel.Controls.Add(deviceNameTextBox);
            addDevicePanel.Controls.Add(label4);
            addDevicePanel.Controls.Add(label3);
            addDevicePanel.Controls.Add(interfaceIdComboBox);
            addDevicePanel.Controls.Add(label2);
            addDevicePanel.Location = new Point(565, 137);
            addDevicePanel.Name = "addDevicePanel";
            addDevicePanel.Size = new Size(299, 368);
            addDevicePanel.TabIndex = 25;
            addDevicePanel.Visible = false;
            // 
            // deviceColorButton
            // 
            deviceColorButton.Location = new Point(15, 287);
            deviceColorButton.Name = "deviceColorButton";
            deviceColorButton.Size = new Size(75, 23);
            deviceColorButton.TabIndex = 26;
            deviceColorButton.Text = "Цвет";
            deviceColorButton.UseVisualStyleBackColor = true;
            deviceColorButton.Click += deviceColorButton_Click;
            // 
            // cancelAddDeviceButton
            // 
            cancelAddDeviceButton.Location = new Point(195, 331);
            cancelAddDeviceButton.Name = "cancelAddDeviceButton";
            cancelAddDeviceButton.Size = new Size(94, 23);
            cancelAddDeviceButton.TabIndex = 25;
            cancelAddDeviceButton.Text = "Отмена";
            cancelAddDeviceButton.UseVisualStyleBackColor = true;
            cancelAddDeviceButton.Click += cancelAddDeviceButton_Click;
            // 
            // confirmAddDeviceButton
            // 
            confirmAddDeviceButton.Location = new Point(10, 331);
            confirmAddDeviceButton.Name = "confirmAddDeviceButton";
            confirmAddDeviceButton.Size = new Size(94, 23);
            confirmAddDeviceButton.TabIndex = 24;
            confirmAddDeviceButton.Text = "Подтвердить";
            confirmAddDeviceButton.UseVisualStyleBackColor = true;
            confirmAddDeviceButton.Click += confirmAddDeviceButton_Click;
            // 
            // devicePosYTextBox
            // 
            devicePosYTextBox.Location = new Point(110, 261);
            devicePosYTextBox.Name = "devicePosYTextBox";
            devicePosYTextBox.Size = new Size(179, 23);
            devicePosYTextBox.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 269);
            label10.Name = "label10";
            label10.Size = new Size(68, 15);
            label10.TabIndex = 20;
            label10.Text = "Позиция Y:";
            // 
            // devicePosXTextBox
            // 
            devicePosXTextBox.Location = new Point(110, 232);
            devicePosXTextBox.Name = "devicePosXTextBox";
            devicePosXTextBox.Size = new Size(179, 23);
            devicePosXTextBox.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 240);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 18;
            label9.Text = "Позиция X:";
            // 
            // deviceSizeTextBox
            // 
            deviceSizeTextBox.Location = new Point(110, 203);
            deviceSizeTextBox.Name = "deviceSizeTextBox";
            deviceSizeTextBox.Size = new Size(179, 23);
            deviceSizeTextBox.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 206);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 16;
            label8.Text = "Размер:";
            // 
            // deviceFigureTypeComboBox
            // 
            deviceFigureTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceFigureTypeComboBox.FormattingEnabled = true;
            deviceFigureTypeComboBox.Location = new Point(110, 174);
            deviceFigureTypeComboBox.Name = "deviceFigureTypeComboBox";
            deviceFigureTypeComboBox.Size = new Size(179, 23);
            deviceFigureTypeComboBox.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 182);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 14;
            label7.Text = "Тип фигуры:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 153);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 13;
            label6.Text = "Включен:";
            // 
            // deviceIsEnabledComboBox
            // 
            deviceIsEnabledComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceIsEnabledComboBox.FormattingEnabled = true;
            deviceIsEnabledComboBox.Location = new Point(110, 145);
            deviceIsEnabledComboBox.Name = "deviceIsEnabledComboBox";
            deviceIsEnabledComboBox.Size = new Size(179, 23);
            deviceIsEnabledComboBox.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 124);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 11;
            label5.Text = "Описание:";
            // 
            // deviceDescriptionTextBox
            // 
            deviceDescriptionTextBox.Location = new Point(110, 116);
            deviceDescriptionTextBox.Name = "deviceDescriptionTextBox";
            deviceDescriptionTextBox.Size = new Size(179, 23);
            deviceDescriptionTextBox.TabIndex = 10;
            // 
            // deviceNameTextBox
            // 
            deviceNameTextBox.Location = new Point(110, 87);
            deviceNameTextBox.Name = "deviceNameTextBox";
            deviceNameTextBox.Size = new Size(179, 23);
            deviceNameTextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 90);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 8;
            label4.Text = "Имя:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 61);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 7;
            label3.Text = "ID интерфейса:";
            // 
            // interfaceIdComboBox
            // 
            interfaceIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            interfaceIdComboBox.FormattingEnabled = true;
            interfaceIdComboBox.Location = new Point(110, 53);
            interfaceIdComboBox.Name = "interfaceIdComboBox";
            interfaceIdComboBox.Size = new Size(179, 23);
            interfaceIdComboBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 8);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 5;
            label2.Text = "Создайте девайс";
            // 
            // addRegisterPanel
            // 
            addRegisterPanel.BorderStyle = BorderStyle.FixedSingle;
            addRegisterPanel.Controls.Add(registerNameTextBox);
            addRegisterPanel.Controls.Add(label15);
            addRegisterPanel.Controls.Add(label14);
            addRegisterPanel.Controls.Add(deviceIdComboBox);
            addRegisterPanel.Controls.Add(cancelAddRegisterButton);
            addRegisterPanel.Controls.Add(confirmAddRegisterButton);
            addRegisterPanel.Controls.Add(label12);
            addRegisterPanel.Controls.Add(registerDescriptionTextBox);
            addRegisterPanel.Controls.Add(label13);
            addRegisterPanel.Location = new Point(271, 137);
            addRegisterPanel.Name = "addRegisterPanel";
            addRegisterPanel.Size = new Size(288, 181);
            addRegisterPanel.TabIndex = 26;
            addRegisterPanel.Visible = false;
            // 
            // registerNameTextBox
            // 
            registerNameTextBox.Location = new Point(101, 70);
            registerNameTextBox.Name = "registerNameTextBox";
            registerNameTextBox.Size = new Size(179, 23);
            registerNameTextBox.TabIndex = 11;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(3, 78);
            label15.Name = "label15";
            label15.Size = new Size(34, 15);
            label15.TabIndex = 10;
            label15.Text = "Имя:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(3, 49);
            label14.Name = "label14";
            label14.Size = new Size(67, 15);
            label14.TabIndex = 9;
            label14.Text = "ID девайса:";
            // 
            // deviceIdComboBox
            // 
            deviceIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceIdComboBox.FormattingEnabled = true;
            deviceIdComboBox.Location = new Point(101, 41);
            deviceIdComboBox.Name = "deviceIdComboBox";
            deviceIdComboBox.Size = new Size(179, 23);
            deviceIdComboBox.TabIndex = 8;
            // 
            // cancelAddRegisterButton
            // 
            cancelAddRegisterButton.Location = new Point(186, 151);
            cancelAddRegisterButton.Name = "cancelAddRegisterButton";
            cancelAddRegisterButton.Size = new Size(94, 23);
            cancelAddRegisterButton.TabIndex = 6;
            cancelAddRegisterButton.Text = "Отмена";
            cancelAddRegisterButton.UseVisualStyleBackColor = true;
            cancelAddRegisterButton.Click += cancelAddRegisterButton_Click;
            // 
            // confirmAddRegisterButton
            // 
            confirmAddRegisterButton.Location = new Point(3, 151);
            confirmAddRegisterButton.Name = "confirmAddRegisterButton";
            confirmAddRegisterButton.Size = new Size(94, 23);
            confirmAddRegisterButton.TabIndex = 5;
            confirmAddRegisterButton.Text = "Подтвердить";
            confirmAddRegisterButton.UseVisualStyleBackColor = true;
            confirmAddRegisterButton.Click += confirmAddRegisterButton_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(13, 8);
            label12.Name = "label12";
            label12.Size = new Size(103, 15);
            label12.TabIndex = 4;
            label12.Text = "Создайте регистр";
            // 
            // registerDescriptionTextBox
            // 
            registerDescriptionTextBox.Location = new Point(101, 99);
            registerDescriptionTextBox.Name = "registerDescriptionTextBox";
            registerDescriptionTextBox.Size = new Size(179, 23);
            registerDescriptionTextBox.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(3, 107);
            label13.Name = "label13";
            label13.Size = new Size(65, 15);
            label13.TabIndex = 1;
            label13.Text = "Описание:";
            // 
            // isGeneratorWorkingLabel
            // 
            isGeneratorWorkingLabel.AutoSize = true;
            isGeneratorWorkingLabel.Font = new Font("Segoe UI", 12F);
            isGeneratorWorkingLabel.Location = new Point(213, 581);
            isGeneratorWorkingLabel.Name = "isGeneratorWorkingLabel";
            isGeneratorWorkingLabel.Size = new Size(175, 21);
            isGeneratorWorkingLabel.TabIndex = 27;
            isGeneratorWorkingLabel.Text = "Генератор не работает";
            // 
            // registerValueLabel
            // 
            registerValueLabel.AutoSize = true;
            registerValueLabel.Location = new Point(1145, 413);
            registerValueLabel.Name = "registerValueLabel";
            registerValueLabel.Size = new Size(74, 15);
            registerValueLabel.TabIndex = 28;
            registerValueLabel.Text = "Актуальное:";
            registerValueLabel.Visible = false;
            // 
            // registerNameLabel
            // 
            registerNameLabel.AutoSize = true;
            registerNameLabel.Location = new Point(870, 415);
            registerNameLabel.Name = "registerNameLabel";
            registerNameLabel.Size = new Size(50, 15);
            registerNameLabel.TabIndex = 29;
            registerNameLabel.Text = "Регистр";
            registerNameLabel.Visible = false;
            // 
            // devicesPanel
            // 
            devicesPanel.BorderStyle = BorderStyle.FixedSingle;
            devicesPanel.Controls.Add(addInterfacePanel);
            devicesPanel.Location = new Point(866, 14);
            devicesPanel.Name = "devicesPanel";
            devicesPanel.Size = new Size(431, 308);
            devicesPanel.TabIndex = 30;
            devicesPanel.Paint += devicesPanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 653);
            Controls.Add(addRegisterPanel);
            Controls.Add(devicesPanel);
            Controls.Add(registerNameLabel);
            Controls.Add(registerValueLabel);
            Controls.Add(isGeneratorWorkingLabel);
            Controls.Add(addDevicePanel);
            Controls.Add(endDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(registerValueListView);
            Controls.Add(updateHistoryButton);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Controls.Add(registerGrid);
            Controls.Add(deviceGrid);
            Controls.Add(interfaceGrid);
            Controls.Add(updateRegisterButton);
            Controls.Add(deleteRegisterButton);
            Controls.Add(addRegisterButton);
            Controls.Add(updateDeviceButton);
            Controls.Add(deleteDeviceButton);
            Controls.Add(addDeviceButton);
            Controls.Add(updateInterfaceButton);
            Controls.Add(deleteInterfaceButton);
            Controls.Add(addInterfaceButton);
            Controls.Add(stopGeneratorButton);
            Controls.Add(startGeneratorButton);
            Controls.Add(registerListView);
            Controls.Add(deviceListView);
            Controls.Add(interfaceListView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            addInterfacePanel.ResumeLayout(false);
            addInterfacePanel.PerformLayout();
            addDevicePanel.ResumeLayout(false);
            addDevicePanel.PerformLayout();
            addRegisterPanel.ResumeLayout(false);
            addRegisterPanel.PerformLayout();
            devicesPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView interfaceListView;
        private ColumnHeader interfaceId;
        private ColumnHeader interfaceName;
        private ListView deviceListView;
        private ColumnHeader deviceId;
        private ColumnHeader deviceName;
        private ListView registerListView;
        private ColumnHeader registerId;
        private ColumnHeader registerName;
        private Button startGeneratorButton;
        private Button stopGeneratorButton;
        private Button addInterfaceButton;
        private Button deleteInterfaceButton;
        private Button updateInterfaceButton;
        private Button addDeviceButton;
        private Button deleteDeviceButton;
        private Button updateDeviceButton;
        private Button addRegisterButton;
        private Button deleteRegisterButton;
        private Button updateRegisterButton;
        private PropertyGrid interfaceGrid;
        private PropertyGrid deviceGrid;
        private PropertyGrid registerGrid;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Button updateHistoryButton;
        private ListView registerValueListView;
        private ColumnHeader value;
        private Label startDateLabel;
        private Label endDateLabel;
        private Panel addInterfacePanel;
        private TextBox interfaceDescriptionTextbox;
        private TextBox interfaceNameTextbox;
        private Label interfaceDescriptionLabel;
        private Label interfaceNameLabel;
        private Button cancelAddInterfaceButton;
        private Button confirmAddInterfaceButton;
        private Label label1;
        private Panel addDevicePanel;
        private Label label2;
        private ComboBox interfaceIdComboBox;
        private Label label3;
        private TextBox deviceNameTextBox;
        private Label label4;
        private TextBox devicePosYTextBox;
        private Label label10;
        private TextBox devicePosXTextBox;
        private Label label9;
        private TextBox deviceSizeTextBox;
        private Label label8;
        private ComboBox deviceFigureTypeComboBox;
        private Label label7;
        private Label label6;
        private ComboBox deviceIsEnabledComboBox;
        private Label label5;
        private TextBox deviceDescriptionTextBox;
        private Button cancelAddDeviceButton;
        private Button confirmAddDeviceButton;
        private Panel addRegisterPanel;
        private Button cancelAddRegisterButton;
        private Button confirmAddRegisterButton;
        private Label label12;
        private TextBox registerDescriptionTextBox;
        private Label label13;
        private Label label14;
        private ComboBox deviceIdComboBox;
        private TextBox registerNameTextBox;
        private Label label15;
        private Label isGeneratorWorkingLabel;
        private Label registerValueLabel;
        private Label registerNameLabel;
        private Button deviceColorButton;
        private Panel devicesPanel;
    }
}
