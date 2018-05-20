using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using crcCalc.Algorithms;

namespace crcCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool convertInputStringToByteArray(string str, ref byte[] arr)
        {
            string inp_hex_str = str.Replace(" ", String.Empty).Replace("-", String.Empty);
            try
            {
                if (inp_hex_str.Length % 2 != 0 || inp_hex_str == "") return false;

                byte[] tmpArr = new byte[inp_hex_str.Length / 2];

                for (int i = 0; i < inp_hex_str.Length; i += 2)
                    tmpArr[i / 2] = Convert.ToByte(inp_hex_str.Substring(i, 2), 16);

                arr = tmpArr;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            IAlgorithms algorithm = null;
            string algName = b.Tag.ToString();

            switch (algName)
            {
                case "crc8ElfApator":
                    {
                        algorithm = new crc8ElfApator();
                        break;
                    }
                case "crc8Teplouchet":
                    {
                        algorithm = new crc8Teplouchet();
                        break;
                    }
                case "crc16Modbus":
                    {
                        algorithm = new crc16ModBus();
                        break;
                    }
                default :
                    {
                        MessageBox.Show("Алгоритма с названием '" + algName + "' нет");
                        return;
                    }
            }
            

            byte[] inputArr = null;
            byte[] crcArr = null;

            if (convertInputStringToByteArray(richTextBox1.Text, ref inputArr))
            {
                algorithm.GetCRCBytes(inputArr, ref crcArr);

                if (crcArr != null)
                {
                    string crcStr = BitConverter.ToString(crcArr).Replace("-", " ").ToLower();
                    textBox1.Text = crcStr;
                }
            }
            else
            {
                MessageBox.Show("Не удается преобразовать входную строку в массив байт");
            }

        }
    }
}
