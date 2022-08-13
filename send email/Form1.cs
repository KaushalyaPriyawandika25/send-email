using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;


namespace send_email
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mm = new MailMessage("kaushipriya04@gmail.com", textBox1.Text);
            mm.Subject = textBox2.Text;
            mm.Body = textBox3.Text;
            foreach(string filename in openFileDialog1.FileNames)
            {
                if(File.Exists(filename))
                {
                    string fname = Path.GetFileName(filename);
                    mm.Attachments.Add(new Attachment(filename));

                }
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new NetworkCredential("kaushipriya04@gmail.com", "hgagcjmrdzjkaoab");
            smtp.EnableSsl = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            label4.Text = "Mail Has Been Sent Successfully " + textBox1.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (string filename in openFileDialog1.FileNames)
            {
                MessageBox.Show(filename);
                label5.Text = filename.ToString();
            }
        }
    }
}