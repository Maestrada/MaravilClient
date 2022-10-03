using BAL.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using RawPrint.NetStd;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MaravilClient
{
    public partial class PrintQeue : Form
    {
        public List<Client> listClient;
        readonly string templatePath = "templatePDF//maraviltemplate.pdf";
        public string pathPDFCompleto = string.Empty;
        public PrintQeue(List<Client> clients)
        {
            InitializeComponent();
            listClient = clients;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string oldFile = "templatePDF//maraviltemplate.pdf";
            string newFile = $"templatePDF//maraviltemplate{Guid.NewGuid()}.pdf";

            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
            iTextSharp.text.Document document = new iTextSharp.text.Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            foreach (Client client in listClient)
            {
                //// the pdf content
                PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 11f);
                arial.Color = BaseColor.Black;
                Chunk nameText = new Chunk("\n\n\n\nNombre:  ");
                nameText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.2f, null);
                Chunk clientName = new Chunk( client.Name + " " + client.LastName, arial);
                Chunk phoneText = new Chunk("\n Telefono(s):  ");
                phoneText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.2f, null);
                Chunk phone = new Chunk( client.CellPhone + (string.IsNullOrEmpty(client.CellPhone2) ? "" : " / " + client.CellPhone2), arial);
                Chunk addressText = new Chunk("\nDireccion:  ");
                addressText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.2f, null);
                Chunk adddres = new Chunk( client.Address, arial);
                Chunk referenceText = new Chunk("\nReferencia:  ");
                referenceText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.2f, null);
                Chunk reference = new Chunk(client.Reference, arial);
                Phrase phraseClientName = new Phrase();
                phraseClientName.Add(nameText);
                phraseClientName.Add(clientName);
                phraseClientName.Add(phoneText);
                phraseClientName.Add(phone);
                phraseClientName.Add(addressText);
                phraseClientName.Add(adddres);
                phraseClientName.Add(referenceText);
                phraseClientName.Add(reference);
                Paragraph paragraphClientName = new Paragraph();
                paragraphClientName.Add(phraseClientName);
                document.Add(paragraphClientName);

                PdfImportedPage page = writer.GetImportedPage(reader, 1);
                cb.AddTemplate(page, 0, 0);
                // create the new page and add it to the pdf
                document.NewPage();
            }
            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
            IPrinter printer = new Printer();
            // Priting the file
            printer.PrintRawFile("Microsoft Print to PDF", newFile);

            //deleting the file after 5 seconds
            Thread.Sleep(5000);
            File.Delete(newFile);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            listClient.Clear();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                listClient.Add(new Client
                {
                    Id = (int)item.Cells[0].Value,
                    Name = item.Cells[1].Value as string,
                    LastName = item.Cells[2].Value as string,
                    CellPhone = item.Cells[3].Value as string,
                    Address = item.Cells[4].Value as string,
                    Reference = item.Cells[5].Value as string,
                });
            }
        }

        private void PrintQeue_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (Client client in listClient)
            {
                dataGridView1.Rows.Add(client.Id, client.Name, client.LastName, client.CellPhone, client.Address,client.Reference);
            }
        }

        private void btnDeleteFromQeue_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
    }
}
