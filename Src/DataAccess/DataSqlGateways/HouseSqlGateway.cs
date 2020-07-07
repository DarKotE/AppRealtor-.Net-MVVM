using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Esoft.Models.House;

namespace Esoft.DataAccess.DataSqlGateways
{
    public class HouseSqlGateway:SqlConfig
    {
        public List<HouseInComplex> SelectAllHouseInComplex()
        {
            var tempHouseList = new List<HouseInComplex>();
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery =
                        @"SELECT [IdHouse], [Street], [Number_House], [Cost_House_Construction], 
                        [Additional_Cost_Apartament_House], [Name_Housing_Complex], [City], 
                        [Status_Construction_Housing_Complex]
                        FROM [dbo].[House]
                        inner join [dbo].[Complex] on [Complex].IdComplex = [House].IdComplex
                        WHERE [House].IsDeleted = 0";

                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }

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
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery =
                        @"SELECT [IdHouse], [Street], [Number_House], 
                        [Cost_House_Construction], [Additional_Cost_Apartament_House],
                        [IdComplex], [IsDeleted] 
                        FROM [dbo].[House]
                        WHERE [House].IsDeleted = 0";
                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }
                    if (reader.HasRows)
                    {
                        var items = new List<House>();
                        while (reader.Read())
                        {
                            var u = new House
                            {
                                IdHouse = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                NumberHouse = reader.GetString(2),
                                CostHouseConstruction = reader.GetInt64(3),
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


        public bool InsertHouse(House newHouse)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery = 
                        @"INSERT INTO dbo.[House] ([Street],
                        [Number_House], [Cost_House_Construction], 
                        [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted])
                        VALUES (@Street, @Number_House, @Cost_House_Construction, 
                        @Additional_Cost_Apartament_House, @IdComplex, 0)";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (newHouse != null)
                        {
                            sqlCommand.Parameters.AddWithValue("Street",
                                newHouse.Street);
                            sqlCommand.Parameters.AddWithValue("Number_House",
                                newHouse.NumberHouse);
                            sqlCommand.Parameters.AddWithValue("Cost_House_Construction",
                                newHouse.CostHouseConstruction);
                            sqlCommand.Parameters.AddWithValue("Additional_Cost_Apartament_House",
                                newHouse.AdditionalCostHouseConstruction);
                            sqlCommand.Parameters.AddWithValue("IdComplex",
                                newHouse.IdComplex);
                        }

                        sqlConnection.Open();
                        noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    }

                    isInserted = noOfRowsAffected > 0;

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

            return isInserted;
        }

        public House SelectHouse(House selectHouse)
        {
            var tempHouse = new House();
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery = 
                        @"SELECT [IdHouse], [Street],  [Number_House], [Cost_House_Construction],   
                        [Additional_Cost_Apartament_House], [IdComplex]
                        FROM [dbo].[House]
                        WHERE [House].IdHouse = @IdHouse 
                        AND [House].IsDeleted=0";
                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        if (selectHouse != null)
                            sqlCommand.Parameters.AddWithValue("IdHouse",
                                selectHouse.IdHouse);
                        reader = sqlCommand.ExecuteReader();
                    }

                    var items = new List<House>();
                    while (reader.Read())
                    {
                        var u = new House
                        {
                            IdHouse = (int) reader["IdHouse"],
                            Street = (string) reader["Street"],
                            NumberHouse = (string) reader["Number_House"],
                            CostHouseConstruction = (long) reader["Cost_House_Construction"],
                            AdditionalCostHouseConstruction = (long) reader["Additional_Cost_Apartament_House"],
                            IdComplex = (int) reader["IdComplex"]
                        };
                        items.Add(u);
                    }

                    if (items.Count > 0)
                        tempHouse = items[0];

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

            return tempHouse;
        }

        public bool UpdateHouse(House updateHouse)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery = 
                        @"UPDATE dbo.[House] 
                        SET Street=@Street, 
                        Number_House=@Number_House, 
                        Cost_House_Construction=@Cost_House_Construction,
                        Additional_Cost_Apartament_House=@Additional_Cost_Apartament_House,
                        IdComplex=@IdComplex,
                        IsDeleted=0
                        WHERE IdHouse=@IdHouse";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (updateHouse != null)
                        {
                            sqlCommand.Parameters.AddWithValue("Street",
                                updateHouse.Street);
                            sqlCommand.Parameters.AddWithValue("Number_House",
                                updateHouse.NumberHouse);
                            sqlCommand.Parameters.AddWithValue("Cost_House_Construction",
                                updateHouse.CostHouseConstruction);
                            sqlCommand.Parameters.AddWithValue("Additional_Cost_Apartament_House",
                                updateHouse.AdditionalCostHouseConstruction);
                            sqlCommand.Parameters.AddWithValue("IdComplex",
                                updateHouse.IdComplex);
                            sqlCommand.Parameters.AddWithValue("IdHouse",
                                updateHouse.IdHouse);
                        }

                        sqlConnection.Open();
                        noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    }

                    isUpdated = noOfRowsAffected > 0;

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

            return isUpdated;
        }

        public bool DeleteHouse(House deleteHouse)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery = 
                        @"UPDATE dbo.[House]
                        SET IsDeleted=1 
                        WHERE IdHouse=@IdHouse";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (deleteHouse != null)
                            sqlCommand.Parameters.AddWithValue("IdHouse",
                                deleteHouse.IdHouse);
                        sqlConnection.Open();
                        noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    }
                    isDeleted = noOfRowsAffected > 0;
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
            return isDeleted;
        }

        public bool DeleteHouseByComplexId(int idComplex)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(ConnectionStringValue()))
            {
                try
                {
                    const string sqlQuery =
                        @"UPDATE dbo.[House]
                        SET IsDeleted=1 
                        WHERE IdComplex=@IdComplex";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("IdComplex",
                            idComplex);
                        sqlConnection.Open();
                        noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    }
                    isDeleted = noOfRowsAffected > 0;
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
            return isDeleted;
        }

    }
    }
