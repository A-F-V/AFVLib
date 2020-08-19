using System;
using System.Windows.Forms;

namespace AFVLib.PAPP
{
    internal class PastelApp
    {
        private readonly PastelConsole pc;

        public PastelApp(ColourPalette cp = null)
        {
            pc = cp == null ? new PastelConsole(ColourPalette.MarineFields) : new PastelConsole(cp);
        }

        public void SayMessage(string message, int color = -2)
        {
            pc.WriteLine(message, color);
        }

        public T AskQuestion<T>(string message, Func<string, T> parser)
        {
            pc.WriteLine(message, -3);
            return parser(Console.ReadLine());
        }

        public string FilePathDialog(string Filter = "All Files (*.*)|*.*")
        {
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = Filter;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
            }

            return filePath;
        }

        public string FolderPathDialog()
        {
            string folderPath = string.Empty;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    folderPath = fbd.SelectedPath;
            }

            return folderPath;
        }
    }
}