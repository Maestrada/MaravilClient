using BAL.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using RawPrint.NetStd;
using Services.OrderActions;
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
        public List<Order> listOrders;
        private readonly IOrderActions orderActionsGlobal;
        readonly string templatePath = "templatePDF//maraviltemplate.pdf";
        public string pathPDFCompleto = string.Empty;
        public PrintQeue(List<Order> orders, IOrderActions orderActions)
        {
            InitializeComponent();
            orderActionsGlobal = orderActions;
            listOrders =    orderActionsGlobal.GetOrdersByListIds( orders.Select(x=>x.Id).ToList());
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
            foreach (Order order in listOrders)
            {
                //// the pdf content
                PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 10f);
                arial.Color = BaseColor.Black;
                Chunk nameText = new Chunk("\n\n\nNombre:  ");
                nameText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.1f, null);
                Chunk clientName = new Chunk(order.Client.Name + " " + order.Client.LastName, arial);
                Chunk phoneText = new Chunk("\n Telefono(s):  ");
                phoneText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.1f, null);
                Chunk phone = new Chunk(order.Client.CellPhone + (string.IsNullOrEmpty(order.Client.CellPhone2) ? "" : " / " + order.Client.CellPhone2), arial);
                Chunk addressText = new Chunk("\nDireccion:  ");
                addressText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.1f, null);
                Chunk adddres = new Chunk(order.Client.Address, arial);
                Chunk referenceText = new Chunk("\nReferencia:  ");
                referenceText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.1f, null);
                Chunk reference = new Chunk(order.Client.Reference, arial);
                Chunk orderDescText = new Chunk("\nDescripcion:  ");
                orderDescText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.1f, null);
                Chunk orderDesc= new Chunk(order.Description, arial);
                Chunk orderIdText = new Chunk("\nNo de pedido:  "); 
                orderIdText.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 0.1f, null);
                Chunk orderId = new Chunk(order.Id.ToString(), arial);
                Phrase phraseClientName = new Phrase();
                phraseClientName.Add(nameText);
                phraseClientName.Add(clientName);
                phraseClientName.Add(phoneText);
                phraseClientName.Add(phone);
                phraseClientName.Add(addressText);
                phraseClientName.Add(adddres);
                phraseClientName.Add(referenceText);
                phraseClientName.Add(reference);
                phraseClientName.Add(orderDescText);
                phraseClientName.Add(orderDesc);
                phraseClientName.Add(orderIdText);
                phraseClientName.Add(orderId);
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
            listOrders.Clear();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                listOrders.Add(new Order
                {
                    Id = (Int64)item.Cells[0].Value,
                    Client = new Client
                    {
                        Name = item.Cells[1].Value as string,
                        LastName = item.Cells[2].Value as string,
                        CellPhone = item.Cells[3].Value as string,
                        Address = item.Cells[4].Value as string,
                        Reference = item.Cells[5].Value as string
                    }
                });
            }
        }

        private void PrintQeue_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (Order order in listOrders)
            {
                dataGridView1.Rows.Add(order.Id, order.Client.Name +" "+ order.Client.LastName,order.Description, order.Client.CellPhone, order.Client.Address, order.Client.Reference);
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
