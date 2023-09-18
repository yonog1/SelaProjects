using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace File
{
    public partial class Form1 : Form
    {
        private BackgroundWorker searchWorker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            TextBoxFilePath.Text = "try.py";
            TextBoxRootPath.Text = "C:\\Users\\max25\\Desktop";

            // Initialize the BackgroundWorker
            searchWorker.DoWork += SearchWorker_DoWork;
            searchWorker.RunWorkerCompleted += SearchWorker_RunWorkerCompleted;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string rootDir = TextBoxRootPath.Text;
            string fileName = TextBoxFilePath.Text;

            // Start the background worker
            searchWorker.RunWorkerAsync(new Tuple<string, string>(rootDir, fileName));
        }

        static string SearchFile(string rootPath, string fileName)
        {
            if (!Directory.Exists(rootPath))
            {
                Console.WriteLine("Directory doesn't exist");
                return null;
            }

            foreach (string subDir in Directory.GetDirectories(rootPath))
            {
                string filePath = SearchFile(subDir, fileName);
                if (filePath != null)
                {
                    return filePath; // return path when found
                }
            }

            foreach (string file in Directory.GetFiles(rootPath))
            {
                if (file == Path.Combine(rootPath, fileName))
                {
                    return Path.Combine(rootPath, fileName); // return path when found
                }
            }

            return null; // return null if not found
        }

        private void Start_Click(object sender, EventArgs e)
        {
            string rootDir = TextBoxRootPath.Text;
            DirectoryInfo dir = new DirectoryInfo(rootDir);

            // Clear the existing nodes in the TreeView
            treeView1.Nodes.Clear();

            treeView1.Nodes.Add(new TreeNode(rootDir));
            GetDirsFiles(dir, treeView1.Nodes[0]);
        }


        private void SearchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Perform the file search in the background
            var args = e.Argument as Tuple<string, string>;
            string rootDir = args.Item1;
            string fileName = args.Item2;

            string filePath = SearchFile(rootDir, fileName);
            e.Result = filePath;
        }

        private void SearchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}");
            }
            else
            {
                string filePath = e.Result as string;

                if (filePath != null)
                {
                    // Display the file path in the TreeView
                    treeView1.Nodes.Add(new TreeNode(filePath));
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
        }

        public void GetDirsFiles(DirectoryInfo d, TreeNode node)
        {
            // Add all files in the subdirectory to the TreeView
            FileInfo[] files = d.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                String fileName = file.FullName;
                String fileSize = file.Length.ToString() + " Bytes";
                String fileExtension = file.Extension;
                String fileCreated = file.LastWriteTime.ToString();

                node.Nodes.Add(string.Format("{0} {1} {2} {3}", fileName, fileSize,
                                    fileExtension, fileCreated));
            }

            // Add all subdirectories to the treeview
            DirectoryInfo[] dirs = d.GetDirectories("*.*");
            foreach (DirectoryInfo dir in dirs)
            {
                node.Nodes.Add(dir.Name);
                GetDirsFiles(dir, node.Nodes[node.Nodes.Count - 1]);
            }

        }
    }
}
