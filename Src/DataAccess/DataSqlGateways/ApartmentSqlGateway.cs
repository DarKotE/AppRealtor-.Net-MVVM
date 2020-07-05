using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using Esoft.DataAccess.DataSqlGateways.SqlConfig;
using Esoft.Models.Apartment;

namespace Esoft.DataAccess.DataSqlGateways
{
    public class ApartmentSqlGateway
    {
        public List<Apartment> SelectAllApartment()
        {
            var tempApartmentList = new List<Apartment>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery =
                        @"SELECT [Id],[Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], 
                        [Porch], [Floor], [Status_Sale], 
                        [Added_value], [Expenses_Building_An_Apartment]
                        FROM [dbo].[Apartments]
                        WHERE [Apartments].IsDeleted = 0";
                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }

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


        public List<ApartmentWithComplexes> SelectAllApartmentWithComplexes()
        {
            var tempApartmentList = new List<ApartmentWithComplexes>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery =
                        @"SELECT [Id],[Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], 
                        [Porch], [Floor], [Status_Sale], 
                        [Apartments].[Added_value], 
						[Expenses_Building_An_Apartment], 
						[Name_Housing_Complex],
						[Street], [Number_House] 
                        FROM [dbo].[Apartments]
                        inner join [dbo].[House] on [House].IdHouse= [Apartments].Id_LCD
						inner join [dbo].[Complex] on [Complex].IdComplex = House.IdComplex
                        WHERE [Apartments].IsDeleted = 0";
                    SqlDataReader reader;
                    using (var sqlCommand = new SqlCommand(sqlQuery,
                        sqlConnection))
                    {
                        sqlConnection.Open();
                        reader = sqlCommand.ExecuteReader();
                    }

                    if (reader.HasRows)
                    {
                        var items = new List<ApartmentWithComplexes>();
                        while (reader.Read())
                        {
                            var u = new ApartmentWithComplexes
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
                                ExpensesBuildingAnApartament = reader.GetInt64(9),
                                NameHousingComplex =  reader.GetString(10),
                                Street = reader.GetString(11),
                                NumberHouse = reader.GetString(12)
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
    }
}
