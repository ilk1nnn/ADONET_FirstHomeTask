using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using static ProjectAdo.NET.MainWindow;


namespace ProjectAdo.NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public class Author
        {
            public object Id { get; set; }
            public object FirstName { get; set; }
            public object LastName { get; set; }
        }



        public Author MyAuthor { get; set; }




        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = this;



            //using (var conn = new SqlConnection())
            //{
            //    conn.ConnectionString = @"Data Source=STHQ0127-07;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    SqlDataReader reader = null;

            //    conn.Open();

            //    string query = "SELECT * FROM Authors";
            //    using (SqlCommand command = new SqlCommand(query, conn))
            //    {
            //        reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {

            //            MyAuthor = new Author()
            //            {
            //                Id = reader[0],
            //                FirstName = reader[1],
            //                LastName = reader[2]
            //            };


            //            listview1.Items.Add($"{MyAuthor.Id} - {MyAuthor.FirstName} - {MyAuthor.LastName}");

            //        }
            //    }
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source=STHQ0127-07;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn.Open();

                string query = $@"INSERT INTO Authors(Id,FirstName,LastName)
                                 VALUES(@id,@firstname,@lastname)";


                var paramid = new SqlParameter();
                paramid.ParameterName = "@id";
                paramid.SqlDbType = System.Data.SqlDbType.Int;
                paramid.Value = int.Parse(IdTxtb.Text);

                var paramfirstname = new SqlParameter();
                paramfirstname.ParameterName = "@firstname";
                paramfirstname.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramfirstname.Value = FirstNameTxtb.Text;


                var paramlastname = new SqlParameter();
                paramlastname.ParameterName = "@lastname";
                paramlastname.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramlastname.Value = LastNameTxtb.Text;


                using (SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.Add(paramid);
                    cmd.Parameters.Add(paramfirstname);
                    cmd.Parameters.Add(paramlastname);
                    var result = cmd.ExecuteNonQuery();





                    listview1.Items.Add($"{paramid.Value} - {paramfirstname.Value} - {paramlastname.Value}");

                }


            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source=STHQ0127-07;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn.Open();

                string query = $@"UPDATE Authors
                                  SET FirstName = @firstname, LastName = @lastname
                                  WHERE Id = @id";


                var paramid = new SqlParameter();
                paramid.ParameterName = "@id";
                paramid.SqlDbType = System.Data.SqlDbType.Int;
                paramid.Value = int.Parse(IdTxtb.Text);

                var paramfirstname = new SqlParameter();
                paramfirstname.ParameterName = "@firstname";
                paramfirstname.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramfirstname.Value = FirstNameTxtb.Text;


                var paramlastname = new SqlParameter();
                paramlastname.ParameterName = "@lastname";
                paramlastname.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramlastname.Value = LastNameTxtb.Text;


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(paramid);
                    cmd.Parameters.Add(paramfirstname);
                    cmd.Parameters.Add(paramlastname);
                    var result = cmd.ExecuteNonQuery();

                }


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source=STHQ0127-07;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn.Open();

                string query = $@"DELETE Authors
                                  WHERE Id = @id";


                var paramid = new SqlParameter();
                paramid.ParameterName = "@id";
                paramid.SqlDbType = System.Data.SqlDbType.Int;
                paramid.Value = int.Parse(IdTxtb.Text);



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(paramid);
                    var result = cmd.ExecuteNonQuery();

                }


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {



            this.DataContext = this;



            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source=STHQ0127-07;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlDataReader reader = null;

                conn.Open();

                string query = "SELECT * FROM Authors";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        MyAuthor = new Author()
                        {
                            Id = reader[0],
                            FirstName = reader[1],
                            LastName = reader[2]
                        };


                        listview1.Items.Add($"{MyAuthor.Id} - {MyAuthor.FirstName} - {MyAuthor.LastName}");

                    }
                }
            }


            allauthors.IsEnabled = false;
            emptylistview.IsEnabled = true;

        }

        private void emptylistview_Click(object sender, RoutedEventArgs e)
        {
            allauthors.IsEnabled=true;
            listview1.Items.Clear();
            emptylistview.IsEnabled=false;
        }
    }
}
