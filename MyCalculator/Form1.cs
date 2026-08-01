using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace DbLabAssignment
{
    public partial class Form1 : Form
    {
        double num1, num2, result;
        string operation, table_name, table_id, new_operand1, new_operand2;
        string ConnectionString = "Data Source=HP\\SQLEXPRESS;Initial Catalog=mycalculator;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void operands(object sender, EventArgs e)
        {
            Button value = (Button)sender;

            if (textBox1.Text == "0")
            {

                if (value.Text == ".")
                {

                    if (!textBox1.Text.Contains("."))
                    {
                        textBox1.Text = textBox1.Text + value.Text;
                        label1.Text = label1.Text + value.Text;
                    }
                }


            }
            else
            {
                textBox1.Text = textBox1.Text + value.Text;
                label1.Text = label1.Text + value.Text;
            }

        }

        private void Operations(object sender, EventArgs e)
        {
            Button value = (Button)sender;
            num1 = double.Parse(textBox1.Text);
            operation = value.Text;
            if(label1.Text!=" ")
            {
                label1.Text = label1.Text + " ";
                label1.Text = label1.Text + value.Text;
            }
            else
            {
                label1.Text = label1.Text + value.Text;
            }
            textBox1.Text = "";

        }

        private void answer(object sender, EventArgs e)
        {
            num2 = double.Parse(textBox1.Text);
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            if (operation == "+")
            {
                result = num1 + num2;
                textBox1.Text = result.ToString();
                label1.Text = label1.Text + "=";
                label1.Text = label1.Text + textBox1.Text;
                string query = "insert into Addition (Operand1 , Operand2 , Result) values ('" + num1 + "' , '" + num2 + "' , '" + result + "')";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully inserted");
                string query1 = "Select * from Addition";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (operation == "-")
            {
                result = num1 - num2;
                textBox1.Text = result.ToString();
                label1.Text = label1.Text + "=";
                label1.Text = label1.Text + textBox1.Text;
                string query = "insert into Subtraction (Operand1 , Operand2 , Result) values ('" + num1 + "' , '" + num2 + "' , '" + result + "')";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully inserted");
                string query1 = "Select * from Subtraction";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (operation == "*")
            {
                result = num1 * num2;
                textBox1.Text = result.ToString();
                label1.Text = label1.Text + "=";
                label1.Text = label1.Text + textBox1.Text;
                string query = "insert into Multiplication (Operand1 , Operand2 , Result) values ('" + num1 + "' , '" + num2 + "' , '" + result + "')";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully inserted");
                string query1 = "Select * from Multiplication";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (operation == "/")
            {
                result = num1 / num2;
                textBox1.Text = result.ToString();
                label1.Text = label1.Text + "=";
                label1.Text = label1.Text + textBox1.Text;
                string query = "insert into Division (Operand1 , Operand2 , Result) values ('" + num1 + "' , '" + num2 + "' , '" + result + "')";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully inserted");
                string query1 = "Select * from Division";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;


            }
        }

        private void back_space(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);

            }

            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "";

            }
        }

        private void clear(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            result = Math.Sqrt(num1);
            operation = "sqrt";
            textBox1.Text = result.ToString();
            label1.Text = label1.Text + "=";
            label1.Text = label1.Text + textBox1.Text;
            string query = "insert into SquareRoot (Operand , Result) values ('" + num1 + "' , '" + result + "')";
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Values successfully inserted");
            string query1 = "Select * from SquareRoot";
            SqlCommand cmd1 = new SqlCommand(query1, sql);
            SqlDataAdapter data = new SqlDataAdapter(cmd1);
            DataTable datatable = new DataTable();
            data.Fill(datatable);
            dataGridView1.DataSource = datatable;

        }

        private void button20_Click(object sender, EventArgs e)
        {

            num1 = Convert.ToDouble(textBox1.Text);
            result = num1 * num1;
            operation = "sqr";
            textBox1.Text = result.ToString();
            label1.Text = label1.Text + "=";
            label1.Text = label1.Text + textBox1.Text;
            string query = "insert into Sqr (Operand , Result) values ('" + num1 + "' , '" + result + "')";
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Values successfully inserted");
            string query1 = "Select * from Sqr";
            SqlCommand cmd1 = new SqlCommand(query1, sql);
            SqlDataAdapter data = new SqlDataAdapter(cmd1);
            DataTable datatable = new DataTable();
            data.Fill(datatable);
            dataGridView1.DataSource = datatable;
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {


        }

        private void button22_Click_1(object sender, EventArgs e)
        {


        }

        private void button22_Click_2(object sender, EventArgs e)
        {
            table_name = tablename.Text;
            table_id = tableID.Text;
            new_operand1 = newoperand1.Text;
            new_operand2 = newoperand2.Text;
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            if (table_name == "Addition" || table_name == "addition" || table_name == "+")
            {
                if (new_operand1 != "" && new_operand2 == "")
                {

                    string query = "update Addition set Operand1 = '" + new_operand1 + "' , Result = '" + double.Parse(new_operand1) + "' + Operand2  where AdditionID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Addition";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 == "" && new_operand2 != "")
                {
                    string query = "update Addition set Operand2 = '" + new_operand2 + "' , Result =  Operand1 + '" + double.Parse(new_operand2) + "'   where AdditionID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Addition";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 != "" && new_operand2 != "")
                {
                    double x, y, z;
                    x = double.Parse(new_operand1);
                    y = double.Parse(new_operand2);
                    z = x + y;
                    string query = "update Addition set Operand1 = '" + new_operand1 + "' , Operand2 = '" + new_operand2 + "' , Result =  '" + z + "'   where AdditionID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Addition";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }

            }
            else if (table_name == "Subtraction" || table_name == "subtraction" || table_name == "-")
            {
                if (new_operand1 != "" && new_operand2 == "")
                {

                    string query = "update Subtraction set Operand1 = '" + new_operand1 + "' , Result = '" + double.Parse(new_operand1) + "' - Operand2  where SubtractionID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Subtraction";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 == "" && new_operand2 != "")
                {
                    string query = "update Subtraction set Operand2 = '" + new_operand2 + "' , Result =  Operand1 - '" + double.Parse(new_operand2) + "'   where SubtractionID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Subtraction";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 != "" && new_operand2 != "")
                {
                    double x, y, z;
                    x = double.Parse(new_operand1);
                    y = double.Parse(new_operand2);
                    z = x - y;
                    string query = "update Subtraction set Operand1 = '" + new_operand1 + "' , Operand2 = '" + new_operand2 + "' , Result = '" + z + "'   where SubtractionID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Subtraction";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
            }
            else if (table_name == "Multiplication" || table_name == "multiplication" || table_name == "x" || table_name == "*")
            {
                if (new_operand1 != "" && new_operand2 == "")
                {

                    string query = "update Multiplication set Operand1 = '" + new_operand1 + "' , Result = '" + double.Parse(new_operand1) + "' * Operand2  where MultiplicationID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Multiplication";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 == "" && new_operand2 != "")
                {
                    string query = "update Multiplication set Operand2 = '" + new_operand2 + "' , Result =  Operand1 * '" + double.Parse(new_operand2) + "'   where MultiplicationID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Multiplication";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 != "" && new_operand2 != "")
                {
                    double x, y, z;
                    x = double.Parse(new_operand1);
                    y = double.Parse(new_operand2);
                    z = x * y;
                    string query = "update Multiplication set Operand1 = '" + new_operand1 + "' , Operand2 = '" + new_operand2 + "' , Result =  '" + z + "'  where MultiplicationID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Multiplication";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
            }
            else if (table_name == "Division" || table_name == "division" || table_name == "/")
            {
                if (new_operand1 != "" && new_operand2 == "")
                {

                    string query = "update Division set Operand1 = '" + new_operand1 + "' , Result = '" + double.Parse(new_operand1) + "' / Operand2  where DivID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Division";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 == "" && new_operand2 != "")
                {
                    string query = "update Division set Operand2 = '" + new_operand2 + "' , Result =  Operand1 / '" + double.Parse(new_operand2) + "'   where DivID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Division";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
                else if (new_operand1 != "" && new_operand2 != "")
                {
                    double x, y, z;
                    x = double.Parse(new_operand1);
                    y = double.Parse(new_operand2);
                    z = x / y;
                    string query = "update Division set Operand1 = '" + new_operand1 + "' , Operand2 = '" + new_operand2 + "' , Result =  '" + z + "'   where DivID = '" + table_id + "'";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Values successfully updated");
                    string query1 = "Select * from Division";
                    SqlCommand cmd1 = new SqlCommand(query1, sql);
                    SqlDataAdapter data = new SqlDataAdapter(cmd1);
                    DataTable datatable = new DataTable();
                    data.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                }
            }
            else if (table_name == "square" || table_name == "Square" || table_name == "sqr" || table_name == "Sqr")
            {

                double x, z;
                x = double.Parse(new_operand1);
                z = x * x;
                string query = "update Sqr set Operand = '" + new_operand1 + "'  , Result =  '" + z + "'   where SqrID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully updated");
                string query1 = "Select * from Sqr";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (table_name == "squareroot" || table_name == "SquareRoot")
            {

                double x, z;
                x = double.Parse(new_operand1);
                z = Math.Sqrt(x);
                string query = "update SquareRoot set Operand = '" + new_operand1 + "'  , Result =  '" + z + "'   where SqrtID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully updated");
                string query1 = "Select * from SquareRoot";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            table_name = tablename.Text;
            table_id = tableID.Text;
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();

            if (table_name == "Addition" || table_name == "addition" || table_name == "+")
            {
                string query = "delete from Addition where AdditionID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully deleted");
                string query1 = "Select * from Addition";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (table_name == "Subtraction" || table_name == "subtraction" || table_name == "-")
            {
                string query = "delete from Subtraction where SubtractionID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully deleted");
                string query1 = "Select * from Subtraction";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (table_name == "Multiplication" || table_name == "multiplication" || table_name == "*")
            {
                string query = "delete from Multiplication where MultiplicationID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully deleted");
                string query1 = "Select * from Multiplication";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (table_name == "Division" || table_name == "division" || table_name == "/")
            {
                string query = "delete from Division where DivID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully deleted");
                string query1 = "Select * from Division";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (table_name == "SquareRoot" || table_name == "squareroot" || table_name == "sqrt")
            {
                string query = "delete from SquareRoot where SqrtID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully deleted");
                string query1 = "Select * from SquareRoot";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (table_name == "Square" || table_name == "square")
            {
                string query = "delete from Sqr where SqrID = '" + table_id + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Values successfully deleted");
                string query1 = "Select * from Sqr";
                SqlCommand cmd1 = new SqlCommand(query1, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd1);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(ConnectionString);
            sql.Open();
            if (tablename.Text == "Addition" || tablename.Text == "addition")
            {
                string query = "Select * from Addition";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (tablename.Text == "Subtraction" || tablename.Text == "subtraction")
            {
                string query = "Select * from Subtraction";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (tablename.Text == "Multiplication" || tablename.Text == "multiplication")
            {
                string query = "Select * from Multiplication";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (tablename.Text == "Division" || tablename.Text == "division")
            {
                string query = "Select * from Division";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (tablename.Text == "Sqr" || tablename.Text == "Square" || tablename.Text == "square")
            {
                string query = "Select * from Sqr";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
            else if (tablename.Text == "SquareRoot" || tablename.Text == "squareroot")
            {
                string query = "Select * from SquareRoot";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                data.Fill(datatable);
                dataGridView1.DataSource = datatable;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}


