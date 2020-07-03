using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Esoft.Classes.DataSqlGateways.SqlConfig;
using Esoft.Classes.Models.Complex;

namespace Esoft.Classes.DataSqlGateways
{
    public class ComplexSqlGateway
    {
        public List<Complex> SelectAllComplex()
        {
            var tempComplexList = new List<Complex>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery =
                        @"SELECT [IdComplex], [Name_Housing_Complex], [City],
                        [Status_Construction_Housing_Complex], 
                        [Added_Value], [Building_Costs]
                        FROM [dbo].[Complex]
                        WHERE [Complex].IsDeleted = 0";

                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }

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


        public List<ComplexWithHouses> SelectAllComplexWithHouses()
        {
            var tempComplexList = new List<ComplexWithHouses>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = 
                        @"SELECT [IdComplex], [Name_Housing_Complex], [City],
                        [Status_Construction_Housing_Complex], 
                        [Added_Value], [Building_Costs]
                        FROM [dbo].[Complex]
                        WHERE [Complex].IsDeleted = 0";

                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }

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


        public bool CanDeleteComplex(Complex complexToDelete)
        {
            var isPossible = true;

            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery =
                        @"SELECT [Id]
                        @FROM [dbo].[Apartments]
                        inner join[dbo].[House] 
                        on [House].IdHouse = Apartments.Id_LCD
                        inner join [dbo].[Complex] 
                        on [Complex].IdComplex = House.IdComplex
                        WHERE Apartments.Status_Sale = 'sold' and [Complex].IdComplex = @IdComplex";

                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (complexToDelete != null)
                            sqlCommand.Parameters.AddWithValue("IdComplex",
                                complexToDelete.IdComplex);
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }

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
                    const string sqlQuery = 
                        @"INSERT INTO dbo.[Complex] 
                        (Name_Housing_Complex,City, Status_Construction_Housing_Complex, 
                        Added_Value, Building_Costs, IsDeleted)
                        VALUES (@Name_Housing_Complex, @City, @Status_Construction_Housing_Complex,  
                        @Added_Value, @Building_Costs, 0)";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (newComplex != null)
                        {
                            sqlCommand.Parameters.AddWithValue("Name_Housing_Complex",
                                newComplex.NameHousingComplex);
                            sqlCommand.Parameters.AddWithValue("Status_Construction_Housing_Complex",
                                newComplex.StatusConstructionHousingComplex);
                            sqlCommand.Parameters.AddWithValue("Added_Value",
                                newComplex.AddedValue);
                            sqlCommand.Parameters.AddWithValue("Building_Costs",
                                newComplex.BuildingCost);
                            sqlCommand.Parameters.AddWithValue("City",
                                newComplex.City);
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

        public Complex SelectComplex(Complex newComplex)
        {
            var tempComplex = new Complex();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = 
                        @"SELECT [IdComplex], [City],
                        [Name_Housing_Complex], [Status_Construction_Housing_Complex],
                        [Added_Value], [Building_Costs]
                        FROM [dbo].[Complex]
                        WHERE [Complex].IdComplex = @IdComplex 
                        AND [Complex].IsDeleted=0";
                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        if (newComplex != null)
                            sqlCommand.Parameters.AddWithValue("IdComplex",
                                newComplex.IdComplex);
                        reader = sqlCommand.ExecuteReader();
                    }

                    var items = new List<Complex>();
                    while (reader.Read())
                    {
                        var u = new Complex
                        {
                            IdComplex = (int) reader["IdComplex"],
                            City = (string) reader["City"],
                            NameHousingComplex = (string) reader["Name_Housing_Complex"],
                            StatusConstructionHousingComplex = (string) reader["Status_Construction_Housing_Complex"],
                            AddedValue = (long) reader["Added_Value"],
                            BuildingCost = (long) reader["Building_Costs"]


                        };
                        items.Add(u);
                    }

                    if (items.Count > 0)
                        tempComplex = items[0];

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

            return tempComplex;
        }

        public bool UpdateComplex(Complex newComplex)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = 
                        @"UPDATE dbo.[Complex] 
                        SET Name_Housing_Complex=@Name_Housing_Complex, 
                        City=@City, 
                        Status_Construction_Housing_Complex=@Status_Construction_Housing_Complex,
                        Added_Value=@Added_Value,
                        Building_Costs=@Building_Costs,
                        IsDeleted=0
                        WHERE IdComplex=@IdComplex";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (newComplex != null)
                        {
                            sqlCommand.Parameters.AddWithValue("Name_Housing_Complex",
                                newComplex.NameHousingComplex);
                            sqlCommand.Parameters.AddWithValue("City",
                                newComplex.City);
                            sqlCommand.Parameters.AddWithValue("Status_Construction_Housing_Complex",
                                newComplex.StatusConstructionHousingComplex);
                            sqlCommand.Parameters.AddWithValue("Added_Value",
                                newComplex.AddedValue);
                            sqlCommand.Parameters.AddWithValue("Building_Costs",
                                newComplex.BuildingCost);
                            sqlCommand.Parameters.AddWithValue("NumberPhoneTeacher",
                                newComplex.NameHousingComplex);
                            sqlCommand.Parameters.AddWithValue("IdComplex",
                                newComplex.IdComplex);
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

        public bool DeleteComplex(Complex newComplex)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    const string sqlQuery =
                        @"UPDATE dbo.[Complex] 
                        SET IsDeleted=1 
                        WHERE IdComplex=@IdComplex";
                    int noOfRowsAffected;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        if (newComplex != null)
                            sqlCommand.Parameters.AddWithValue("IdComplex",
                                newComplex.IdComplex);
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
