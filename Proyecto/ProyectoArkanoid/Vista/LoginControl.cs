﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoArkanoid.Controladores;

namespace ProyectoArkanoid.Vista
{
    
    public partial class LoginControl : UserControl
    {
        private Usuario u;
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tb_usuarios.Text.Equals(""))
            {
                MessageBox.Show("No has ingresado tu nickname");
            }
            else
            {
                try
                {
                    var dt = ConexionDB.ExecuteQuery("SELECT * FROM PLAYER" +
                        $" WHERE nickname = '{tb_usuarios.Text}'");

                    if (dt.Rows.Count > 0)
                    {

                        var dataUsuario = dt.Rows[0];

                        u = new Usuario(dataUsuario[0].ToString());

                    }
                    //Hide();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
    }
}
