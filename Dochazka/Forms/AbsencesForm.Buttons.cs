using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Dochazka {
    public partial class AbsencesForm {
        
        private void PrintBtn_Click(object sender, EventArgs e) {
            //MessageBox.Show("Tato funkce je ještě ve vývoji.", "Brzy dostupné");
            PrintDialog dialog = new PrintDialog();
            
            PrintDocument printDocument = PrepareDocument();
            dialog.Document = printDocument;
            dialog.ShowDialog();
            
        }

        private PrintDocument PrepareDocument() {
            PrintDocument document = new PrintDocument();
            document.DocumentName = "Prezence";
            document.PrintPage+= new PrintPageEventHandler(PrintPage);
            return document;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev) {
            Queue<string[]> lineQueue = new Queue<string[]>(lines);
            Font font = new Font("Arial", 12);
            float linesPerPage = ev.MarginBounds.Height/font.GetHeight(ev.Graphics);
            
            int count = 0;
            string line = null;
            float yPos = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string headLine = "Jmeno | P | N | O | Celkova absence";
            yPos = topMargin;
            ev.Graphics.DrawString(headLine, font, Brushes.Black, leftMargin, yPos, new StringFormat());
            count++;
            while (count < linesPerPage && lineQueue.Count > 0) {
                string[] lineArr = lineQueue.Dequeue();
                line = string.Format("{0} | {1} | {2} | {3} | {4}", lineArr[0], lineArr[1], lineArr[2], lineArr[3],
                    lineArr[4]);
                yPos = topMargin + (count * font.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line,font,Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            if (lineQueue.Count>0)
                ev.HasMorePages = true;
            else {
                ev.HasMorePages = false;
            }
        }
        
        private void CloseBtn_Click(object sender, EventArgs e) {
            Close();
        }
    }
}