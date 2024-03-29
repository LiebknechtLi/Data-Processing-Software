using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_9._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int pos = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "请选择文件夹";
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            string file;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            {
                file = openFileDialog1.FileName.ToString();
                //MessageBox.Show(file);
                richTextBox1.LoadFile(file, RichTextBoxStreamType.PlainText);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Focus();//光标注入
            string sl = richTextBox1.Text.Trim();
            pos = sl.IndexOf(textBox1.Text.ToString(), pos);

            if (pos == -1)
            {
                MessageBox.Show("无更多匹配内容");
            }
            else
            {
                MessageBox.Show(pos.ToString());//在字符串的第几个字
                richTextBox1.SelectionStart = pos;
                richTextBox1.SelectionLength = textBox1.Text.ToString().Length;
                pos += textBox1.Text.ToString().Length;//蓝色光标选择字符
                pos += 1;//结束查找，下一个
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = 0;
            string text = textBox1.Text;
            string str = richTextBox1.Text;
            int pos = 0;
            while (true)
            {
                pos = str.IndexOf(text, pos);

                if (pos == -1)
                    break;

                num++;

                richTextBox1.SelectionStart = pos;
                richTextBox1.SelectionLength = text.Length;

                pos += text.Length;
            }

            MessageBox.Show("一共有:" + num + "个匹配词");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num = 0;
            string text = textBox1.Text;
            string str = richTextBox1.Text;

            int pos = 0;
            while (true)
            {
                
                pos = str.IndexOf(text, pos);

                if (pos == -1)
                    break;

                num++;

                richTextBox1.SelectionStart = pos;
                richTextBox1.SelectionLength = text.Length;

                pos += text.Length;
                
            }
            double rate = (double)num / richTextBox1.Text.Length * 100;
            MessageBox.Show("总体词频为" + rate + "%");
        }
    }
    
}
