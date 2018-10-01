using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projetinho
{


    public partial class frmEscola : Form
    {

      


        public frmEscola()
        {
            InitializeComponent();

                

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
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

        private void n1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try

            {

                double n1Calculada = 0;
                double n2Calculada = 0;
                double resultado = 0;
                double a = Convert.ToDouble(nota1.Text);
                double b = Convert.ToDouble(nota2.Text);
                int idAluno2;

                if (int.TryParse(alunoID.Text, out idAluno2)) {

                    int idAluno = int.Parse(alunoID.Text);

                } else {

                    MessageBox.Show("Digite um ID válido.");
                }


                n1Calculada = a * 0.3;
                n2Calculada = b * 0.7;
                resultado = n1Calculada + n2Calculada;
                txtResultado.Text = resultado.ToString();

                lblMedia.Text = "Aluno Reprovado";

                if (resultado >= 4 && resultado < 7)
                {

                    lblMedia.Text = "Aluno de Exame";

                } else if (resultado >=7) {

                    lblMedia.Text = "Aluno Aprovado";

                }

                if (lblMedia.Visible == false)

                {
                    lblMedia.Show();
                }

                

                try {


                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "Server=TIT0517634W10-1;Database=escola;Trusted_Connection=true";
                    conn.Open();

                    string insert = "INSERT INTO nota(idAlunoFK, notaContinuada, notaRegimental)";
                    insert += "VALUES (@idAlunoFK, @notaContinuada, @notaRegimental)";
                    SqlCommand insertObject = new SqlCommand(insert, conn);
                    insertObject.Parameters.AddWithValue("@idAlunoFK", alunoID.Text);
                    insertObject.Parameters.AddWithValue("@notaContinuada", nota1.Text);
                    insertObject.Parameters.AddWithValue("@notaRegimental", nota2.Text);
                    insertObject.ExecuteNonQuery();
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

        private void nota2_TextChanged(object sender, EventArgs e)
        {

        }

        private void idAluno_TextChanged(object sender, EventArgs e)
        {
            
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

            catch(Exception) {

                MessageBox.Show("Erro no Cadastro.");
                        
            }


        }

        private void frmEscola_Load(object sender, EventArgs e)
        {
            
        }
    }
}
