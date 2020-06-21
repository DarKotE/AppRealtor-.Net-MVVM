using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Esoft.ClassFolder
{
    public class SqlMethods
    {
        internal List<Complex> SelectAllComplex()
        {
            throw new NotImplementedException();
        }

        public List<HouseInComplex> SelectAllHouseInComplex()
        {
            var tempHouseList = new List<HouseInComplex>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery =
                        "SELECT [IdHouse], [Street], [Number_House], [Cost_House_Construction], " +
                        "[Additional_Cost_Apartament_House], [Name_Housing_Complex], [City], " +
                        "[Status_Construction_Housing_Complex]";
                    sqlQuery += " FROM [dbo].[House]";
                    sqlQuery += " inner join [dbo].[Complex] on [Complex].IdComplex = [House].IdComplex";
                    sqlQuery += " WHERE [House].IsDeleted = 0";

                    var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<HouseInComplex>();
                        while (reader.Read())
                        {
                            var u = new HouseInComplex
                            {
                                IdHouse = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                NumberHouse = reader.GetString(2),
                                CostHouseConstruction = reader.GetInt64(3),
                                AdditionalCostHouseConstruction = reader.GetInt64(4),
                                NameHousingComplex = reader.GetString(5),
                                City = reader.GetString(6),
                                StatusConstructionHousingComplex = reader.GetString(7)
                            };

                            items.Add(u);
                        }

                        tempHouseList = items;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                finally
                {
                    sqlConnection.Close();

                }
            }

            return tempHouseList;

        }

        public List<House> SelectAllHouse()
        {
            var tempHouseList = new List<House>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery =
                        "SELECT [IdHouse], [Street], [Number_House], [Cost_House_Construction], " +
                        "[Additional_Cost_Apartament_House], [IdComplex], [IsDeleted] ";
                    sqlQuery += " FROM [dbo].[House]";
                    var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<House>();
                        while (reader.Read())
                        {
                            var u = new House
                            {
                                IdHouse = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                NumberHouse= reader.GetString(2),
                                CostHouseConstruction= reader.GetInt64(3),
                                AdditionalCostHouseConstruction = reader.GetInt64(4),
                                IdComplex = reader.GetInt32(5),
                                IsDeleted = reader.GetBoolean(6)
                            };

                            items.Add(u);
                        }

                        tempHouseList = items;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                finally
                {
                    sqlConnection.Close();

                }
            }

            return tempHouseList;
           
        }

        public List<Apartment> SelectAllApartment()
        {
            var tempApartmentList = new List<Apartment>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery =
                        "SELECT [Id],[Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], " +
                        "[Porch], [Floor], [Status_Sale], "
                        + "[Added_value], [Expenses_Building_An_Apartment]";
                    sqlQuery += " FROM [dbo].[Apartments]";
                    var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<Apartment>();
                        while (reader.Read())
                        {
                            var u = new Apartment
                            {
                                Id = reader.GetInt32(0),
                                IdLsd = reader.GetInt32(1),
                                NumberApartment = reader.GetInt32(2),
                                Area = reader.GetDouble(3),
                                NumberOfRooms = reader.GetInt32(4),
                                Porch = reader.GetInt32(5),
                                Floor = reader.GetInt32(6),
                                StatusSale = reader.GetString(7),
                                AddedValue = reader.GetInt64(8),
                                ExpensesBuildingAnApartament = reader.GetInt64(9)
                            };

                            items.Add(u);
                        }

                        tempApartmentList = items;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                finally
                {
                    sqlConnection.Close();

                }
            }

            return tempApartmentList;
        }

        public bool InsertComplex(Complex newComplex)
        {
            throw new NotImplementedException();
        }

        public bool SelectComplex(Complex newComplex)
        {
            throw new NotImplementedException();
        }

        public bool UpdateComplex(Complex newComplex)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComplex(Complex newComplex)
        {
            throw new NotImplementedException();
        }

        public bool InsertApartment(Apartment newApartment)
        {
            throw new NotImplementedException();
        }

        public bool SelectApartment(Apartment selectApartment)
        {
            throw new NotImplementedException();
        }

        public bool UpdateApartment(Apartment updateApartment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApartment(Apartment deleteApartment)
        {
            throw new NotImplementedException();
        }

        public bool InsertHouse(House newHouse)
        {
            throw new NotImplementedException();
        }

        public bool SelectHouse(House selectHouse)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHouse(House updateHouse)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHouse(House deleteHouse)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    const string sqlQuery = "UPDATE dbo.[House] set IsDeleted=1 "
                                            + "WHERE IdHouse=@IdHouse";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdHouse", deleteHouse.IdHouse);
                    sqlConnection.Open();
                    var noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    isDeleted = noOfRowsAffected > 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return isDeleted;
        }
    }



}
