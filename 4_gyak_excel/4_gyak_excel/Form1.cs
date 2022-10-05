﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace _4_gyak_excel
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();

                xlWB = xlApp.Workbooks.Add(Missing.Value);

                xlSheet = xlWB.ActiveSheet;

                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void CreateTable()
        {
            string[] headers = new string[] {
                 "Kód",
                 "Eladó",
                 "Oldal",
                 "Kerület",
                 "Lift",
                 "Szobák száma",
                 "Alapterület (m2)",
                 "Ár (mFt)",
                 "Négyzetméter ár (Ft/m2)"};

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i+1] = headers[i];
            }
            
            object[,] values = new object[Flats.Count, headers.Length];

            int sorszam = 0;
            foreach (var flat in Flats)
            {
                values[sorszam, 0] = flat.Code;
                values[sorszam, 1] = flat.Vendor;
                values[sorszam, 2] = flat.Side;
                values[sorszam, 3] = flat.District;
                if (flat.Elevator)
                {
                    values[sorszam, 4] = "Van";
                }
                else
                {
                    values[sorszam, 4] = "Nincs";
                };
                values[sorszam, 5] = flat.NumberOfRooms;
                values[sorszam, 6] = flat.FloorArea;
                values[sorszam, 7] = flat.Price;
                values[sorszam, 8] = "";
                sorszam++;
            }

            xlSheet.get_Range(
            GetCell(2, 1),
            GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
            xlSheet.get_Range(
            GetCell(2, 9),
            GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = "=1000000*H2/G2";
        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
