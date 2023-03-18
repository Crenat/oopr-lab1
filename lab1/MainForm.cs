using lab1.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab1
{
    public partial class MainForm : Form
    {
        private List<TVViewModel> TVs;

        public MainForm()
        {
            InitializeComponent();

            GenerateTVFile();

            TVs = File.ReadAllLines(Constants.FILE_NAME)
                .Select(line => line.Split(','))
                .Select(parts => new TVViewModel
                {
                    Brand = parts[0],
                    Price = decimal.Parse(parts[1]),
                    Manufacturer = parts[2]
                })
                .ToList();

            TVViewModel theMostExpenciveTV = GetTheMostExpenciveTV(TVs);

            text.Text = $"The most expencive TV is: {theMostExpenciveTV}";
        }

        private void GenerateTVFile()
        {
            var TVs = new List<TVViewModel>
            {
                new TVViewModel { Brand = "Samsung", Price = 12999.99m, Manufacturer = "South Korea" },
                new TVViewModel { Brand = "Hisense", Price = 17999.99m, Manufacturer = "China" },
                new TVViewModel { Brand = "Samsung", Price = 27999.99m, Manufacturer = "South Korea" },
                new TVViewModel { Brand = "Philips", Price = 7599.99m, Manufacturer = "Poland" },
                new TVViewModel { Brand = "Samsung", Price = 27999.99m, Manufacturer = "South Korea" },
            };

            using (var writer = new StreamWriter(Constants.FILE_NAME))
            {
                foreach (var tv in TVs)
                {
                    writer.WriteLine($"{tv.Brand},{tv.Price},{tv.Manufacturer}");
                }
            }
        }

        private TVViewModel GetTheMostExpenciveTV(List<TVViewModel> TVs)
        {
            TVViewModel theMostExpenciveTV = null;
            foreach (var TV in TVs)
            {
                if(theMostExpenciveTV == null)
                {
                    theMostExpenciveTV = TV;
                } else if(TV.Price > theMostExpenciveTV.Price)
                {
                    theMostExpenciveTV = TV;
                }
            }
            return theMostExpenciveTV;
        }
    }
}
