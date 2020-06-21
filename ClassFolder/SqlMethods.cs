using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Esoft.ClassFolder.ModelsFolder;

namespace Esoft.ClassFolder
{
    public class SqlMethods
    {
        
        public List<Complex> SelectAllComplex()
        {
            var tempComplexList = new List<Complex>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery =
                        "SELECT [IdComplex], [Name_Housing_Complex], [City], [Status_Construction_Housing_Complex], " +
                        "[Added_Value], [Building_Costs]"; 
                    sqlQuery += " FROM [dbo].[Complex]";
                    sqlQuery += " WHERE [Complex].IsDeleted = 0";

                    var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<Complex>();
                        while (reader.Read())
                        {
                            var u = new Complex
                            {
                                IdComplex = reader.GetInt32(0),
                                NameHousingComplex = reader.GetString(1),
                                City = reader.GetString(2),
                                StatusConstructionHousingComplex = reader.GetString(3),
                                AddedValue = reader.GetInt64(4),
                                BuildingCost = reader.GetInt64(5)
                            };

                            items.Add(u);
                        }

                        tempComplexList = items;
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

            return tempComplexList;
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

        public List<ComplexWithHouses> SelectAllComplexWithHouses()
        {
            var tempComplexList = new List<ComplexWithHouses>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery =
                        "SELECT [IdComplex], [Name_Housing_Complex], [City], [Status_Construction_Housing_Complex], " +
                        "[Added_Value], [Building_Costs]";
                    sqlQuery += " FROM [dbo].[Complex]";
                    sqlQuery += " WHERE [Complex].IsDeleted = 0";

                    var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<ComplexWithHouses>();
                        while (reader.Read())
                        {
                            var u = new ComplexWithHouses
                            {
                                IdComplex = reader.GetInt32(0),
                                NameHousingComplex = reader.GetString(1),
                                City = reader.GetString(2),
                                StatusConstructionHousingComplex = reader.GetString(3),
                                StatusConstructionHousingComplexName = reader.GetString(3),
                                AddedValue = reader.GetInt64(4),
                                BuildingCost = reader.GetInt64(5)
                            };

                            items.Add(u);
                        }

                        tempComplexList = items;
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

            return tempComplexList;

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


        public bool CanDeleteComplex(Complex complexToDelete)
        {
            var isPossible = true;

            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery =
                        "SELECT [Id]";
                    sqlQuery += " FROM [dbo].[Apartments]";
                    sqlQuery += " inner join[dbo].[House] on[House].IdHouse = Apartments.Id_LCD ";
                    sqlQuery += " inner join[dbo].[Complex] on[Complex].IdComplex = House.IdComplex";
                    sqlQuery += " WHERE Apartments.Status_Sale = 'sold' and [Complex].IdComplex = @IdComplex";

                    var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdComplex", complexToDelete.IdComplex);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        isPossible = false;
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

            return isPossible;
        }

        public bool InsertComplex(Complex newComplex)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[Complex] (Name_Housing_Complex," +
                                   " City, Status_Construction_Housing_Complex, Added_Value, Building_Costs, IsDeleted)" +
                                   " VALUES (@Name_Housing_Complex, @City, " +
                                   "@Status_Construction_Housing_Complex, @Added_Value, @Building_Costs, 0)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Name_Housing_Complex", newComplex.NameHousingComplex);
                    sqlCommand.Parameters.AddWithValue("Status_Construction_Housing_Complex", newComplex.StatusConstructionHousingComplex);
                    sqlCommand.Parameters.AddWithValue("Added_Value", newComplex.AddedValue);
                    sqlCommand.Parameters.AddWithValue("Building_Costs", newComplex.BuildingCost);
                    sqlCommand.Parameters.AddWithValue("City", newComplex.City);
                    sqlConnection.Open();
                    var noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    isInserted = noOfRowsAffected > 0;

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

            return isInserted;
        }

        public Complex SelectComplex(Complex newComplex)
        {
            var tempComplex = new Complex();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT [IdComplex], [City]," + 
                                   " [Name_Housing_Complex], [Status_Construction_Housing_Complex]," +
                                   " [Added_Value], [Building_Costs]";
                    sqlQuery += " FROM [dbo].[Complex]";
                    sqlQuery += " WHERE [Complex].IdComplex = @IdComplex AND [Complex].IsDeleted=0";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdComplex", newComplex.IdComplex);
                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<Complex>();
                    while (reader.Read())
                    {
                        var u = new Complex
                        {
                            IdComplex = (int)reader["IdComplex"],
                            City = (string)reader["City"],
                            NameHousingComplex = (string)reader["Name_Housing_Complex"],
                            StatusConstructionHousingComplex = (string)reader["Status_Construction_Housing_Complex"],
                            AddedValue = (long)reader["Added_Value"],
                            BuildingCost = (long)reader["Building_Costs"]
                            
                            
                        };
                        items.Add(u);
                    }
                    if (items.Count > 0) tempComplex = items[0];
                    
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
             
            return tempComplex;
        }

        public bool UpdateComplex(Complex newComplex)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = "UPDATE dbo.[Complex] set " +
                                            " Name_Housing_Complex=@Name_Housing_Complex, " +
                                            " City=@City, " +
                                            " Status_Construction_Housing_Complex=@Status_Construction_Housing_Complex," +
                                            " Added_Value=@Added_Value," +
                                            " Building_Costs=@Building_Costs," +
                                            " IsDeleted=0" +
                                            " WHERE IdComplex=@IdComplex";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Name_Housing_Complex", newComplex.NameHousingComplex);
                    sqlCommand.Parameters.AddWithValue("City", newComplex.City);
                    sqlCommand.Parameters.AddWithValue("Status_Construction_Housing_Complex", newComplex.StatusConstructionHousingComplex);
                    sqlCommand.Parameters.AddWithValue("Added_Value", newComplex.AddedValue);
                    sqlCommand.Parameters.AddWithValue("Building_Costs", newComplex.BuildingCost);
                    sqlCommand.Parameters.AddWithValue("NumberPhoneTeacher", newComplex.NameHousingComplex);
                    sqlCommand.Parameters.AddWithValue("IdComplex", newComplex.IdComplex);
                    sqlConnection.Open();
                    var noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    isUpdated = noOfRowsAffected > 0;

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
            return isUpdated;
        }

