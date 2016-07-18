using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QueueManager;
using System.IO;

namespace MovieQueueManagerGUI
{
    public partial class Form1 : Form
    {
        private QueueManagers _queueManager = new QueueManagers();

        public Form1()
        {
            InitializeComponent();
            DisplayListOfMovies();
            openFileDialog1.InitialDirectory = "C:\\Users\\"+Environment.UserName+"\\AppData\\Local\\QueueManager";
            HandleCommandLineArguments();
            _queueManager.CopyListForSaveOnQuit();
        }

        private void HandleCommandLineArguments()
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string filePath = args[1];

                if (File.Exists(filePath))
                {
                    string name = Path.GetFileNameWithoutExtension(filePath);
                    QueueFileManager queueFileManager = new QueueFileManager();
                    _queueManager.AddMovieToQueue(queueFileManager.OpenFile(filePath));
                    DisplayListOfMovies();
                }
            }
        }

        private void DisplayListOfMovies()
        {
            movieListBox.Items.Clear();
            List<string> movieList = _queueManager.GetMovieList();

            foreach (var item in movieList)
            {
                movieListBox.Items.Add(item);
            }
            
            UpdateCounter();
        }

        private void UpdateCounter()
        {
            List<string> movieList = _queueManager.GetMovieList();
            numberOfMoviesLabel.Text = movieListBox.Items.Count + "/" + movieList.Count.ToString() + " Movies Displayed";
            
        }

        private void ShowAddMovieDialog()
        {
            List<string> movieName = new List<string>();
            movieName.Add(Microsoft.VisualBasic.Interaction.InputBox("Enter The Movie Name", "Add Movie", "Default", this.Location.X+10, this.Location.Y+100));
            _queueManager.AddMovieToQueue(movieName);

            DisplayListOfMovies();
        }

        private void DeleteMovie()
        {
            IEnumerable<string> selectedItemsToBeDeleted = movieListBox.SelectedItems.Cast<string>();
            _queueManager.DeleteMovieFromQueue(selectedItemsToBeDeleted.ToArray<string>());

            movieSearchBox.Clear();
            DisplayListOfMovies();
        }

        private void RemoveMovieFromListBox(IEnumerable<string> selectedItemsToBeDeleted)
        {
            List<string> itemsToBeDeleted = selectedItemsToBeDeleted.ToList<string>();
            foreach (var item in itemsToBeDeleted)
            {
                movieListBox.Items.Remove(item);
            }
        }

        private void OpenListOfMovies()
        {
            openFileDialog1.Filter = "Movie List Files (*.mof)|*.mof";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _queueManager.DeleteMovieFromQueue(_queueManager.GetMovieList().ToArray());
                    QueueFileManager _queueFileManager = new QueueFileManager();
                    List<string> listToLoad = _queueFileManager.OpenFile(openFileDialog1.FileName);
                    _queueManager.AddMovieToQueue(listToLoad);
                    _queueManager.CopyListForSaveOnQuit();
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    MessageBox.Show("Please select a valid file");
                }
            }

            DisplayListOfMovies();
        }

        private void AddListOfMovies()
        {
            openFileDialog1.Filter = "Movie List Files (*.mof)|*.mof";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    QueueFileManager _queueFileManager = new QueueFileManager();
                    List<string> listToLoad = _queueFileManager.OpenFile(openFileDialog1.FileName);
                    _queueManager.AddMovieToQueue(listToLoad);
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    MessageBox.Show("Please select a valid file");
                }
            }

            DisplayListOfMovies();
        }

        private void LoadPlaintextMovies()
        {
            openFileDialog1.Filter = "Movie List Files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                QueueFileManager _queueFileManager = new QueueFileManager();
                _queueManager.LoadListOfMoviesFromTextFile(openFileDialog1.FileName);
            }
            DisplayListOfMovies();
        }

        private void FilterSearch()
        {
            SearchManager searchManager = new SearchManager();
            List<string> searchedList = searchManager.SearchFor(_queueManager.GetMovieList(), movieSearchBox.Text);
            movieListBox.Items.Clear();
            foreach(var item in searchedList)
            {
            movieListBox.Items.Add(item);
            }

            UpdateCounter();
        }

        private void SortListOfMovies()
        {
            _queueManager.SortListOfMovies();
            DisplayListOfMovies();
        }

        private void SaveOnQuit()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                QueueFileManager _queueFileManager = new QueueFileManager();
                _queueFileManager.SaveFile(saveFileDialog1.FileName, _queueManager.GetMovieList());
            }
        }

        private string ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            return "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddMovieDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteMovie();
        }

        private void AddMovieList_Click(object sender, EventArgs e)
        {
            OpenListOfMovies();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            SortListOfMovies();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterSearch();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_queueManager.QueueHasBeenModified())
            {
                SaveOnQuit();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListOfMovies();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOnQuit();
        }

        private void importPlaintextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPlaintextMovies();
        }

        private void MoviePanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "F")
            {
                movieSearchBox.SelectAll();
                movieSearchBox.Select();
            }
        }

        private void loadDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryReader directoryReader = new DirectoryReader();
            Dictionary<string, string> dictionaryOfPathsAndNames = new Dictionary<string,string>();
            List<string> listOfNames = new List<string>();

            listOfNames = directoryReader.GetListOfMoviesFromDirectory(ChooseFolder());
            dictionaryOfPathsAndNames = directoryReader.CreateDictionaryForNamesAndPaths(listOfNames);
            listOfNames = directoryReader.GetListOfFileNames(dictionaryOfPathsAndNames);
            _queueManager.AddMovieToQueue(listOfNames);
            DisplayListOfMovies();
        }

        private void importMovieListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddListOfMovies();
        }
    }
}
