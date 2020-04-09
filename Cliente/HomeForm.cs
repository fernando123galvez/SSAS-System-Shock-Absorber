﻿using Entities;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cliente
{
    public partial class HomeForm : Form
    {
        LoginForm loginForm = null;
        User currentUser = null;
        public HomeForm(LoginForm loginForm,User user)
        {
            this.loginForm = loginForm;
            this.currentUser = user;
            InitializeComponent();
            //this.labelClose.Text=$"Hola {user.Correo}";
            lblUserName.Text = user.Correo;
            lblRol.Text = user.rol.Descripcion;
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loginForm.Visible)
                loginForm.Close();
        }

        private void iconPictureBox1_Click(object sender, System.EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Compress;
            }else
            {
                this.WindowState = FormWindowState.Normal;
                this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Expand;
            }
        }

        private void labelClose_Click(object sender, System.EventArgs e)
        {
            if (!loginForm.Visible)
                Application.Exit();
            else
                this.Close();
        }

        private void iconPictureBox2_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf013, 0);
        }
    }
}
