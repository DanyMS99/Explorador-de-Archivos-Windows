using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {   //VARIABLES
        Computer compu = new Computer();//objeto de VisualBasic
        OpenFileDialog openFileD = new OpenFileDialog(); //abrir cuadro de dialogo
        FolderBrowserDialog folderBrowD = new FolderBrowserDialog(); //abrir carpetas de dialogo
        DriveInfo[] drivers = DriveInfo.GetDrives();//arreglo de dispositivos
        string path = "";//guardar url
        TextWriter archivo;//crear archivo
        string ext = ".txt";//extencion del archivo
        bool btn_archivo = false;
        bool btn_carpeta = false;


        public Form1()
        {
            InitializeComponent();
            DispositivosConectados();
          
        }

        public void DispositivosConectados()
        {
            foreach (DriveInfo d in drivers)
            {
                listBox1.Items.Add("\n");
                listBox1.Items.Add("Drive: " + d.Name);
                listBox1.Items.Add("  Drive type: " + d.DriveType);

                if (d.IsReady == true)
                {
                    listBox1.Items.Add("  Volume label: " + d.VolumeLabel);
                    listBox1.Items.Add("  File system: " + d.DriveFormat);
                    listBox1.Items.Add("  Available space to current user: " + d.AvailableFreeSpace + " bytes");
                    listBox1.Items.Add("  Total available space:           " + d.TotalFreeSpace + " bytes");
                    listBox1.Items.Add("  Total size of drive:             " + d.TotalSize + " bytes");
                }
            }
           
        }     

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox1.Size = new Size(337, 355);
            listBox1.Location = new Point(6, 19);
            listBox1.Visible = true;
            comboBox1.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            groupBox1.Text = "Dispositivos";
            textBox3.Visible = false;
            richTextBox1.Visible = false;
        }
        /*FIN DISPOSITIVOS
---------------------------------------------------------------------------------------------------------------------
        INICIO ARCHIVOS
         */

       
        private void button2_Click(object sender, EventArgs e)
        {   

            btn_archivo = true;
            btn_carpeta = false;
            listBox1.Visible = false;
            comboBox1.Visible = true;
            comboBox1.Text = "";
            label1.Visible = false;
            textBox1.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            groupBox1.Text = "Archivos";
            textBox3.Visible = true;
            textBox3.Text = "";
            richTextBox1.Visible = false;


        }

        /*FIN ARCHIVOS
---------------------------------------------------------------------------------------------------------------------
        INICIO CARPETAS
        */
        private void button1_Click(object sender, EventArgs e)
        {
            btn_carpeta = true;
            btn_archivo = false;
            listBox1.Visible = false;
            comboBox1.Visible = true;
            comboBox1.Text = "";
            label1.Visible = false;
            textBox1.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            groupBox1.Text = "Carpetas";
            textBox3.Visible = true;
            textBox3.Text = "";
            richTextBox1.Visible = false;



        }
        //VENTANA
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(btn_archivo == true)
            {
                if (comboBox1.SelectedIndex == 0)//Nuevo 1
                {
                    listBox1.Visible = false;
                    comboBox1.Visible = true;
                    label1.Visible = true;
                    label1.Text = "Seleccione la ruta";
                    textBox1.Visible = true;
                    textBox1.Text = "/";
                    textBox1.Location = new Point(22, 103);
                    button4.Visible = true;
                    button4.Location = new Point(312, 100);
                    label2.Visible = false;
                    textBox2.Visible = false;
                    button5.Visible = false;
                    button6.Location = new Point(125, 295);
                    button6.Visible = true;
                    textBox3.Text = "";
                    richTextBox1.Visible = true;
                }
                else
                {
                    if (comboBox1.SelectedIndex == 1)//copiar 2
                    {
                        textBox1.Text = "/";
                        textBox2.Text = "/";
                        listBox1.Visible = false;
                        comboBox1.Visible = true;
                        label1.Visible = true;
                        label1.Text = "Seleccione la ruta de origen";
                        textBox1.Visible = true;
                        button4.Visible = true;
                        label2.Visible = true;
                        label2.Location = new Point(22, 150);
                        label2.Text = "Seleccione la ruta de destino";
                        textBox2.Visible = true;
                        textBox2.Location = new Point(22, 168);
                        button5.Visible = true;
                        button5.Location = new Point(312, 166);
                        button6.Visible = true;
                        button6.Location = new Point(133, 214);
                        textBox3.Text = "";
                        richTextBox1.Visible = false;
                    }

                    else
                    {
                        if (comboBox1.SelectedIndex == 2)//Cambiar nombre 1
                        {
                            textBox1.Text = "/";
                            textBox2.Text = "/";
                            listBox1.Visible = false;
                            comboBox1.Visible = true;
                            label1.Visible = true;
                            label1.Text = "Seleccione la ruta";
                            textBox1.Visible = true;
                            button4.Visible = true;
                            label2.Visible = false;
                            textBox2.Visible = false;
                            textBox2.Location = new Point(22, 168);
                            button5.Visible = false;
                            button6.Location = new Point(124, 142);
                            button6.Visible = true;
                            textBox3.Text = "";
                            richTextBox1.Visible = false;
                            richTextBox1.Text= "";
                        }

                        else
                        {
                            if (comboBox1.SelectedIndex == 3)//Mover 2
                            {
                                textBox1.Text = "/";
                                textBox2.Text = "/";
                                listBox1.Visible = false;
                                comboBox1.Visible = true;
                                label1.Visible = true;
                                label1.Text = "Seleccione la ruta de origen";
                                textBox1.Visible = true;
                                button4.Visible = true;
                                label2.Visible = true;
                                label2.Text = "Seleccione la ruta de destino";
                                textBox2.Visible = true;
                                textBox2.Location = new Point(22, 168);
                                button5.Visible = true;
                                button5.Location = new Point(312, 166);
                                button6.Visible = true;
                                button6.Location = new Point(121, 210);
                                button6.Visible = true;
                                textBox3.Text = "";
                                richTextBox1.Visible = false;
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 4)//eliminar 1
                                {
                                    textBox1.Text = "/";
                                    textBox2.Text = "/";
                                    listBox1.Visible = false;
                                    comboBox1.Visible = true;
                                    label1.Visible = true;
                                    label1.Text = "Seleccione la ruta";
                                    textBox1.Visible = true;
                                    label2.Visible = false;
                                    button4.Visible = true;
                                    textBox2.Visible = false;
                                    button5.Visible = false;
                                    button6.Location = new Point(124, 142);
                                    button6.Visible = true;
                                    textBox3.Text = "";
                                    richTextBox1.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (btn_carpeta == true)
                {
                    if (comboBox1.SelectedIndex == 0)//Nuevo 1
                    {
                        listBox1.Visible = false;
                        comboBox1.Visible = true;
                        label1.Visible = true;
                        label1.Text = "Seleccione la ruta";
                        textBox1.Visible = true;
                        textBox1.Text = "/";
                        textBox1.Location = new Point(22, 103);
                        button4.Visible = true;
                        button4.Location = new Point(312, 100);
                        label2.Visible = false;
                        textBox2.Visible = false;
                        button5.Visible = false;
                        button6.Location = new Point(124, 142);
                        button6.Visible = true;
                        textBox3.Text = "";
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 1)//copiar 2
                        {
                            textBox1.Text = "/";
                            textBox2.Text = "/";
                            listBox1.Visible = false;
                            comboBox1.Visible = true;
                            label1.Visible = true;
                            label1.Text = "Seleccione la ruta de origen";
                            textBox1.Visible = true;
                            button4.Visible = true;
                            label2.Visible = true;
                            label2.Location = new Point(22, 150);
                            label2.Text = "Seleccione la ruta de destino";
                            textBox2.Visible = true;
                            textBox2.Location = new Point(22, 168);
                            button5.Visible = true;
                            button5.Location = new Point(312, 166);
                            button6.Visible = true;
                            button6.Location = new Point(133, 214);
                            textBox3.Text = "";
                        }

                        else
                        {
                            if (comboBox1.SelectedIndex == 2)//Cambiar nombre 1
                            {
                                textBox1.Text = "/";
                                textBox2.Text = "/";
                                listBox1.Visible = false;
                                comboBox1.Visible = true;
                                label1.Visible = true;
                                label1.Text = "Seleccione la ruta";
                                textBox1.Visible = true;
                                button4.Visible = true;
                                label2.Visible = false;
                                textBox2.Visible = false;
                                textBox2.Location = new Point(22, 168);
                                button5.Visible = false;
                                button6.Location = new Point(124, 142);
                                button6.Visible = true;
                                textBox3.Text = "";
                            }

                            else
                            {
                                if (comboBox1.SelectedIndex == 3)//Mover 2
                                {
                                    textBox1.Text = "/";
                                    textBox2.Text = "/";
                                    listBox1.Visible = false;
                                    comboBox1.Visible = true;
                                    label1.Visible = true;
                                    label1.Text = "Seleccione la ruta de origen";
                                    textBox1.Visible = true;
                                    button4.Visible = true;
                                    label2.Visible = true;
                                    label2.Text = "Seleccione la ruta de destino";
                                    textBox2.Visible = true;
                                    textBox2.Location = new Point(22, 168);
                                    button5.Visible = true;
                                    button5.Location = new Point(312, 166);
                                    button6.Visible = true;
                                    button6.Location = new Point(121, 210);
                                    button6.Visible = true;
                                    textBox3.Text = "";
                                }
                                else
                                {
                                    if (comboBox1.SelectedIndex == 4)//eliminar 1
                                    {
                                        textBox1.Text = "/";
                                        textBox2.Text = "/";
                                        listBox1.Visible = false;
                                        comboBox1.Visible = true;
                                        label1.Visible = true;
                                        label1.Text = "Seleccione la ruta";
                                        textBox1.Visible = true;
                                        label2.Visible = false;
                                        button4.Visible = true;
                                        textBox2.Visible = false;
                                        button5.Visible = false;
                                        button6.Location = new Point(124, 142);
                                        button6.Visible = true;
                                        textBox3.Text = "";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
        /*FIN CARPETAS
---------------------------------------------------------------------------------------------------------------------
        INICIO Btn URL
        */
        private void button4_Click(object sender, EventArgs e)
        {
            if (btn_carpeta == true)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    seleccionarPath();
                    textBox3.Text = path;
                }
                else
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        seleccionarPath();
                        textBox1.Text = path;
                        textBox3.Text = path;
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 2)
                        {
                            seleccionarPath();
                            textBox3.Text = path;
                        }
                        else
                        {
                            if (comboBox1.SelectedIndex == 3)
                            {
                                seleccionarPath();
                                textBox1.Text = path;
                                textBox3.Text = path;
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 4)
                                {
                                    seleccionarPath();
                                    textBox1.Text = path;
                                    textBox3.Text = path;
                                }
                            }
                        }
                    }
                }
               
            }
            else
            {
                if (btn_archivo== true)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        seleccionarPath();
                        textBox3.Text = path;
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 1)
                        {
                            origenArchivo(textBox1);
                            textBox3.Text = path;
                        }
                        else
                        {
                            if (comboBox1.SelectedIndex == 2)
                            {
                                origenArchivo(textBox1);
                                textBox1.Text = "/";
                                textBox3.Text = path;
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 3)
                                {
                                    origenArchivo(textBox1);
                                    
                                    textBox3.Text = path;
                                }
                                else
                                {
                                    if (comboBox1.SelectedIndex == 4)
                                    {
                                        origenArchivo(textBox1);
                                        textBox3.Text = path;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        //-------------------------------------------------------------------------------------------------------

        private void button5_Click(object sender, EventArgs e)
        {
            if (btn_carpeta == true)
            {
                destinoCarpeta(textBox2, textBox1);
            }
            else
            {
                if (btn_archivo == true)
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        destinoArchivo(textBox2, textBox1);
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 2)
                        {
                            destinoArchivo(textBox2, textBox1);
                        }
                        else
                        {
                            if (comboBox1.SelectedIndex == 3)
                            {
                                destinoArchivo(textBox2, textBox1);
                            }
                        }
                    }
                }
            }
        }
    
        //---------------------------------------------------------URL--------------------------------------------
        public void seleccionarPath()
        {
            //Funcion para que nos de la ruta que deseamos
            var resultado = folderBrowD.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                path = folderBrowD.SelectedPath;
            }
        }
       // -------------------------------------------------

        public void origenArchivo(TextBox txtOrigenArchivo)
        {
            //Funcion que nos da la ruta del archivo
            var resultado = openFileD.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                txtOrigenArchivo.Text = openFileD.FileName;
                path = txtOrigenArchivo.Text;
            }
        }//-----------------------------------------------------

        public void destinoArchivo(TextBox txtDestinoArchivo, TextBox txtOrigenArchivo)
        {
            //Funcion que nos da la ruta del archivo
            var resultado = folderBrowD.ShowDialog();
            if (resultado == DialogResult.OK)
                txtDestinoArchivo.Text = folderBrowD.SelectedPath + txtOrigenArchivo.Text.Substring(txtOrigenArchivo.Text.LastIndexOf(@"\"));
        }
        //------------------------------------------------------------

        public void destinoCarpeta(TextBox txtDestino, TextBox txtOrigen)
        {
            //Funcion que nos da la ruta de la carpeta que queremos como destino
            var resultado = folderBrowD.ShowDialog();
            if (resultado == DialogResult.OK)
                txtDestino.Text = folderBrowD.SelectedPath + txtOrigen.Text.Substring(txtOrigen.Text.LastIndexOf(@"\"));
        }//

        /*
-----------------------------------------------------------------------------------------------------------------------
        bnt EJECUTAR
         */

        private void button6_Click(object sender, EventArgs e)
        {
            if(btn_carpeta == true)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox1.Visible = true;
                    button4.Visible = true;
                    
                    string newCarpeta = textBox1.Text;
                    string creacionCarpeta = path + newCarpeta;

                    if (!Directory.Exists(creacionCarpeta))
                    {
                        Directory.CreateDirectory(creacionCarpeta);
                        MessageBox.Show("Se a creado una nueva Carpeta");
                    }
                }
                else
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        compu.FileSystem.CopyDirectory(textBox1.Text, textBox2.Text);
                        MessageBox.Show("La carpeta ha sido copiada");
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 2)
                        {
                            string newName = textBox1.Text;
                            FileInfo fi = new FileInfo(path);
                            var ruta = fi.Directory;
                            var newRuta = ruta + newName;
                            Directory.Move(path, newRuta);
                            MessageBox.Show("El nombre de la carpeta ha sido cambiado");
                        }
                        else
                        {
                            if (comboBox1.SelectedIndex == 3)
                            {

                                compu.FileSystem.MoveDirectory(textBox1.Text, textBox2.Text);
                            MessageBox.Show("La carpeta ha sido movida");
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 4)
                                {
                                    Directory.Delete(path);
                                    MessageBox.Show("La carpeta ha sido eliminada");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (btn_archivo == true)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        string nombreArchivo = textBox1.Text;
                        string mensaje = richTextBox1.Text;
                        string newArchivo = path + nombreArchivo + ext;
                        archivo = new StreamWriter(newArchivo);
                        archivo.WriteLine(mensaje);
                        archivo.Close();
                        MessageBox.Show("Se a creado un archivo");
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 1)
                        {
                            compu.FileSystem.CopyFile(textBox1.Text, textBox2.Text);
                            MessageBox.Show("El archivo ha sido copiado");
                        }
                        else
                        {
                            if (comboBox1.SelectedIndex == 2)
                            {
                                string newName = textBox1.Text;
                                FileInfo fi = new FileInfo(path);
                                //var nombre = fi.Name;
                                var ruta = fi.Directory;
                                var newRuta = ruta + newName + ext;
                                File.Move(path, newRuta);
                                MessageBox.Show("El nombre del archivo a sido cambiado");
                            }
                            else
                            {
                                if (comboBox1.SelectedIndex == 3)
                                {
                                    compu.FileSystem.MoveFile(textBox1.Text, textBox2.Text);
                                    MessageBox.Show("El archivo a sido movido");
                                }
                                else
                                {
                                    if (comboBox1.SelectedIndex == 4)
                                    {
                                        File.Delete(path);
                                        MessageBox.Show("El archivo ha sido borrado");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";

        }



    }
}


