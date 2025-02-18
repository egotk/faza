using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using test_faza_client.api.service.interfaces;
using test_faza_client.api.services.interfaces;
using test_faza_client.common.entity;
using test_faza_client.dependencyContainer;

namespace test_faza_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Interface> _interfaces = [];
        private Interface? _selectedInterface;
        private List<Device> _devices = [];
        private Device? _selectedDevice;
        private List<Register> _registers = [];
        private Register? _selectedRegister;
        private List<RegisterValue> _values = [];
        private List<Device> _activeDevices = [];

        private IInterfaceService _interfaceService;
        private IDeviceService _deviceService;
        private IRegisterService _registerService;
        private IGeneratorService _generatorService;
        private IRegisterValueService _registerValueService;

        private DateTime? _startDate;
        private DateTime? _endDate;

        private Color? _selectedColor;

        // флаги для редактирования
        private bool _isInterfaceModified = false;
        private bool _isDeviceModified = false;
        private bool _isRegisterModified = false;


        private async void Form1_Load(object sender, EventArgs e)
        {

            IDependencyContainer container = new DependencyContainer();
            IServiceProvider provider = container.Configure();
            _interfaceService = provider.GetRequiredService<IInterfaceService>();
            _deviceService = provider.GetRequiredService<IDeviceService>();
            _registerService = provider.GetRequiredService<IRegisterService>();
            _generatorService = provider.GetRequiredService<IGeneratorService>();
            _registerValueService = provider.GetRequiredService<IRegisterValueService>();

            // запрашиваем интерфейсы информацию с сервера
            _interfaces = await _interfaceService.GetAllIncluding();
            _activeDevices = _interfaces.SelectMany(i => i.Devices).Where(d => d.IsEnabled == true).ToList();
            FillListView<Interface>(interfaceListView, _interfaces);

            // перерисовываем панель
            devicesPanel.Invalidate();
        }

        // дженерик функция для заполнения списков
        private void FillListView<T>(ListView listView, List<T> items) where T : BaseEntity, INameableEntity
        {
            listView.Items.Clear();
            listView.Items.AddRange(
                items.Select(item => new ListViewItem([
                    item.Id.ToString()!,
                    item.Name,
                    ])
                { Tag = item }).ToArray());
        }

        private void FillRegisterValueListView()
        {
            registerValueListView.Items.Clear();

            if (_values.Count > 0)
            {
                registerValueListView.Items.AddRange(
                    _values.Select(valueEntity => new ListViewItem([
                        valueEntity.Value.ToString(),
                    ])
                    { Tag = valueEntity }).ToArray());

                registerNameLabel.Text = $"Регистр {_selectedRegister!.Name}";
                registerValueLabel.Text = $"Актуальное: {_values.OrderByDescending(value => value.Timestamp).First().Value}";
            }
        }

        // выбран новый элемент списка
        private void interfaceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (interfaceListView.SelectedItems.Count > 0 && interfaceListView.SelectedItems[0].Tag != null)
            {
                _selectedInterface = (Interface)interfaceListView.SelectedItems[0].Tag!;
                _devices = _selectedInterface.Devices;
                FillListView<Device>(deviceListView, _devices);
                interfaceGrid.SelectedObject = _selectedInterface;
                interfaceGrid.Visible = true;
                deleteInterfaceButton.Enabled = true;
                updateInterfaceButton.Enabled = true;
                _isInterfaceModified = false;
                MakeVisible(deviceListView, addDeviceButton, deleteDeviceButton, updateDeviceButton, deviceGrid);
            }
        }

        private void deviceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deviceListView.SelectedItems.Count > 0 && deviceListView.SelectedItems[0].Tag != null)
            {
                _selectedDevice = (Device)deviceListView.SelectedItems[0].Tag!;
                _registers = _selectedDevice.Registers;
                FillListView(registerListView, _registers);
                deleteDeviceButton.Enabled = true;
                updateDeviceButton.Enabled = true;
                _isDeviceModified = false;
                deviceGrid.SelectedObject = _selectedDevice;
                MakeVisible(registerListView, addRegisterButton, deleteRegisterButton, updateRegisterButton, registerGrid);
            }
        }

        private void registerListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (registerListView.SelectedItems.Count > 0 && registerListView.SelectedItems[0].Tag != null)
            {
                _selectedRegister = (Register)registerListView.SelectedItems[0].Tag!;
                registerGrid.SelectedObject = _selectedRegister;
                registerGrid.Visible = true;
                deleteRegisterButton.Enabled = true;
                updateRegisterButton.Enabled = true;
                _isRegisterModified = false;
                _values = _selectedRegister!.Values;
                FillRegisterValueListView();
                SetDatesToDefault();
                ShowRegisterValueHistoryPanel();
            }

        }

        // возврат дат к исходным
        private void SetDatesToDefault()
        {
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
            startDatePicker.Value = _startDate.Value;
            endDatePicker.Value = _endDate.Value;
        }

        // показать значения регистров
        private void ShowRegisterValueHistoryPanel()
        {
            registerValueListView.Visible = true;
            startDateLabel.Visible = true;
            startDatePicker.Visible = true;
            endDateLabel.Visible = true;
            endDatePicker.Visible = true;
            updateHistoryButton.Visible = true;
            registerNameLabel.Visible = true;
            registerValueLabel.Visible = true;
        }

        // показать список и кнопки
        private void MakeVisible(ListView listView, Button button1, Button button2, Button button3, PropertyGrid grid)
        {
            listView.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            grid.Visible = true;
        }

        private async void startGeneratorButton_Click(object sender, EventArgs e)
        {
            bool? success = await _generatorService.Start();
            if (success != null)
            {
                isGeneratorWorkingLabel.Text = $"Генератор {(success.Value ? "работает" : "не работает")}";
                startGeneratorButton.Enabled = false;
                stopGeneratorButton.Enabled = true;
            }
        }

        private async void stopGeneratorButton_Click(object sender, EventArgs e)
        {
            bool? success = await _generatorService.Stop();
            if (success != null)
            {
                isGeneratorWorkingLabel.Text = $"Генератор {(success.Value ? "работает" : "не работает")}";
                _interfaces = await _interfaceService.GetAllIncluding();
                RefreshScreen();
                startGeneratorButton.Enabled = true;
                stopGeneratorButton.Enabled = false;
            }
        }

        // дата изменилась
        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            _startDate = startDatePicker.Value;

            if (_endDate != null)
            {
                if (_startDate >= _endDate)
                    MessageBox.Show("Начальная дата должна быть меньше конечной");
            }
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            _endDate = endDatePicker.Value;
            if (_startDate != null)
                updateHistoryButton.Enabled = true;
            if (_startDate != null)
            {
                if (_endDate <= _startDate)
                    MessageBox.Show("Конечная дата должна быть меньше начальной");
            }
        }

        private async void updateHistoryButton_Click(object sender, EventArgs e)
        {
            if (_startDate != null && _endDate != null && _selectedRegister != null)
            {
                DateTime startDate = _startDate.Value;
                DateTime endDate = _endDate.Value;
                _values = await _registerValueService.GetValueHistory(_selectedRegister, startDate, endDate);
                Console.WriteLine(JsonConvert.SerializeObject(_values));
                FillRegisterValueListView();
            }
        }

        // дженерик функция для удаления сущностей
        private async Task DeleteEntity<T>(T entity, Func<T, Task<bool>> deleteFunc) where T : BaseEntity, INameableEntity
        {
            DialogResult confirm = MessageBox.Show($"Вы уверены, что хотите удалить {entity.Name}?", "Подтвердите действие", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool result = await deleteFunc(entity);

                if (result)
                {
                    MessageBox.Show("Удаление прошло успешно");
                    RefreshScreen();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при удалении");
                }
            }
        }

        private async void deleteInterfaceButton_Click(object sender, EventArgs e) => await DeleteEntity<Interface>(_selectedInterface!, _interfaceService.Delete);

        private async void deleteDeviceButton_Click(object sender, EventArgs e) => await DeleteEntity<Device>(_selectedDevice!, _deviceService.Delete);

        private async void deleteRegisterButton_Click(object sender, EventArgs e) => await DeleteEntity<Register>(_selectedRegister!, _registerService.Delete);

        // сделали запрос на обновление актуальных данных - обновили экран
        private async void RefreshScreen()
        {
            // обнуляем выбранное
            _selectedInterface = null;
            _selectedDevice = null;
            _selectedRegister = null;
            // рефетчим данные
            _interfaces = await _interfaceService.GetAllIncluding();
            //FillInterfaceListView();
            FillListView<Interface>(interfaceListView, _interfaces);
            _devices = _interfaces.SelectMany(i => i.Devices).ToList();
            _registers = _devices.SelectMany(d => d.Registers).ToList();
            _activeDevices = _interfaces.SelectMany(i => i.Devices).Where(d => d.IsEnabled == true).ToList();
            // очищаем таблицы
            deviceListView.Items.Clear();
            registerListView.Items.Clear();
            registerValueListView.Items.Clear();
            interfaceGrid.SelectedObject = null;
            deviceGrid.SelectedObject = null;
            registerGrid.SelectedObject = null;
            registerNameLabel.Text = "Регистр";
            registerValueLabel.Text = "Актуальное:";
            // блокируем кнопки удаления и редактирования
            deleteInterfaceButton.Enabled = false;
            deleteDeviceButton.Enabled = false;
            deleteRegisterButton.Enabled = false;
            updateInterfaceButton.Enabled = false;
            updateDeviceButton.Enabled = false;
            updateRegisterButton.Enabled = false;
            // перерисовываем панель
            devicesPanel.Invalidate();
        }

        // дженерик функция для обновления сущностей
        private async Task UpdateEntity<T>(T entity, bool isEntityModified, Func<T, Task<bool>> updateFunc) where T : BaseEntity, INameableEntity
        {
            if (isEntityModified)
            {
                bool result = await updateFunc(entity);

                if (result)
                {
                    MessageBox.Show("Обновление прошло успешно", "Успех");
                    RefreshScreen();
                }
                else
                    MessageBox.Show("Произошла ошибка при обновлении", "Ошибка");
            }
            else
                MessageBox.Show("Сначала измените выбранную сущность", "Предупреждение");
        }

        private async void updateInterfaceButton_Click(object sender, EventArgs e) => await UpdateEntity<Interface>(_selectedInterface!, _isInterfaceModified, _interfaceService.Update);

        private async void updateDeviceButton_Click(object sender, EventArgs e) => await UpdateEntity<Device>(_selectedDevice!, _isDeviceModified, _deviceService.Update);

        private async void updateRegisterButton_Click(object sender, EventArgs e) => await UpdateEntity<Register>(_selectedRegister!, _isRegisterModified, _registerService.Update);


        // отследить изменения в PropertyGrid, чтобы не отправлять запрос, если значения не менялись
        private void interfaceGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _isInterfaceModified = true;
        }

        private void deviceGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _isDeviceModified = true;
        }

        private void registerGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _isRegisterModified = true;
        }

        // показать панели с формами для добавления сущностей
        private void addInterfaceButton_Click(object sender, EventArgs e)
        {
            interfaceNameTextbox.Text = string.Empty;
            interfaceDescriptionTextbox.Text = string.Empty;
            addInterfacePanel.Visible = true;
        }

        private void addDeviceButton_Click(object sender, EventArgs e)
        {
            _selectedColor = null;

            addDevicePanel.Visible = true;
            List<int> interfaceIds = _interfaces.Select(i => i.Id ?? 0).Distinct().ToList();

            interfaceIdComboBox.DataSource = interfaceIds;
            deviceIsEnabledComboBox.DataSource = new List<bool> { false, true };
            deviceFigureTypeComboBox.DataSource = Enum.GetValues(typeof(FigureType));
        }

        private void addRegisterButton_Click(object sender, EventArgs e)
        {
            addRegisterPanel.Visible = true;
            List<int> deviceIds = _devices.Select(d => d.Id ?? 0).Distinct().ToList();

            deviceIdComboBox.DataSource = deviceIds;
        }

        // скрыть панели
        private void cancelAddInterfaceButton_Click(object sender, EventArgs e)
        {
            addInterfacePanel.Visible = false;
        }

        private void cancelAddDeviceButton_Click(object sender, EventArgs e)
        {
            addDevicePanel.Visible = false;
        }

        private void cancelAddRegisterButton_Click(object sender, EventArgs e)
        {
            addRegisterPanel.Visible = false;

        }

        // валидация и добавление сущностей
        private async void confirmAddInterfaceButton_Click(object sender, EventArgs e)
        {
            bool isNameCorrect = !string.IsNullOrWhiteSpace(interfaceNameTextbox.Text);
            bool isDescriptionCorrect = !string.IsNullOrWhiteSpace(interfaceDescriptionTextbox.Text);

            if (isNameCorrect && isDescriptionCorrect)
            {
                Interface newInterface = new()
                {
                    Name = interfaceNameTextbox.Text,
                    Description = interfaceDescriptionTextbox.Text,
                };

                bool result = await _interfaceService.Create(newInterface);

                if (result)
                {
                    MessageBox.Show("Интерфейс успешно добавлен", "Успех");
                    RefreshScreen();
                    addInterfacePanel.Visible = false;
                }
                else
                    MessageBox.Show("При добавлении интерфейса произошла ошибка", "Ошибка");

            }
            else
                MessageBox.Show("Заполните все поля", "Предупреждение");
        }

        private async void confirmAddDeviceButton_Click(object sender, EventArgs e)
        {
            bool isNameCorrect = !string.IsNullOrWhiteSpace(deviceNameTextBox.Text);
            bool isDescriptionCorrect = !string.IsNullOrWhiteSpace(deviceDescriptionTextBox.Text);
            bool isSizeCorrect = int.TryParse(deviceSizeTextBox.Text, out int size);
            bool isPosXCorrect = int.TryParse(devicePosXTextBox.Text, out int posX);
            bool isPosYCorrect = int.TryParse(devicePosYTextBox.Text, out int posY);
            bool isColorCorrect = _selectedColor != null;


            if (isNameCorrect && isDescriptionCorrect && isColorCorrect)
            {
                if (isSizeCorrect && isPosXCorrect && isPosYCorrect)
                {
                    Device newDevice = new()
                    {
                        InterfaceId = (int)interfaceIdComboBox.SelectedItem!,
                        Name = deviceNameTextBox.Text,
                        Description = deviceDescriptionTextBox.Text,
                        IsEnabled = (bool)deviceIsEnabledComboBox.SelectedItem!,
                        FigureType = (FigureType)deviceFigureTypeComboBox.SelectedItem!,
                        Size = int.Parse(deviceSizeTextBox.Text),
                        PosX = int.Parse(devicePosXTextBox.Text),
                        PosY = int.Parse(devicePosYTextBox.Text),
                        Color = _selectedColor!.Value.ToArgb(),
                    };

                    bool result = await _deviceService.Create(newDevice);

                    if (result)
                    {
                        MessageBox.Show("Девайс успешно добавлен", "Успех");
                        RefreshScreen();
                        addDevicePanel.Visible = false;
                    }
                    else
                        MessageBox.Show("Произошла ошибка при создании девайса", "Ошибка");
                }
                else
                    MessageBox.Show("Числовые поля заполнены неправильно (целочисленный формат)", "Предупреждение");
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Предупреждение");
            }

        }

        private async void confirmAddRegisterButton_Click(object sender, EventArgs e)
        {
            bool isNameCorrect = !string.IsNullOrWhiteSpace(registerNameTextBox.Text);
            bool isDescriptionCorrect = !string.IsNullOrWhiteSpace(registerDescriptionTextBox.Text);

            if (isNameCorrect && isDescriptionCorrect)
            {
                Register newRegister = new()
                {
                    DeviceId = (int)deviceIdComboBox.SelectedItem!,
                    Name = registerNameTextBox.Text,
                    Description = registerDescriptionTextBox.Text,
                };

                bool result = await _registerService.Create(newRegister);

                if (result)
                {
                    MessageBox.Show("Регистр успешно добавлен", "Успех");
                    RefreshScreen();
                    addRegisterPanel.Visible = false;
                }
                else
                    MessageBox.Show("При добавлении регистра произошла ошибка", "Ошибка");

            }
            else
                MessageBox.Show("Заполните все поля", "Предупреждение");
        }

        // окно с выбором цвета
        private void deviceColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedColor = colorDialog.Color;
            }
        }

        // рисуем панель с активными устройствами
        private void devicesPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_activeDevices.Count > 0)
            {
                foreach (Device device in _activeDevices)
                {
                    Color color = Color.FromArgb(device.Color);
                    string name = device.Name;
                    int size = device.Size;
                    int x = device.PosX;
                    int y = device.PosY;
                    Pen figurePen = new Pen(color);
                    Pen borderPen = new Pen(Color.Black);

                    // рамка
                    e.Graphics.DrawRectangle(borderPen, x, y, size + size / 2, size + size / 2);
                    // имя
                    e.Graphics.DrawString(name, new Font("Segoe UI", 9), Brushes.Black, x, y + (size + size / 2));

                    // фигура
                    switch (device.FigureType)
                    {
                        case FigureType.Circle:
                            e.Graphics.DrawEllipse(figurePen, x + size / 4, y + size / 4, size, size);
                            break;
                        case FigureType.Square:
                            e.Graphics.DrawRectangle(figurePen, x + size / 4, y + size / 4, size, size);
                            break;
                        case FigureType.Line:
                            e.Graphics.DrawLine(figurePen, x + size / 4, y + size / 4, (x + size / 4 + size), y + size / 4);
                            break;
                    }
                }
            }
        }
    }
}
