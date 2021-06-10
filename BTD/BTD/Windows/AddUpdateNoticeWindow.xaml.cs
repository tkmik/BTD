using BTDCore.Models;
using BTDCore.ViewModels;
using BTDService.Services.db.EventsLogs;
using BTDService.Services.db.Notices;
using BTDService.Services.db.Tables;
using Microsoft.Win32;
using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace BTD.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUpdateNoticeWindow.xaml
    /// </summary>
    public partial class AddUpdateNoticeWindow : Window
    {
        private readonly INoticeService _noticeService;
        private readonly IEventsLogService _eventLogService;
        private readonly ITableService _tableService;
        private Notice Notice { get; set; }
        public AddUpdateNoticeWindow(ViewNotice notice = default)
        {
            InitializeComponent();
            _noticeService = new NoticeService();
            _eventLogService = new EventsLogService();
            _tableService = new TableService();
            if (notice is not null)
            {
                DesignationTextBox.Text = notice.Designation;
                ChoiceButton.Content = notice.Name;
                NoteTextBlock.Text = notice.Note;
            }
            SaveButton.Click += async (sender, e) =>
            {
                var copyFile =
                       new FileInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                    @"\Notices\");
                if (!DesignationTextBox.Text.Equals("")
                    && !ChoiceButton.Content.Equals(""))
                {
                    if (notice is not null)
                    {
                        var note = _noticeService.GetNoticeByDesignationAsync(notice.Designation).Result;
                        note.Designation = DesignationTextBox.Text;
                        note.Name = ChoiceButton.Content.ToString();
                        note.Note = NoteTextBlock.Text;
                        note.Paths = copyFile + note.Name;
                        await _noticeService.UpdateAsync(note);
                        await _eventLogService.AddAsync(new EventLog 
                        {
                            UserId = LoginWindow.CurrentUser.Id,
                            TableId = await _tableService.GetTableByIdAsync((int)TableName.Notice),
                            SystemEventId = (int)BTDSystemEvents.Editing,
                            DateOfEvent = DateTime.Now
                        });
                        SystemSounds.Hand.Play();
                    }
                    else
                    {
                        Notice = new Notice
                        {
                            Designation = DesignationTextBox.Text,
                            Name = ChoiceButton.Content.ToString(),
                            Note = NoteTextBlock.Text,
                            Paths = copyFile.ToString() + ChoiceButton.Content.ToString()
                        };
                        _noticeService.Add(Notice);
                        await _eventLogService.AddAsync(new EventLog
                        {
                            UserId = LoginWindow.CurrentUser.Id,
                            TableId = await _tableService.GetTableByIdAsync((int)TableName.Notice),
                            SystemEventId = (int)BTDSystemEvents.Adding,
                            DateOfEvent = DateTime.Now
                        });
                    }
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Данные были сохранены!");
                    Close();
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Данные введены некорректно!");
                }
            };
        }

        private void ChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            var openDlg = new OpenFileDialog();
            var copyFile =
                        new FileInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                     @"\Notices\");
            try
            {
                openDlg.Filter = "Word documents|*.docx";
                if (!openDlg.ShowDialog().GetValueOrDefault())
                    return;
                var file = new FileInfo(openDlg.FileName);
                Directory.CreateDirectory(copyFile.ToString());
                file.CopyTo(copyFile + openDlg.SafeFileName);
                copyFile.IsReadOnly = true;
                ChoiceButton.Content = openDlg.SafeFileName;
            }
            catch (IOException)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Такой файл уже существует!");
            }
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
            Close();
            ChoiceButton.Content = "Загрузить";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ChoiceButton.Content = "Загрузить";
        }
    }
}
