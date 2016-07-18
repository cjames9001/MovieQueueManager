namespace MovieQueueManagerGUI
{
    partial class Form1
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
            this.MoviePanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.AddMovieList = new System.Windows.Forms.Button();
            this.movieListBox = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SortButton = new System.Windows.Forms.Button();
            this.movieSearchBox = new System.Windows.Forms.TextBox();
            this.searchText = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.numberOfMoviesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPlaintextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMovieListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MoviePanel
            // 
            this.MoviePanel.Location = new System.Drawing.Point(10, 35);
            this.MoviePanel.Name = "MoviePanel";
            this.MoviePanel.Size = new System.Drawing.Size(400, 700);
            this.MoviePanel.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(15, 28);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Movie";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(108, 28);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete Movie";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddMovieList
            // 
            this.AddMovieList.Location = new System.Drawing.Point(201, 28);
            this.AddMovieList.Name = "AddMovieList";
            this.AddMovieList.Size = new System.Drawing.Size(115, 23);
            this.AddMovieList.TabIndex = 2;
            this.AddMovieList.Text = "Add New Movie List";
            this.AddMovieList.UseVisualStyleBackColor = true;
            this.AddMovieList.Click += new System.EventHandler(this.AddMovieList_Click);
            // 
            // movieListBox
            // 
            this.movieListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieListBox.FormattingEnabled = true;
            this.movieListBox.Location = new System.Drawing.Point(13, 82);
            this.movieListBox.Name = "movieListBox";
            this.movieListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.movieListBox.Size = new System.Drawing.Size(397, 446);
            this.movieListBox.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Movie List Files (*.mof)|*.mof";
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(335, 28);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(75, 23);
            this.SortButton.TabIndex = 4;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // movieSearchBox
            // 
            this.movieSearchBox.Location = new System.Drawing.Point(60, 57);
            this.movieSearchBox.Name = "movieSearchBox";
            this.movieSearchBox.Size = new System.Drawing.Size(149, 20);
            this.movieSearchBox.TabIndex = 6;
            this.movieSearchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // searchText
            // 
            this.searchText.AutoSize = true;
            this.searchText.Location = new System.Drawing.Point(16, 60);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(44, 13);
            this.searchText.TabIndex = 7;
            this.searchText.Text = "Search:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberOfMoviesLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(422, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // numberOfMoviesLabel
            // 
            this.numberOfMoviesLabel.Name = "numberOfMoviesLabel";
            this.numberOfMoviesLabel.Size = new System.Drawing.Size(118, 17);
            this.numberOfMoviesLabel.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(422, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.addToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDirectoryToolStripMenuItem,
            this.importPlaintextToolStripMenuItem,
            this.importMovieListToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // loadDirectoryToolStripMenuItem
            // 
            this.loadDirectoryToolStripMenuItem.Name = "loadDirectoryToolStripMenuItem";
            this.loadDirectoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadDirectoryToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.loadDirectoryToolStripMenuItem.Text = "&Load Directory";
            this.loadDirectoryToolStripMenuItem.Click += new System.EventHandler(this.loadDirectoryToolStripMenuItem_Click);
            // 
            // importPlaintextToolStripMenuItem
            // 
            this.importPlaintextToolStripMenuItem.Name = "importPlaintextToolStripMenuItem";
            this.importPlaintextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importPlaintextToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.importPlaintextToolStripMenuItem.Text = "&Import Plaintext";
            this.importPlaintextToolStripMenuItem.Click += new System.EventHandler(this.importPlaintextToolStripMenuItem_Click);
            // 
            // importMovieListToolStripMenuItem
            // 
            this.importMovieListToolStripMenuItem.Name = "importMovieListToolStripMenuItem";
            this.importMovieListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.importMovieListToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.importMovieListToolStripMenuItem.Text = "Import &Movie List";
            this.importMovieListToolStripMenuItem.Click += new System.EventHandler(this.importMovieListToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 551);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.movieSearchBox);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.movieListBox);
            this.Controls.Add(this.AddMovieList);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoviePanel_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Panel MoviePanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button AddMovieList;
        private System.Windows.Forms.ListBox movieListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.TextBox movieSearchBox;
        private System.Windows.Forms.Label searchText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel numberOfMoviesLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPlaintextToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem loadDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMovieListToolStripMenuItem;
    }
}

