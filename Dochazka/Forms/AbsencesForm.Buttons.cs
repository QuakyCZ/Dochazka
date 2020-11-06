using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Dochazka {
    public partial class AbsencesForm {
        private Bitmap _bitmap;
        
        private void PrintBtn_Click(object sender, EventArgs e) {
            _bitmap = new Bitmap(presenceList.Size.Width,presenceList.Size.Height);
            presenceList.DrawToBitmap(_bitmap,new Rectangle(0,0,presenceList.Size.Width,presenceList.Size.Height));
            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.WindowState = FormWindowState.Maximized;
            PrintDocument printDocument = PrepareDocument();
            dialog.Document = printDocument;
            dialog.ShowDialog();
            
        }

        private PrintDocument PrepareDocument() {
            PrintDocument document = new PrintDocument();
            document.DocumentName = "Prezence";
            //document.DefaultPageSettings.Landscape = true;
            document.PrintPage+= PrintPage;
            return document;
        }

        private string[] Headers = {"Jméno", "Přítomen", "Neomluvená absence", "Omluvená absence", "Absence celkem"};
        
        
        private void PrintPage(object sender, PrintPageEventArgs e) {
            using (Font header_font = new Font("Times New Roman",
                12, FontStyle.Bold))
            {
                
                using (Font body_font = new Font("Times New Roman", 11))
                {
                    int line_spacing = 20;

                    int[] column_widths = FindColumnWidths(
                        e.Graphics, header_font, body_font, Headers, lines);

                    
                    int x = e.MarginBounds.Left;
                    int y = e.MarginBounds.Top;
                    e.Graphics.DrawString("Prezence " + _dateTime.Month + " " + _dateTime.Year,header_font,Brushes.Black, x,y);
                    y += line_spacing;
                    
                    for (int col = 0; col < Headers.Length; col++)
                    {
                        
                        y = e.MarginBounds.Top + 50;
                        e.Graphics.DrawString(Headers[col],
                            header_font, Brushes.Blue, x, y);
                        y += (int)(line_spacing * 1.5);

                        
                        for (int row = 0; row <
                                          lines.Count; row++)
                        {
                            e.Graphics.DrawString(lines[row][col],
                                body_font, Brushes.Black, x, y);
                            y += line_spacing;
                        }
                        
                        x += column_widths[col];
                    }
                }
            }

            //DrawGrid(e, y)
            e.HasMorePages = false;
        }
        
        private int[] FindColumnWidths(Graphics gr, Font header_font,
            Font body_font, string[] headers, List<string[]> values)
        {
            // Make room for the widths.
            int[] widths = new int[headers.Length];

            // Find the width for each column.
            for (int col = 0; col < widths.Length; col++)
            {
                // Check the column header.
                widths[col] = (int)gr.MeasureString(
                    headers[col], header_font).Width;

                // Check the items.
                for (int row = 0; row < values.Count; row++)
                {
                    int value_width = (int)gr.MeasureString(
                        values[row][col], body_font).Width;
                    if (widths[col] < value_width)
                        widths[col] = value_width;
                }

                // Add some extra space.
                widths[col] += 20;
            }

            return widths;
        }
        
        
        private void CloseBtn_Click(object sender, EventArgs e) {
            Close();
        }
        
        
    }
}