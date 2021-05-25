using BTDCore.Models;
using BTDCore.ViewModels;
using BTDService.Services.db.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BTD.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUpdateDocumentation.xaml
    /// </summary>
    public partial class AddUpdateDocumentationWindow : Window
    {
        ICardService _cardService;
        public AddUpdateDocumentationWindow(Documentation document = default)
        {
            InitializeComponent();
            _cardService = new CardService();
            _cardService.Load();
            if (document is not null)
            {
                DesignationTextBox.Text = document.Designation;
                NameTextBox.Text = document.Name;
                A0TextBox.Text = document.A0.ToString();
                A1TextBox.Text = document.A1.ToString();
                A2TextBox.Text = document.A2.ToString();
                A3TextBox.Text = document.A3.ToString();
                A4TextBox.Text = document.A4.ToString();
                TypeDocumnetComboBox.SelectedItem = _cardService.GetTypeOfDocument(document.TypeId);                
                TemporaryCheckBox.IsChecked = document.IsTemporary;
                CanceledCheckBox.IsChecked = document.IsCanceled;
                NoteTextBlock.Text = document.Note;
            }

            SaveButton.Click += (sender, e) => 
            {
                if (!DesignationTextBox.Text.Equals("") 
                    && !NameTextBox.Text.Equals("")
                    && !A0TextBox.Text.Equals("")
                    && !A1TextBox.Text.Equals("")
                    && !A2TextBox.Text.Equals("")
                    && !A3TextBox.Text.Equals("")
                    && !A4TextBox.Text.Equals("")
                    && TypeDocumnetComboBox.SelectedValue is not null)
                {
                    if (document is not null)
                    {
                        Card oldCard = _cardService.GetCardByDesignation(document.Designation);
                        oldCard.Designation = DesignationTextBox.Text;
                        oldCard.Name = NameTextBox.Text;
                        oldCard.A0 = int.Parse(A0TextBox.Text);
                        oldCard.A1 = int.Parse(A1TextBox.Text);
                        oldCard.A2 = int.Parse(A2TextBox.Text);
                        oldCard.A3 = int.Parse(A3TextBox.Text);
                        oldCard.A4 = int.Parse(A4TextBox.Text);
                        oldCard.TypeId = TypeDocumnetComboBox.SelectedIndex + 1;
                        oldCard.DateOfChanges = DateTime.Now;
                        oldCard.IsTemporary = (bool)TemporaryCheckBox.IsChecked;
                        oldCard.IsCanceled = (bool)CanceledCheckBox.IsChecked;
                        oldCard.Note = NoteTextBlock.Text;
                        _cardService.Update(oldCard);
                    }
                    else
                    {
                        Card newCard = new Card();
                        newCard.Designation = DesignationTextBox.Text;
                        newCard.Name = NameTextBox.Text;
                        newCard.DateOfRegistration = DateTime.Now;
                        newCard.A0 = int.Parse(A0TextBox.Text);
                        newCard.A1 = int.Parse(A1TextBox.Text);
                        newCard.A2 = int.Parse(A2TextBox.Text);
                        newCard.A3 = int.Parse(A3TextBox.Text);
                        newCard.A4 = int.Parse(A4TextBox.Text);
                        newCard.TypeId = TypeDocumnetComboBox.SelectedIndex + 1;
                        newCard.DateOfChanges = DateTime.Now;
                        newCard.IsTemporary = (bool)TemporaryCheckBox.IsChecked;
                        newCard.IsCanceled = (bool)CanceledCheckBox.IsChecked;
                        newCard.Note = NoteTextBlock.Text;
                        _cardService.Add(newCard);
                    }
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Данные были сохранены!");
                    Close();
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Данные заполнены некорректно!");
                }
                
            };
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TypeDocumnetComboBox.ItemsSource = _cardService.GetTypesOfDocumentation();
        }

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{

        //    _cardService.Save();
        //}

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ATextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsNumber(c))
                e.Handled = false;
            else
                e.Handled = true;

            base.OnPreviewTextInput(e);
        }
    }
}
