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
    public partial class frm3 : Form
    {
        public frm3()
        {
            InitializeComponent();
        }

        private void alunoID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLancar_Click(object sender, EventArgs e)
        {
            try

            {

                double n1Calculada = 0;
                double n2Calculada = 0;
                double resultado = 0;
                double a = Convert.ToDouble(nota1.Text);
                double b = Convert.ToDouble(nota2.Text);
                int idAluno2;


                if (int.TryParse(alunoID.Text, out idAluno2))
                {

                    int idAluno = int.Parse(alunoID.Text);

                }
                else
                {

                    MessageBox.Show("Digite um ID válido.");
                }


                n1Calculada = a * 0.3;
                n2Calculada = b * 0.7;
                resultado = n1Calculada + n2Calculada;
                txtResultado.Text = resultado.ToString();


                if (resultado >= 4 && resultado < 7)
                {

                    lblMedia.Text = "Aluno de Exame";

                }
                else if (resultado < 4)
                {

                    lblMedia.Text = "Aluno Reprovado";

                }
                else
                {

                    lblMedia.Text = "Aluno Aprovado";

                }


                if (lblMedia.Visible == false)

                {
                    lblMedia.Show();
                }



                try
                {


                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "Server=TIT0517634W10-1;Database=escola;Trusted_Connection=true";
                    conn.Open();

                    string insert = "INSERT INTO nota(idAlunoFK, notaContinuada, notaRegimental)";
                    insert += "VALUES (@idAlunoFK, @notaContinuada, @notaRegimental)";
                    SqlCommand cmd = new SqlCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@idAlunoFK", alunoID.Text);
                    cmd.Parameters.AddWithValue("@notaContinuada", nota1.Text);
                    cmd.Parameters.AddWithValue("@notaRegimental", nota2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Notas lançadas no sistema!");

                    conn.Close();
                    alunoID.Text = String.Empty;
                    nota1.Text = String.Empty;
                    nota2.Text = String.Empty;

                }

                catch (Exception)
                {

                    MessageBox.Show("Erro ao inserir dados, Digite um ID válido.");

                }




                /*https://www.c-sharpcorner.com/article/login-form-in-c-sharp-connected-with-database-for/
                 https://www.c-sharpcorner.com/UploadFile/18585c/insert-data-in-sql-server-from-front-end-by-using-windows-ap/
                 https://www.c-sharpcorner.com/UploadFile/009464/insert-data-into-database-in-window-form-using-C-Sharp/
                 quem pesquisa aprende xD */

            }

            catch
            {
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            nota1.Text = String.Empty;
            nota2.Text = String.Empty;
            txtResultado.Text = String.Empty;
            lblMedia.Text = String.Empty;
            alunoID.Text = String.Empty;

            if (lblMedia.Visible == true)

            {
                lblMedia.Hide();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
