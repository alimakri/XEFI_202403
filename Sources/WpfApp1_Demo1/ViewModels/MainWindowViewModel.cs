using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1_Demo1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand ChangerTitreCommand { get; set; }
        public RelayCommand BlocNoteCommand { get; set; }
        public RelayCommand FermerCommand { get; set; }
        private string titre = "Titre 1";

        public string Titre
        {
            get { return titre; }
            set
            {
                titre = value; OnPropertyChanged("Titre");
            }
        }
        public MainWindowViewModel()
        {
            ChangerTitreCommand = new RelayCommand(ChangerTitreCommandExecute);
            BlocNoteCommand = new RelayCommand(BlocNoteCommandExecute);
            FermerCommand = new RelayCommand(FermerCommandExecute);
        }

        private void FermerCommandExecute(object obj)
        {
            ((Window)obj).Close();
        }

        private void BlocNoteCommandExecute(object obj)
        {
            try
            {
                Process.Start("notepad.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangerTitreCommandExecute(object obj)
        {
            Titre = "Nouveau titre";
        }
    }
}
