using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    class Movies
    {
        SqlConnection ConnectVideo = new SqlConnection("Data Source=karan-PC;Initial Catalog=videoSystem;Integrated Security=True");

        SqlCommand Comandrented = new SqlCommand();

        SqlDataReader videoreader;

        String dataupdate;
        

        public IEnumerable DefaultView { get; internal set; }

       


        public DataTable Viseoshow()
        {
            DataTable dtbase = new DataTable();
            try
            {
                Comandrented.Connection = ConnectVideo;
                dataupdate = "Select * from Movies";

                Comandrented.CommandText = dataupdate;
                ConnectVideo.Open();

                videoreader = Comandrented.ExecuteReader();

                if (videoreader.HasRows)
                {
                    dtbase.Load(videoreader);
                }
                return dtbase;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (videoreader != null)
                {
                    videoreader.Close();
                }

                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }

        }

        public void Updatecust(int CID, string FName, string LName, string Address, string Phone)
        {
            try
            {
                Comandrented.Parameters.Clear();
                Comandrented.Connection = ConnectVideo;
                dataupdate = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                Comandrented.Parameters.AddWithValue("@CustID", CID);
                Comandrented.Parameters.AddWithValue("@FirstName", FName);
                Comandrented.Parameters.AddWithValue("@LastName", LName);
                Comandrented.Parameters.AddWithValue("@Address", Address);
                Comandrented.Parameters.AddWithValue("@Phone", Phone);

                Comandrented.CommandText = dataupdate;

                ConnectVideo.Open();

                Comandrented.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }
        }

        public void Videosinsert(string Rat, string Titlemovie, string Yearmov, string RentCost, string Plots, string Genre, int copi)
        {
            try
            {
                Comandrented.Parameters.Clear();
                Comandrented.Connection = ConnectVideo;



                dataupdate = "Insert into Movies(Rating, Title, Year, Rental_Cost, Plot, Genre, copies) Values( @Rating, @Title, @Year, @Rental_Cost, @Plot, @Genre, @copies)";


                Comandrented.Parameters.AddWithValue("@Rating", Rat);
                Comandrented.Parameters.AddWithValue("@Title", Titlemovie);
                Comandrented.Parameters.AddWithValue("@Year", Yearmov);
                Comandrented.Parameters.AddWithValue("@Rental_Cost", RentCost);
                Comandrented.Parameters.AddWithValue("@Plot", Plots);
                Comandrented.Parameters.AddWithValue("@Genre", Genre);
                Comandrented.Parameters.AddWithValue("@copies", copi);

                Comandrented.CommandText = dataupdate;

                ConnectVideo.Open();

                Comandrented.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }
        }

        public void Delmovie(int MID)
        {
            try
            {
                Comandrented .Parameters.Clear();
                Comandrented.Connection = this.ConnectVideo;


                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MID) };
                Comandrented.Parameters.Add(parameterArray[0]);
                String mov;
                ConnectVideo.Open();

                mov = "Delete from Movies where MovieID like @MovieID";
                Comandrented.CommandText = mov;
                Comandrented.ExecuteNonQuery();



            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }

            }
        }

       

        public void UpdateVideo(int MovieID, string Rating, string Title, int Year, string Plot, string Genre, int copies)
        {
            try
            {
                Comandrented.Parameters.Clear();
                Comandrented.Connection = ConnectVideo;
                dataupdate = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MoviedID like @MovieID";


                Comandrented.Parameters.AddWithValue("@MoviedID", MovieID);
                Comandrented.Parameters.AddWithValue("@Rating", Rating);
                Comandrented.Parameters.AddWithValue("@Title", Title);
                Comandrented.Parameters.AddWithValue("@Year", Year);
                Comandrented.Parameters.AddWithValue("@Plot", Plot);
                Comandrented.Parameters.AddWithValue("@Genre", Genre);
                Comandrented.Parameters.AddWithValue("@copies", copies);


                Comandrented.CommandText = dataupdate;

                ConnectVideo.Open();

                Comandrented.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }
        }

        public DataTable Custshow()
        {
            DataTable dtbse = new DataTable();
            try
            {
                Comandrented .Connection = ConnectVideo;
                dataupdate = "Select * from Coustmer";

                Comandrented.CommandText = dataupdate;
                ConnectVideo.Open();

                videoreader = Comandrented.ExecuteReader();

                if (videoreader.HasRows)
                {
                    dtbse.Load(videoreader);
                }
                return dtbse;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (videoreader != null)
                {
                    videoreader.Close();
                }

                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }

        }



        public void InsertCust(string FName, string LName, string Address, string Phone)
        {
            try
            {
                Comandrented.Parameters.Clear();
                Comandrented.Connection = ConnectVideo;



                dataupdate = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";


                Comandrented.Parameters.AddWithValue("@FirstName", FName);
                Comandrented.Parameters.AddWithValue("@LastName", LName);
                Comandrented.Parameters.AddWithValue("@Address", Address);
                Comandrented.Parameters.AddWithValue("@Phone", Phone);

                Comandrented.CommandText = dataupdate;

                ConnectVideo.Open();

                Comandrented.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }
        }

        public void CustrDelete(int CID)
        {
            try
            {
                Comandrented .Parameters.Clear();
                Comandrented.Connection = this.ConnectVideo ;


                String Strr = "";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CID) };
                Comandrented.Parameters.Add(parameterArray[0]);

                ConnectVideo.Open();
                int count = Convert.ToInt32(Comandrented.ExecuteScalar());

                Strr = "Delete from Coustmer where CustID like @CustID";
                Comandrented.CommandText = Strr;
                Comandrented.ExecuteNonQuery();
                MessageBox.Show("customer deleted succesfully");

            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.ConnectVideo != null)
                {
                    this.ConnectVideo.Close();
                }
            }
        }

        public DataTable Rentshow()
        {
            DataTable dtbase = new DataTable();
            try
            {
                Comandrented.Connection = ConnectVideo;
                dataupdate = "Select * from RentedMovies";

                Comandrented.CommandText = dataupdate;
                ConnectVideo.Open();

                videoreader = Comandrented.ExecuteReader();

                if (videoreader.HasRows)
                {
                    dtbase.Load(videoreader);
                }
                return dtbase;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (videoreader != null)
                {
                    videoreader.Close();
                }

                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }

        }



        public void rentvideo(int MIDFK, int CIDFK, DateTime DRented, int copies)
        {
            try
            {
                Comandrented.Parameters.Clear();
                Comandrented.Connection = ConnectVideo;



                dataupdate = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented ) Values( @MovieIDFk, @CustIDFK, @DateRented)";

                Comandrented.Parameters.AddWithValue("@MovieIDFK", MIDFK);
                Comandrented.Parameters.AddWithValue("@CustIDFK", CIDFK);
                Comandrented.Parameters.AddWithValue("@DateRented", DRented);
                Comandrented.Parameters.AddWithValue("@copies", copies);


                Comandrented.CommandText = dataupdate;

                ConnectVideo.Open();

                Comandrented.ExecuteNonQuery();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }
        }


        public void Return(int RMID, int MID, DateTime DRent, DateTime DReturned)
        {
            try
            {
                Comandrented.Parameters.Clear();
                Comandrented.Connection = ConnectVideo;
                int Money = 0, Amount = 0;
                double days = (DReturned - DRent).TotalDays;

                string rent = "Select Rental_Cost from Movies where MovieID = @MovieIDFK";
                Comandrented.Parameters.AddWithValue("@MovieIDFK", MID);

                Comandrented.CommandText = rent;
                ConnectVideo.Open();
                Amount = Convert.ToInt32(Comandrented.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    Money = Amount;
                }
                else
                {
                    Money = Amount * Convert.ToInt32(days);
                }


                dataupdate = "Update RentedMovies Set DateReturned='" + DReturned + "' where RMID = @RMID";
                Comandrented.Parameters.AddWithValue("@DateReurned", DReturned);
                Comandrented.Parameters.AddWithValue("@RMID", RMID);

                Comandrented.CommandText = dataupdate;

                Comandrented.ExecuteNonQuery();


                dataupdate = "Update Movies set copies = copies+1 where MovieID = @MovieIDFK";
                this.Comandrented.CommandText = this.dataupdate;

                this.Comandrented.ExecuteNonQuery();

                this.Comandrented.CommandText = this.dataupdate;

                this.Comandrented.ExecuteNonQuery();

                MessageBox.Show("Your Fees is " + Money);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (ConnectVideo != null)
                {
                    ConnectVideo.Close();
                }
            }


        }

       


       
        


    }
}
