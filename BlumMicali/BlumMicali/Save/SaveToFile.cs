using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace BlumMicali.Save
{
    internal class SaveToFile
    {
        // Сохранение случайных чисел в txt файл
        private void SaveTxt(string numbers, string fileName)
        {            
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                    writer.Write(numbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла!\n{ex}", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        // Сохранение случайных чисел
        public void SaveFile(string numbers)
        {
            SaveFileDialog savefile = new SaveFileDialog
            {
                FileName = "BlumMicali.txt",
                Filter = "Text files (*.txt)|*.txt"
            };

            if (savefile.ShowDialog() == true)
            {
                SaveTxt(numbers, savefile.FileName);
            }
        }
    }
}