        public bool DeleteComplex(Complex newComplex)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    const string sqlQuery = "UPDATE dbo.[Complex] set IsDeleted=1 "
                                            + "WHERE IdComplex=@IdComplex";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdComplex", newComplex.IdComplex);
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
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[House] ([Street]," +
                                   " [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted])" +
                                   " VALUES (@Street, @Number_House, " +
                                   "@Cost_House_Construction, @Additional_Cost_Apartament_House, @IdComplex, 0)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Street", newHouse.Street);
                    sqlCommand.Parameters.AddWithValue("Number_House", newHouse.NumberHouse);
                    sqlCommand.Parameters.AddWithValue("Cost_House_Construction", newHouse.CostHouseConstruction);
                    sqlCommand.Parameters.AddWithValue("Additional_Cost_Apartament_House", newHouse.AdditionalCostHouseConstruction);
                    sqlCommand.Parameters.AddWithValue("IdComplex", newHouse.IdComplex);
                    sqlConnection.Open();
                    var noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    isInserted = noOfRowsAffected > 0;

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

            return isInserted;
        }

        public House SelectHouse(House selectHouse)
        {
            var tempHouse = new House();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT [IdHouse], [Street]," +
                                   " [Number_House], [Cost_House_Construction]," +
                                   " [Additional_Cost_Apartament_House], [IdComplex]";
                    sqlQuery += " FROM [dbo].[House]";
                    sqlQuery += " WHERE [House].IdHouse = @IdHouse AND [House].IsDeleted=0";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdHouse", selectHouse.IdHouse);
                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<House>();
                    while (reader.Read())
                    {
                        var u = new House
                        {
                            IdHouse = (int)reader["IdHouse"],
                            Street = (string)reader["Street"],
                            NumberHouse = (string)reader["Number_House"],
                            CostHouseConstruction = (long)reader["Cost_House_Construction"],
                            AdditionalCostHouseConstruction = (long)reader["Additional_Cost_Apartament_House"],
                            IdComplex = (int)reader["IdComplex"]


                        };
                        items.Add(u);
                    }
                    if (items.Count > 0) tempHouse = items[0];

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

            return tempHouse;
        }

        public bool UpdateHouse(House updateHouse)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = "UPDATE dbo.[House] set " +
                                            " Street=@Street, " +
                                            " Number_House=@Number_House, " +
                                            " Cost_House_Construction=@Cost_House_Construction," +
                                            " Additional_Cost_Apartament_House=@Additional_Cost_Apartament_House," +
                                            " IdComplex=@IdComplex," +
                                            " IsDeleted=0" +
                                            " WHERE IdHouse=@IdHouse";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Street", updateHouse.Street);
                    sqlCommand.Parameters.AddWithValue("Number_House", updateHouse.NumberHouse);
                    sqlCommand.Parameters.AddWithValue("Cost_House_Construction", updateHouse.CostHouseConstruction);
                    sqlCommand.Parameters.AddWithValue("Additional_Cost_Apartament_House", updateHouse.AdditionalCostHouseConstruction);
                    sqlCommand.Parameters.AddWithValue("IdComplex", updateHouse.IdComplex);
                    sqlCommand.Parameters.AddWithValue("IdHouse", updateHouse.IdHouse);
                    
                    sqlConnection.Open();
                    var noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    isUpdated = noOfRowsAffected > 0;

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
            return isUpdated;
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
