using System;
using System.Drawing; // ใช้สำหรับ Brushes และ Font
using System.Drawing.Printing; // ใช้สำหรับ PrintDocument และการพิมพ์

namespace QMS.Services
{
    public class ThermalPrinter
    {
        public void PrintQueueTicket(string queueNumber, string queueType, string queueDate)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) => PrintPageHandler(sender, e, queueNumber, queueType, queueDate);
            printDocument.PrinterSettings.PrinterName = "POS-80";  // ระบุชื่อเครื่องพิมพ์ที่ใช้งาน
            printDocument.Print();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e, string queueNumber, string queueType, string queueDate)
        {
            string receiptText = $"หมายเลขคิว: {queueNumber}\n" +
                                 $"รายการที่เลือก: {queueType}\n" +
                                 $"วันที่และเวลา: {queueDate}\n" +
                                 "*ถ้าเรียกคิวแล้วไม่อยู่ทำรายการ ขอสงวนสิทธิ์ในการข้ามคิว*";

            Font font = new Font("Arial", 10);
            e.Graphics.DrawString(receiptText, font, Brushes.Black, new PointF(10, 10));
        }
    }
}
