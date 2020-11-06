using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Dochazka {
    public partial class AbsencesForm {
        private PrintDocument _document;
        private Document pdfDocument;

        private string[] Headers = {"Jméno", "P", "N", "O", "Celkem"};
        private void savePDFBtn_Click(object sender, EventArgs e) {
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Prezence.pdf";
            dialog.Filter = "PDF|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    CreatePDF();
                    File.Copy(Path.Combine(Program.DBROOTFOLDER,"doc.pdf"),dialog.FileName,true);
                }
                catch(Exception ex) {
                    MessageBox.Show("Dokument nebylo možné uložit.", "Chyba");
                    Console.WriteLine(ex);
                }
            }
        }

        private void CreatePDF() {
            pdfDocument = new Document();
            PdfWriter.GetInstance(pdfDocument, new FileStream(Path.Combine(Program.DBROOTFOLDER,"doc.pdf"), FileMode.Create));
            pdfDocument.Open();
            pdfDocument.AddLanguage("cs-cz");
            pdfDocument.Add(CreateParagraph("Prezence " + _dateTime.Month + ". " + _dateTime.Year, 15));
            pdfDocument.Add(CreateParagraph("\n", 15));

            PdfPTable table = new PdfPTable(5);
            for (int i = 0; i < Headers.Length; i++) {
                table.AddCell(CreateParagraph(Headers[i], 12));
            }
            foreach (string[] studentData in lines) {
                for (int i = 0; i < studentData.Length; i++) {
                    table.AddCell(studentData[i]);
                }
            }

            pdfDocument.Add(table);
            pdfDocument.Close();
        }

        private Paragraph CreateParagraph(string content, float size) {
            BaseFont font = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,BaseFont.CP1252,false);
            return new Paragraph(content,new iTextSharp.text.Font(font,size));
        }
        
        private void CloseBtn_Click(object sender, EventArgs e) {
            Close();
        }
        
        
    }
}