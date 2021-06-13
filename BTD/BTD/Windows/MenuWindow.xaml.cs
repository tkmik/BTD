using BTDCore.Models;
using BTDCore.ViewModels;
using BTDService.Services.db.Cards;
using BTDService.Services.db.EventsLogs;
using BTDService.Services.db.Notices;
using BTDService.Services.db.Tables;
using BTDService.Services.db.Users;
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace BTD.Windows
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ICardService _cardService;
        private readonly INoticeService _noticeService;
        private readonly IEventsLogService _eventLogService;
        private readonly ITableService _tableService;

        private bool DataGridAllSize = false;
        private bool DataGridExpand = false;
        public MenuWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            _cardService = new CardService();
            _noticeService = new NoticeService();
            _eventLogService = new EventsLogService();
            _tableService = new TableService();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.CloseApp();
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                ExpandIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowCollapseAll;
                WindowState = WindowState.Maximized;
            }
            else
            {
                ExpandIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ArrowExpandAll;
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = await _cardService.GetAllDocumentationAsync();
        }
        //show some tables
        private async void Documentation_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ToolTip = null;
            if ((bool)AllDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _cardService.GetAllDocumentationAsync();
            }
            if ((bool)TechDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _cardService.GetTechDocumentationAsync();
            }
            if ((bool)DesDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _cardService.GetDesDocumentationAsync();
            }
            if ((bool)NotificationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _noticeService.GetNoticesAsync();
                DataGrid.ToolTip = "Кликните дважды по записи, чтобы просмотреть файл!";
            }
            if ((bool)UsersRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _userService.GetAllUsersDetailsAsync();
            }
            if ((bool)EventLogRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _eventLogService.GetViewEventLogAsync();
            }
        }
        //look for information from table
        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)AllDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _cardService.GetAllDocumentationAsync(SearchTextBox.Text);
            }
            if ((bool)TechDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _cardService.GetTechDocumentationAsync(SearchTextBox.Text);
            }
            if ((bool)DesDocumentationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _cardService.GetDesDocumentationAsync(SearchTextBox.Text);
            }
            if ((bool)NotificationRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _noticeService.GetNoticesAsync(SearchTextBox.Text);
            }
            if ((bool)UsersRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _userService.GetAllUsersDetailsAsync(SearchTextBox.Text);
            }
            if ((bool)EventLogRadioButton.IsChecked)
            {
                DataGrid.ItemsSource = await _eventLogService.GetViewEventLogAsync(SearchTextBox.Text);
            }
        }
        //show/hide left bar
        private void TreeOnButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DataGridAllSize)
            {
                TreeOnButton.Style = (Style)TreeOnButton.FindResource("ModernExpandButtonPressed");
                DataGrid.Margin = new Thickness(10);
                DataGridAllSize = true;
            }
            else
            {
                DataGrid.Margin = new Thickness(160, 10, 10, 10);
                TreeOnButton.Style = (Style)TreeOnButton.FindResource("ModernExpandButton");
                DataGridAllSize = false;
            }
        }
        //add some information about documentation and etc
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)AllDocumentationRadioButton.IsChecked
                || (bool)TechDocumentationRadioButton.IsChecked
                || (bool)DesDocumentationRadioButton.IsChecked)
            {
                if (LoginWindow.CurrentUser.UserCapabilities.CanAddInfo)
                {
                    AddUpdateDocumentationWindow window = new AddUpdateDocumentationWindow();
                    window.Show();
                    window.Topmost = true;
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Вы не можете добавлять документацию, обратитесь к администратору!");
                }
            }
            if ((bool)NotificationRadioButton.IsChecked)
            {
                AddUpdateNoticeWindow window = new AddUpdateNoticeWindow();
                window.Show();
                window.Topmost = true;
            }
            if ((bool)UsersRadioButton.IsChecked)
            {
                if (LoginWindow.CurrentUser.UserCapabilities.CanMakeNewUser)
                {
                    AddUpdateUserWindow window = new AddUpdateUserWindow();
                    window.Show();
                    window.Topmost = true;
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Вы не можете добавлять пользователей!");
                }
            }
            if ((bool)EventLogRadioButton.IsChecked)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Вы не можете добавлять событие!");
            }

        }
        //editing some data which was selected
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is not null)
            {
                if ((bool)AllDocumentationRadioButton.IsChecked
                    || (bool)TechDocumentationRadioButton.IsChecked
                    || (bool)DesDocumentationRadioButton.IsChecked)
                {
                    if (LoginWindow.CurrentUser.UserCapabilities.CanEditInfo)
                    {
                        AddUpdateDocumentationWindow window = new AddUpdateDocumentationWindow((Documentation)DataGrid.SelectedItem);
                        window.Owner = this;
                        window.Show();
                        window.Topmost = true;
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Вы не можете редактировать документацию, обратитесь к администратору!");
                        return;
                    }
                }
                if ((bool)NotificationRadioButton.IsChecked)
                {
                    AddUpdateNoticeWindow window = new AddUpdateNoticeWindow((ViewNotice)DataGrid.SelectedItem);
                    window.Owner = this;
                    window.Show();
                    window.Topmost = true;
                }
                if ((bool)UsersRadioButton.IsChecked)
                {

                    if (LoginWindow.CurrentUser.UserCapabilities.CanEditUser)
                    {
                        AddUpdateUserWindow window = new AddUpdateUserWindow((ViewUserDetails)DataGrid.SelectedItem);
                        window.Owner = this;
                        window.Show();
                        window.Topmost = true;
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Вы не можете редактировать пользователей!");
                        return;
                    }
                }
                
            } 
            else if ((bool)EventLogRadioButton.IsChecked)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Вы не можете добавлять событие!");
                return;
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Запись не выбрана!");
            }
        }
        //delete the data
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is not null)
            {
                if ((bool)AllDocumentationRadioButton.IsChecked
                    || (bool)TechDocumentationRadioButton.IsChecked
                    || (bool)DesDocumentationRadioButton.IsChecked)
                {
                    if (LoginWindow.CurrentUser.UserCapabilities.CanDeleteInfo)
                    {
                        _cardService.Delete((await _cardService.GetCardByDesignationAsync(((Documentation)DataGrid.SelectedItem).Designation)).Id);
                        await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                        {
                            UserId = LoginWindow.CurrentUser.Id,
                            TableId = await _tableService.GetTableByIdAsync((int)TableName.Cards),
                            SystemEventId = (int)BTDSystemEvents.Deleting,
                            DateOfEvent = DateTime.Now
                        });
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Вы не можете удалять документацию, обратитесь к администратору!");
                        return;
                    }
                }
                else if ((bool)UsersRadioButton.IsChecked)
                {
                    if (LoginWindow.CurrentUser.UserCapabilities.CanDeleteUser)
                    {
                        _userService.Delete((await _userService.GetUserByLoginAsync(((ViewUserDetails)DataGrid.SelectedItem).Login)).Id);
                        await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                        {
                            UserId = LoginWindow.CurrentUser.Id,
                            TableId = await _tableService.GetTableByIdAsync((int)TableName.Users),
                            SystemEventId = (int)BTDSystemEvents.Deleting,
                            DateOfEvent = DateTime.Now
                        });
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Вы не можете редактировать пользователей!");
                        return;
                    }                   
                }
                else if ((bool)NotificationRadioButton.IsChecked)
                {
                    _noticeService.Delete((await _noticeService.GetNoticeByDesignationAsync(((ViewNotice)DataGrid.SelectedItem).Designation)).Id);
                    await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                    {
                        UserId = LoginWindow.CurrentUser.Id,
                        TableId = await _tableService.GetTableByIdAsync((int)TableName.Notice),
                        SystemEventId = (int)BTDSystemEvents.Deleting,
                        DateOfEvent = DateTime.Now
                    });
                }
                SystemSounds.Hand.Play();
                MessageBox.Show("Запись успешно удалена!");
                return;
            }
            else if ((bool)EventLogRadioButton.IsChecked)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Вы не можете добавлять событие!");
                return;
            }
            SystemSounds.Hand.Play();
            MessageBox.Show("Запись не выбрана!");
        }

        //Print Datagrid to Excel and try to open after
        private async void ReportExcelButton_Click(object sender, RoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog();
            if (LoginWindow.CurrentUser.UserCapabilities.CanMakeReport)
            {
                saveDlg.Filter = "Excel documents|*.xlsx";
                if (!saveDlg.ShowDialog().GetValueOrDefault())
                    return;
                var options = new ExcelExportingOptions();
                options.ExcelVersion = ExcelVersion.Excel2010;
                using var excelEngine = DataGrid.ExportToExcel(DataGrid.View, options);
                var workBook = excelEngine.Excel.Workbooks[0];
                IWorksheet worksheet = workBook.Worksheets[0];
                worksheet.UsedRange.AutofitColumns();
                workBook.SaveAs(saveDlg.FileName);
                if ((bool)AllDocumentationRadioButton.IsChecked
                        || (bool)TechDocumentationRadioButton.IsChecked
                        || (bool)DesDocumentationRadioButton.IsChecked)
                {
                    await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                    {
                        UserId = LoginWindow.CurrentUser.Id,
                        TableId = await _tableService.GetTableByIdAsync((int)TableName.Cards),
                        SystemEventId = (int)BTDSystemEvents.MakingReport,
                        DateOfEvent = DateTime.Now
                    });
                }
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Вы не можете созадвать отчет по документации, обратитесь к администратору!");
                return;
            }
            if ((bool)NotificationRadioButton.IsChecked)
            {

                await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                {
                    UserId = LoginWindow.CurrentUser.Id,
                    TableId = await _tableService.GetTableByIdAsync((int)TableName.Notice),
                    SystemEventId = (int)BTDSystemEvents.MakingReport,
                    DateOfEvent = DateTime.Now
                });
            }
            if ((bool)UsersRadioButton.IsChecked)
            {
                await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                {
                    UserId = LoginWindow.CurrentUser.Id,
                    TableId = await _tableService.GetTableByIdAsync((int)TableName.Users),
                    SystemEventId = (int)BTDSystemEvents.MakingReport,
                    DateOfEvent = DateTime.Now
                });
            }

            if (MessageBox.Show("Открыть файл " + saveDlg.SafeFileName + " ? ", saveDlg.SafeFileName, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using var p = new Process();
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = saveDlg.FileName;
                p.Start();
            }

        }
        //Open Print Preview Window
        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.CurrentUser.UserCapabilities.CanMakeReport)
            {
                DataGrid.PrintSettings = new PrintSettings();
                DataGrid.PrintSettings.AllowPrintByDrawing = false;
                DataGrid.PrintSettings.PrintPageOrientation = PrintOrientation.Landscape;
                DataGrid.ShowPrintPreview();
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Вы не можете созадвать отчет по документации, обратитесь к администратору!");
            }
        }
        //Print Datagrid to PDF and try to open after
        private async void ReportPdfButton_Click(object sender, RoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog();
            if (LoginWindow.CurrentUser.UserCapabilities.CanMakeReport)
            {
                saveDlg.Filter = "PDF documents|*.pdf";
                if (!saveDlg.ShowDialog().GetValueOrDefault())
                    return;
                PdfExportingOptions options = new PdfExportingOptions();
                var document = new PdfDocument();
                document.PageSettings.Orientation = PdfPageOrientation.Landscape;
                var page = document.Pages.Add();
                options.AutoRowHeight = true;
                options.ExportFormat = false;
                options.FitAllColumnsInOnePage = true;
                var PDFGrid = DataGrid.ExportToPdfGrid(DataGrid.View, options);
                var format = new PdfGridLayoutFormat()
                {
                    Layout = PdfLayoutType.Paginate,
                    Break = PdfLayoutBreakType.FitPage
                };
                PDFGrid.Draw(page, new PointF(), format);
                document.Save(saveDlg.FileName);
                if ((bool)AllDocumentationRadioButton.IsChecked
                        || (bool)TechDocumentationRadioButton.IsChecked
                        || (bool)DesDocumentationRadioButton.IsChecked)
                {
                    await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                    {
                        UserId = LoginWindow.CurrentUser.Id,
                        TableId = await _tableService.GetTableByIdAsync((int)TableName.Cards),
                        SystemEventId = (int)BTDSystemEvents.MakingReport,
                        DateOfEvent = DateTime.Now
                    });
                }
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Вы не можете созадвать отчет по документации, обратитесь к администратору!");
                return;
            }
            if ((bool)NotificationRadioButton.IsChecked)
            {
                await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                {
                    UserId = LoginWindow.CurrentUser.Id,
                    TableId = await _tableService.GetTableByIdAsync((int)TableName.Notice),
                    SystemEventId = (int)BTDSystemEvents.MakingReport,
                    DateOfEvent = DateTime.Now
                });
            }
            if ((bool)UsersRadioButton.IsChecked)
            {
                await _eventLogService.AddAsync(new BTDCore.Models.EventLog
                {
                    UserId = LoginWindow.CurrentUser.Id,
                    TableId = await _tableService.GetTableByIdAsync((int)TableName.Users),
                    SystemEventId = (int)BTDSystemEvents.MakingReport,
                    DateOfEvent = DateTime.Now
                });
            }
            if (MessageBox.Show("Открыть файл " + saveDlg.SafeFileName + " ? ", saveDlg.SafeFileName, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using var p = new Process();
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = saveDlg.FileName;
                p.Start();
            }
        }
        //reload table
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Documentation_Click(sender, e);
        }

        private async void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((bool)NotificationRadioButton.IsChecked)
            {
                if (DataGrid.SelectedItem is not null)
                {
                    try
                    {
                        var notice = await _noticeService.GetNoticeByDesignationAsync(((ViewNotice)DataGrid.SelectedItem).Designation);
                        using var process = new Process();
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.FileName = notice.Paths;
                        process.Start();
                    }
                    catch (Win32Exception)
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Проверьте целостность файла!");
                    }
                }
            }
        }

        private void ExpandTableButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DataGridExpand)
            {
                DataGrid.ColumnSizer = GridLengthUnitType.AutoWithLastColumnFill;
                ExpandTableButton.Style = (Style)ExpandTableButton.FindResource("ModernExpandButtonPressed");
                DataGridExpand = true;
            }
            else
            {
                DataGrid.ColumnSizer = GridLengthUnitType.Star;
                ExpandTableButton.Style = (Style)ExpandTableButton.FindResource("ModernExpandButton");
                DataGridExpand = false;
            }
        }

        private async void LeaveButton_Click(object sender, RoutedEventArgs e)
        {           
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
            await _eventLogService.AddAsync(new BTDCore.Models.EventLog
            {
                UserId = LoginWindow.CurrentUser.Id,
                TableId = default,
                SystemEventId = (int)BTDSystemEvents.ExitFromSystem,
                DateOfEvent = DateTime.Now
            }); 
            LoginWindow.CurrentUser = new User();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                using var process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = Directory.GetCurrentDirectory() + @"/helpBTD.chm";
                process.Start();
            }
            catch (Win32Exception)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Проверьте целостность файла!");
            }
        }
    }
}
