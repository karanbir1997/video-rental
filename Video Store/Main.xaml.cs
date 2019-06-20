using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        
        Movies Obj_Movies = new Movies();
        

        public int CID;
        public int MID;

        public Main()
        {
            InitializeComponent();
            moviedate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

       

      

        

        private void loadcust(object sender, RoutedEventArgs e)
        {
            datagriduser.ItemsSource = Obj_Movies.Custshow().DefaultView;
        }
   
        private void showcust(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)datagriduser.SelectedItems[0];
            Cid.Text = Convert.ToString(row["CustID"]);
            Firstname.Text = Convert.ToString(row["FirstName"]);
            Lastname.Text = Convert.ToString(row["Lastname"]);
            Address.Text = Convert.ToString(row["Address"]);
            Phone.Text = Convert.ToString(row["Phone"]);

            datagriduser.ItemsSource = Obj_Movies .Custshow() .DefaultView;
        }
        private void CustomerinsertClick(object sender, RoutedEventArgs e)
        {

            if (Firstname.Text != "" && Lastname.Text != "" && Address.Text != "" && Phone.Text != "")
            {
                Obj_Movies.InsertCust(Firstname.Text, Lastname.Text, Address.Text, Phone.Text);
                datagriduser.ItemsSource = Obj_Movies.Custshow().DefaultView;
                Mid.Text = "";
                this.Cid.Text = "";
                movyear.Text = "";
                rate.Text = "";
                Mid.Text = "";
                this.copiestext.Text = "";
                Firstname.Text = "";
                namemovie.Text = "";
                Plot.Text = "";
                Genre.Text = "";

                Lastname.Text = "";
                Address.Text = "";
                Phone.Text = "";


            }
        }

        private void insertvideos_Click(object sender, RoutedEventArgs e)
        {
            
            if (rate.Text != "" && namemovie.Text != "" && movyear.Text != "" &&  Plot.Text != "" && Genre.Text != "" && copiestext.Text != "")
            {
                int yearvid = Convert.ToInt32(movyear.Text);
                int copies = Convert.ToInt32(this.copiestext.Text);
                string money;
                if (2019 - yearvid > 5)
                {
                    money = "2";
                        
                }
                else
                {
                    money = "5";
                }

                Obj_Movies.Videosinsert(rate.Text, namemovie.Text, movyear.Text, money, Plot.Text, Genre.Text, copies);
                datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
                namemovie.Text = "";
                Mid.Text = "";
                this.Cid.Text = "";
                movyear.Text = "";
                rate.Text = "";
                Mid.Text = "";
                this.copiestext.Text = "";
                Firstname.Text = "";
                namemovie.Text = "";
                Plot.Text = "";
                Genre.Text = "";

                Lastname.Text = "";
                Address.Text = "";
                Phone.Text = "";
                this.copiestext.Text = "";

            }
        }
        private void custupdate_Click(object sender, RoutedEventArgs e)
        {
            string FName = Firstname.Text;
            string LName = Lastname.Text;
            string Address = this.Address.Text;
            string Phone = this.Phone.Text;
            int CustID = Convert.ToInt32(Cid.Text);
            Obj_Movies.Updatecust(CustID, FName, LName, Address, Phone);

            datagriduser.ItemsSource = Obj_Movies.Custshow().DefaultView;
            Mid.Text = "";
            this.Cid.Text = "";
            movyear.Text = "";
            rate.Text = "";
            Mid.Text = "";
            this.copiestext.Text = "";
            Firstname.Text = "";
            namemovie.Text = "";
            Plot.Text = "";
            Genre.Text = "";

            Lastname.Text = "";
            
            this.Phone.Text = "";
            this.Address.Text = "";
        }

        private void getmovie_Click(object sender, RoutedEventArgs e)
        {
            if (copiestext.Text != "0")

            {
                if (Mid.Text != "" && Cid.Text != "" && moviedate.Text != "")
                {
                    int MID = Convert.ToInt32(Mid.Text);
                    int Cid = Convert.ToInt32(this.Cid.Text);
                    moviedate.Text = DateTime.Today.ToString("dd-MM-yyyy");
                    int copies = Convert.ToInt32(this.copiestext.Text);




                    Obj_Movies.rentvideo(MID, Cid, DateTime.Now, copies);
                    datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
                    datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
                    datagriduser.ItemsSource = Obj_Movies.Custshow().DefaultView;
                    Mid.Text = "";
                    this.Cid.Text = "";
                    movyear.Text = "";
                    rate.Text = "";
                    Mid.Text = "";
                    this.copiestext.Text = "";
                    Firstname.Text = "";
                    namemovie.Text = "";
                    Plot.Text = "";
                    Genre.Text = "";

                    Lastname.Text = "";
                    Address.Text = "";
                    Phone.Text = "";

                }

            }
            else
            {
                MessageBox.Show("No More Copies Left");
            }

        }


        private void showissue(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)datarent.SelectedItems[0];
            Mid.Text = Convert.ToString(row["MovieIDFK"]);
            Cid.Text = Convert.ToString(row["CustIDFK"]);
            Rmid_txt.Text = Convert.ToString(row["RMID"]);
            moviedate.Text = Convert.ToString(row["DateRented"]);
            dateretuned.Text = DateTime.Now.ToString("dd-MM-yyyy");



            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
        }

        private void video_load(object sender, RoutedEventArgs e)
        {
            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;

        }

        private void rented(object sender, RoutedEventArgs e)
        {
            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
        }

        private void vidretuen_Click(object sender, RoutedEventArgs e)
        {

            int RMID = Convert.ToInt32(Rmid_txt.Text);
            dateretuned.Text = DateTime.Today.ToString("dd-MM-yyyy");
            int MoviedID = Convert.ToInt32(Mid.Text);



            Obj_Movies.Return(RMID, MoviedID, Convert.ToDateTime(moviedate.Text), DateTime.Now);

            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
            datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
            datagriduser.ItemsSource = Obj_Movies.Custshow().DefaultView;
            Mid.Text = "";
            Cid.Text = "";
            Genre.Text = "";
            movyear.Text = "";
            rate.Text = "";
            Mid.Text = "";
            copiestext.Text = "";
            Firstname.Text = "";
            namemovie.Text = "";
            Plot.Text = "";

            Lastname.Text = "";
            Address.Text = "";
            Phone.Text = "";


        }

        private void DeluserClick(object sender, RoutedEventArgs e)
        {
            int CID = Convert.ToInt32(Cid.Text);
            
                Obj_Movies.CustrDelete(CID);
                datagriduser.ItemsSource = Obj_Movies.Custshow().DefaultView;
                Firstname.Text = "";
                Address.Text = "";
                Lastname.Text = "";

                Phone.Text = "";
            
        }
        private void Viddel(object sender, RoutedEventArgs e)
        {

            int Vid = Convert.ToInt32(Mid.Text);



                Obj_Movies .Delmovie( Vid);
                datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
                namemovie.Text = "";
                rate.Text = "";
                Plot.Text = "";
                movyear.Text = "";
                Genre.Text = "";
                Mid.Text = "";


            
            


        }

        private void showvid(object sender, RoutedEventArgs e)
        {
           datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
        }

        private void videoshow(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)datagridviode.SelectedItems[0];
            namemovie.Text = Convert.ToString(row["Title"]);
            Plot.Text = Convert.ToString(row["Plot"]);
            Genre.Text = Convert.ToString(row["Genre"]);
            movyear.Text = Convert.ToString(row["Year"]);
            rate.Text = Convert.ToString(row["Rating"]);
            Mid.Text = Convert.ToString(row["MovieID"]);
            copiestext.Text = Convert.ToString(row["copies"]);

            datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
        }

       

        private void UpdateMovies_Click(object sender, RoutedEventArgs e)
        {
            int MID = Convert.ToInt32(Mid.Text);
            int copies = Convert.ToInt32(this.copiestext.Text);


            string Title = namemovie.Text;
            string Rating = rate.Text;
            string Plot = this.Plot.Text;
            string Genre = this.Genre.Text;
            int Year = Convert.ToInt32(movyear.Text);
            Obj_Movies.UpdateVideo(MID, Rating, Title, Year, Plot, Genre, copies);
            datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
            namemovie.Text = "";
            rate.Text = "";
            this.Plot.Text = "";
            movyear.Text = "";
            this.Genre.Text = "";
            this.copiestext.Text = "";
        }
       

        private void Retuenvid(object sender, RoutedEventArgs e)
        {
            int RMID = Convert.ToInt32(Rmid_txt.Text);
            int MID = Convert.ToInt32(Mid.Text);
            


            Obj_Movies.Return(RMID, MID, Convert.ToDateTime(moviedate.Text), DateTime.Now);

            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
            datagridviode.ItemsSource = Obj_Movies.Viseoshow().DefaultView;
            datarent.ItemsSource = Obj_Movies.Rentshow().DefaultView;
            datagriduser.ItemsSource = Obj_Movies .Custshow().DefaultView;
            Mid.Text = "";
            Cid.Text = "";
            Genre.Text = "";
            movyear.Text = "";
            rate.Text = "";
            Mid.Text = "";
            copiestext.Text = "";
            Firstname.Text = "";
            Lastname.Text = "";
            namemovie.Text = "";
            Plot.Text = "";
            
            Address.Text = "";
            Phone.Text = "";


        }

      
    
        

      
    }
}
