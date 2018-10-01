using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projetinho
{
    public partial class frm2 : Form
    {
        public frm2()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=TIT0517634W10-1;Database=escola;Trusted_Connection=true";
                conn.Open();



                string insert = "INSERT INTO aluno (nome, email)";
                insert += " VALUES (@nome, @email)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");

                txtNome.Text = String.Empty;
                txtEmail.Text = String.Empty;
                conn.Close();

            }

            catch (Exception)
            {

                MessageBox.Show("Erro no Cadastro.");

            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
           
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
