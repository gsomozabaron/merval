using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace merval
{
    public class GeneradorDePDF
    {
        public void GeneratePDFReport(string filePath)
        {
            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);
                    document.Add(new Paragraph("Contenido del informe PDF"));

                    // Aquí puedes agregar más contenido según tus necesidades
                }
            }
        }

        /*
        var pdfGenerator = new PdfReportGenerator();
        pdfGenerator.GeneratePDFReport("ruta_del_archivo.pdf");
        */

        /*
         private void btnGenerarPDF_Click(object sender, EventArgs e)
    {
        // Instanciar el generador de informes PDF
        var pdfGenerator = new PdfReportGenerator();

        // Especificar la ruta del archivo PDF
        string filePath = "ruta_del_archivo.pdf";

        // Generar el informe PDF
        pdfGenerator.GeneratePDFReport(filePath);

        MessageBox.Show("Informe PDF generado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
         */
    }
}
