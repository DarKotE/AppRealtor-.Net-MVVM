﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using AcademicPerformance.ClassFolder;

namespace Esoft.ClassFolder
{
    public class CDataAccess
    {
        #region AuthLoginValidation
        public bool IsAuthValid(string userLogin, string userPassword)
        {
            
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                const string sqlQuery = "SELECT IdUser FROM [dbo].[User] " + 
                                        "Where  LoginUser  = @LoginUser AND PasswordUser = @PasswordUser";
                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("LoginUser", userLogin);
                sqlCommand.Parameters.AddWithValue("PasswordUser", userPassword);
                try
                {
                    sqlConnection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        sqlDataReader.Close();
                        return true;
                    }
                    else
                    {
                        sqlDataReader.Close();
                        return false;
                    }
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
                return false;

            }
                
        }
        public bool IsLoginFree(string login)
        {

            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("select IdUser From dbo.[User]" 
                                            + " Where  LoginUser='" + login + "'", sqlConnection);
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Close();
                    return false;
                }
                else
                {
                    sqlDataReader.Close();
                    return true;
                }

            }

        }
        #endregion  

        
        #region UserAccess
        public List<UserModel> GetUserList()
        {
            var tempUserList = new List<UserModel>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdUser, LoginUser, PasswordUser, RoleUser";
                    sqlQuery += " FROM [dbo].[User]";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var users = new List<UserModel>();
                        while (reader.Read())
                        {
                            var u = new UserModel();
                            u.IdUser = reader.GetInt32(0);
                            u.LoginUser = reader.GetString(1);
                            u.PasswordUser = reader.GetString(2);
                            u.RoleUser = reader.GetInt32(3);
                            users.Add(u);
                        }
                        tempUserList = users;
                    }
                    

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
            return tempUserList;
        }

        public UserModel GetUser(string userLogin, string userPassword)
        {
            var tempUserModel = new UserModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdUser, LoginUser, PasswordUser, RoleUser";
                    sqlQuery += " FROM [dbo].[User]";
                    sqlQuery += " WHERE [User].LoginUser = @LoginUser " + 
                                "AND [User].PasswordUser = @PasswordUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("LoginUser", userLogin);
                    sqlCommand.Parameters.AddWithValue("PasswordUser", userPassword);
                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<UserModel>();
                    while (reader.Read())
                    {
                        var u = new UserModel();
                        u.IdUser = (int)reader["IdUser"];
                        u.LoginUser = (string)reader["LoginUser"];
                        u.PasswordUser = (string)reader["PasswordUser"];
                        u.RoleUser = (int)reader["RoleUser"];
                        items.Add(u);
                    }
                    if (items.Count>0)tempUserModel = items[0];

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
            return tempUserModel;
        }
        public bool InsertUser(UserModel userModel)
        {
            var isInserted = false;
            using (var sqlConnection = 
                new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
               
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[User] (LoginUser,PasswordUser," 
                                   + "RoleUser) VALUES (@LoginUser, @PasswordUser, @RoleUser)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("LoginUser", userModel.LoginUser);
                    sqlCommand.Parameters.AddWithValue("PasswordUser", userModel.PasswordUser);
                    sqlCommand.Parameters.AddWithValue("RoleUser", userModel.RoleUser);
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


        public bool UpdateUser(UserModel userModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    var sqlQuery = "UPDATE dbo.[User] set LoginUser=@LoginUser, " 
                                   + "PasswordUser=@PasswordUser, RoleUser=@RoleUser WHERE IdUser=@IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("LoginUser", userModel.LoginUser);
                    sqlCommand.Parameters.AddWithValue("PasswordUser", userModel.PasswordUser);
                    sqlCommand.Parameters.AddWithValue("RoleUser", userModel.RoleUser);
                    sqlCommand.Parameters.AddWithValue("IdUser", userModel.IdUser);
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

        public bool DeleteUser(int idUser)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    const string sqlQuery = "DELETE FROM  dbo.[User]" +
                                            " WHERE IdUser=@IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", idUser);
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

        public UserModel SelectUserId(int idUser)
        {
            UserModel tempUser = null;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdUser, LoginUser, PasswordUser, RoleUser";
                    sqlQuery += " FROM [dbo].[User] WHERE IdUser=@IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", idUser);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows) 
                    {
                        reader.Read();
                        tempUser = new UserModel
                        {
                            IdUser = reader.GetInt32(0),
                            LoginUser = reader.GetString(1),
                            PasswordUser = reader.GetString(2),
                            RoleUser = reader.GetInt32(3)
                        };
                    }
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
            return tempUser;
        }
        public UserModel SelectUserLogin(string loginUser)
        {
            UserModel tempUser = null;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdUser, LoginUser, PasswordUser, RoleUser";
                    sqlQuery += " FROM [dbo].[User] WHERE LoginUser=@LoginUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("LoginUser", loginUser);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        tempUser = new UserModel();
                        tempUser.IdUser = reader.GetInt32(0);
                        tempUser.LoginUser = reader.GetString(1);
                        tempUser.PasswordUser = reader.GetString(2);
                        tempUser.RoleUser = reader.GetInt32(3);
                    }
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
            return tempUser;
        }

        #endregion

        
        #region JournalAccess
        
        public List<JournalModel> GetJournalListForUser()
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                var sqlQuery = "select [IdJournal],";
                sqlQuery +=
                    " RTRIM(LTRIM(CONCAT(COALESCE([LastNameStudent] + ' ', '')," + 
                    " COALESCE([FirstNameStudent] + ' ', ''), COALESCE([MiddleNameStudent], '')))) AS FIOStudent,";
                sqlQuery += " [NameEvaluation],[NumberEvaluation],";
                sqlQuery +=
                    " RTRIM(LTRIM(CONCAT(COALESCE([LastNameTeacher] + ' ', ''), " + 
                    "COALESCE([FirstNameTeacher] + ' ', ''), COALESCE([MiddleNameTeacher]," +
                    " '')))) AS FIOTeacher,";
                sqlQuery += " [NameDiscipline], [Journal].[IdStudent], [Journal].[IdTeacher]," 
                            + " [Journal].[IdDiscipline], [Journal].[Id]";
                sqlQuery += " FROM [dbo].[Journal]";
                sqlQuery += " inner join [dbo].Student on Student.IdStudent = Journal.IdStudent";
                sqlQuery += " inner join [dbo].Teacher on Teacher.IdTeacher = Journal.IdTeacher";
                sqlQuery += " inner join [dbo].Evaluation on Evaluation.Id = Journal.Id";
                sqlQuery += " inner join [dbo].Discipline on Discipline.IdDiscipline = Journal.IdDiscipline";
                sqlQuery += " WHERE Student.IdUser = @IdUser or Teacher.IdUser=@IdUser";

                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdUser", App.IdUser);
                var dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                var journalList = (from DataRow dataRow in dataTable.Rows
                    select new JournalModel()
                    {
                        IdJournal = Convert.ToInt32(dataRow["IdJournal"]),
                        FIOStudent = dataRow["FIOStudent"].ToString(),
                        FIOTeacher = dataRow["FIOTeacher"].ToString(),
                        NameDiscipline = dataRow["NameDiscipline"].ToString(),
                        NameEvaluation = dataRow["NameEvaluation"].ToString(),
                        NumberEvaluation = Convert.ToInt32(dataRow["NumberEvaluation"]),
                        IdStudent = Convert.ToInt32(dataRow["IdStudent"]),
                        IdTeacher = Convert.ToInt32(dataRow["IdTeacher"]),
                        IdDiscipline = Convert.ToInt32(dataRow["IdDiscipline"]),
                        IdEvaluation = Convert.ToInt32(dataRow["Id"]),
                    }).ToList();

                var output = journalList;
                return output;
            }
        }
        public List<JournalModel> GetJournalList()
        {
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                var sqlQuery = "select [IdJournal],";
                sqlQuery +=
                    " RTRIM(LTRIM(CONCAT(COALESCE([LastNameStudent] + ' ', '')," +
                    " COALESCE([FirstNameStudent] + ' ', ''), COALESCE([MiddleNameStudent], '')))) AS FIOStudent,";
                sqlQuery += " [NameEvaluation],[NumberEvaluation],";
                sqlQuery +=
                    " RTRIM(LTRIM(CONCAT(COALESCE([LastNameTeacher] + ' ', ''), " +
                    "COALESCE([FirstNameTeacher] + ' ', ''), COALESCE([MiddleNameTeacher]," +
                    " '')))) AS FIOTeacher,";
                sqlQuery += " [NameDiscipline], [Journal].[IdStudent], [Journal].[IdTeacher],"
                            + " [Journal].[IdDiscipline], [Journal].[Id]";
                sqlQuery += " FROM [dbo].[Journal]";
                sqlQuery += " inner join [dbo].Student on Student.IdStudent = Journal.IdStudent";
                sqlQuery += " inner join [dbo].Teacher on Teacher.IdTeacher = Journal.IdTeacher";
                sqlQuery += " inner join [dbo].Evaluation on Evaluation.Id = Journal.Id";
                sqlQuery += " inner join [dbo].Discipline on Discipline.IdDiscipline = Journal.IdDiscipline";

                var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                var dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                var journalList = (from DataRow dataRow in dataTable.Rows
                                   select new JournalModel()
                                   {
                                       IdJournal = Convert.ToInt32(dataRow["IdJournal"]),
                                       FIOStudent = dataRow["FIOStudent"].ToString(),
                                       FIOTeacher = dataRow["FIOTeacher"].ToString(),
                                       NameDiscipline = dataRow["NameDiscipline"].ToString(),
                                       NameEvaluation = dataRow["NameEvaluation"].ToString(),
                                       NumberEvaluation = Convert.ToInt32(dataRow["NumberEvaluation"]),
                                       IdStudent = Convert.ToInt32(dataRow["IdStudent"]),
                                       IdTeacher = Convert.ToInt32(dataRow["IdTeacher"]),
                                       IdDiscipline = Convert.ToInt32(dataRow["IdDiscipline"]),
                                       IdEvaluation = Convert.ToInt32(dataRow["Id"]),
                                   }).ToList();

                var output = journalList;
                return output;
            }
        }

        public JournalModel GetJournal(int idJournal)
        {
            var tempJournal = new JournalModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdJournal, IdStudent, IdTeacher, IdDiscipline, Id";
                    sqlQuery += " FROM [dbo].[Journal]";
                    sqlQuery += " WHERE [Journal].IdJournal = @IdJournal";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdJournal", idJournal);

                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<JournalModel>();
                    while (reader.Read())
                    {
                        var u = new JournalModel
                        {
                            IdJournal = (int) reader["Id"],
                            IdStudent = (int) reader["IdStudent"],
                            IdTeacher = (int) reader["IdTeacher"],
                            IdDiscipline = (int) reader["IdDiscipline"],
                            IdEvaluation = (int) reader["Id"]
                        };

                        items.Add(u);
                    }
                    if (items.Count>0) tempJournal = items[0];

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
            return tempJournal;
        }
        public bool InsertJournal(JournalModel journalModel)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[Journal] (IdStudent, IdTeacher, " 
                                   + "IdDiscipline, Id) VALUES (@IdStudent, " 
                                   + "@IdTeacher, @IdDiscipline, @Id)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdStudent", journalModel.IdStudent);
                    sqlCommand.Parameters.AddWithValue("IdTeacher", journalModel.IdTeacher);
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", journalModel.IdDiscipline);
                    sqlCommand.Parameters.AddWithValue("Id", journalModel.IdEvaluation);
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


        public bool UpdateJournal(JournalModel journalModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "UPDATE dbo.[Journal] set IdTeacher=@IdTeacher," 
                                   + "IdStudent=@IdStudent,IdDiscipline=@IdDiscipline,Id=@Id" 
                                   + " WHERE IdJournal=@IdJournal";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdJournal", journalModel.IdJournal);
                    sqlCommand.Parameters.AddWithValue("IdTeacher", journalModel.IdTeacher);
                    sqlCommand.Parameters.AddWithValue("IdStudent", journalModel.IdStudent);
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", journalModel.IdDiscipline);
                    sqlCommand.Parameters.AddWithValue("Id", journalModel.IdEvaluation);
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

        public bool DeleteJournal(int idJournal)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    var sqlQuery = "DELETE FROM  dbo.[Journal] WHERE idJournal=@idJournal";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("idJournal", idJournal);
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



        #endregion  


        #region DisciplineAccess
        public List<DisciplineModel> GetDisciplineList()
        {
            var tempDisciplineList = new List<DisciplineModel>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdDiscipline, NameDiscipline";
                    sqlQuery += " FROM [dbo].[Discipline]";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var disciplines = new List<DisciplineModel>();
                        while (reader.Read())
                        {
                            var u = new DisciplineModel();
                            u.IdDiscipline = reader.GetInt32(0);
                            u.NameDiscipline = reader.GetString(1);
                            disciplines.Add(u);
                        }
                        tempDisciplineList = disciplines;
                    }


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
            return tempDisciplineList;
        }

        public DisciplineModel GetDiscipline(int idDiscipline)
        {
            var tempDiscipline = new DisciplineModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdDiscipline, NameDiscipline";
                    sqlQuery += " FROM [dbo].[Discipline]";
                    sqlQuery += " WHERE [Discipline].IdDiscipline = @IdDiscipline";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", idDiscipline);
                    
                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<DisciplineModel>();
                    while (reader.Read())
                    {
                        var u = new DisciplineModel();
                        u.IdDiscipline = (int)reader["IdDiscipline"];
                        u.NameDiscipline = (string)reader["NameDiscipline"];
                        items.Add(u);
                    }
                    if (items.Count > 0) tempDiscipline = items[0];

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
            return tempDiscipline;
        }
        public bool InsertDiscipline(DisciplineModel disciplineModel)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[Discipline] (IdDiscipline,NameDiscipline)"
                                   + " VALUES (@IdDiscipline, @NameDiscipline)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", disciplineModel.IdDiscipline);
                    sqlCommand.Parameters.AddWithValue("NameDiscipline", disciplineModel.NameDiscipline);
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


        public bool UpdateDiscipline(DisciplineModel disciplineModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "UPDATE dbo.[Discipline] set NameDiscipline=@NameDiscipline "
                                   + "WHERE IdDiscipline=@IdDiscipline";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameDiscipline", disciplineModel.NameDiscipline);
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", disciplineModel.IdDiscipline);
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

        public bool DeleteDiscipline(int idDiscipline)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    var sqlQuery = "DELETE FROM  dbo.[Discipline] WHERE IdDiscipline=@IdDiscipline";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", idDiscipline);
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

        #endregion  


        #region EvaluationAccess
        public List<EvaluationModel> GetEvaluationList()
        {
            var tempEvaluationList = new List<EvaluationModel>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT Id, NameEvaluation, NumberEvaluation";
                    sqlQuery += " FROM [dbo].[Evaluation]";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<EvaluationModel>();
                        while (reader.Read())
                        {
                            var u = new EvaluationModel
                            {
                                IdEvaluation = reader.GetInt32(0),
                                NameEvaluation = reader.GetString(1),
                                NumberEvaluation = reader.GetInt32(2)
                            };
                            items.Add(u);
                        }
                        tempEvaluationList = items;
                    }


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
            return tempEvaluationList;
        }

        public EvaluationModel GetEvaluation(int idEvaluation)
        {
            var tempEvaluation = new EvaluationModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT Id, NameEvaluation, NumberEvaluation";
                    sqlQuery += " FROM [dbo].[Evaluation]";
                    sqlQuery += " WHERE [Evaluation].Id = @Id";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("Id", idEvaluation);

                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<EvaluationModel>();
                    while (reader.Read())
                    {
                        var u = new EvaluationModel
                        {
                            IdEvaluation = (int) reader["Id"],
                            NameEvaluation = (string) reader["NameEvaluation"],
                            NumberEvaluation = (int) reader["NumberEvaluation"]
                        };

                        items.Add(u);
                    }
                    if (items.Count > 0) tempEvaluation = items[0];

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
            return tempEvaluation;
        }
        public bool InsertEvaluation(EvaluationModel evaluationModel)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[Evaluation] " 
                                   + "(Id, NameEvaluation, NumberEvaluation) "
                                   + "VALUES (@Id, @NameEvaluation,@NumberEvaluation)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdDiscipline", evaluationModel.IdEvaluation);
                    sqlCommand.Parameters.AddWithValue("NameEvaluation", evaluationModel.NameEvaluation);
                    sqlCommand.Parameters.AddWithValue("NumberEvaluation", evaluationModel.NumberEvaluation);
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


        public bool UpdateEvaluation(EvaluationModel evaluationModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = "UPDATE dbo.[Evaluation] set NameEvaluation=@NameEvaluation,NumberEvaluation=@NumberEvaluation" +
                                            " WHERE Id=@Id";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameEvaluation", evaluationModel.NameEvaluation);
                    sqlCommand.Parameters.AddWithValue("NumberEvaluation", evaluationModel.NumberEvaluation);
                    sqlCommand.Parameters.AddWithValue("Id", evaluationModel.IdEvaluation);
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

        public bool DeleteEvaluation(int idEvaluation)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    var sqlQuery = "DELETE FROM  dbo.[Evaluation] WHERE Id=@Id";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Id", idEvaluation);
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

        #endregion


        #region TeacherAccess
        public List<TeacherModel> GetTeacherList()
        {
            var tempTeacherList = new List<TeacherModel>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdTeacher, LastNameTeacher,FirstNameTeacher, "
                                   + "MiddleNameTeacher,DateOfBirthTeacher,NumberPhoneTeacher, IdUser";
                    sqlQuery += " FROM [dbo].[Teacher]";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<TeacherModel>();
                        while (reader.Read())
                        {
                            var u = new TeacherModel
                            {
                                IdTeacher = reader.GetInt32(0),
                                LastNameTeacher = reader.GetString(1),
                                FirstNameTeacher = reader.GetString(2),
                                MiddleNameTeacher = reader.GetString(3),
                                DateOfBirthTeacher = reader.GetDateTime(4),
                                NumberPhoneTeacher = reader.GetString(5),
                                IdUser = reader.GetInt32(6)
                            };

                            items.Add(u);
                        }
                        tempTeacherList = items;
                    }


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
            return tempTeacherList;
        }

        public TeacherModel GetTeacher(int idUser)
        {
            var tempTeacherModel = new TeacherModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdTeacher, LastNameTeacher, " 
                                   + "FirstNameTeacher, MiddleNameTeacher, DateOfBirthTeacher, NumberPhoneTeacher,IdUser ";
                    sqlQuery += " FROM [dbo].[Teacher]";
                    sqlQuery += " WHERE [Teacher].IdUser = @IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdUser", idUser);
                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<TeacherModel>();
                    while (reader.Read())
                    {
                        var u = new TeacherModel
                        {
                            IdTeacher = (int) reader["IdTeacher"],
                            LastNameTeacher = (string) reader["LastNameTeacher"],
                            FirstNameTeacher = (string) reader["FirstNameTeacher"],
                            MiddleNameTeacher = (string) reader["MiddleNameTeacher"],
                            DateOfBirthTeacher = (DateTime) reader["DateOfBirthTeacher"],
                            NumberPhoneTeacher = (string) reader["NumberPhoneTeacher"],
                            IdUser = (int)reader["IdUser"]
                        };
                        items.Add(u);
                    }
                    if (items.Count > 0) tempTeacherModel = items[0];

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
            return tempTeacherModel;
        }
        public bool InsertTeacher(TeacherModel teacherModel)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[Teacher] (IdUser,LastNameTeacher,"
                                   + " FirstNameTeacher, MiddleNameTeacher,DateOfBirthTeacher,NumberPhoneTeacher) VALUES (@IdUser, @LastNameTeacher, @FirstNameTeacher,@MiddleNameTeacher,@DateOfBirthTeacher,@NumberPhoneTeacher)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", teacherModel.IdUser);
                    sqlCommand.Parameters.AddWithValue("LastNameTeacher", teacherModel.LastNameTeacher);
                    sqlCommand.Parameters.AddWithValue("FirstNameTeacher", teacherModel.FirstNameTeacher);
                    sqlCommand.Parameters.AddWithValue("MiddleNameTeacher", teacherModel.MiddleNameTeacher);
                    sqlCommand.Parameters.AddWithValue("DateOfBirthTeacher", teacherModel.DateOfBirthTeacher);
                    sqlCommand.Parameters.AddWithValue("NumberPhoneTeacher", teacherModel.NumberPhoneTeacher);
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


        public bool UpdateTeacher(TeacherModel teacherModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = "UPDATE dbo.[Teacher] set IdUser=@IdUser, LastNameTeacher=@PasswordUser, FirstNameTeacher=@FirstNameTeacher, DateOfBirthTeacher=@DateOfBirthTeacher, NumberPhoneTeacher=@NumberPhoneTeacher WHERE IdTeacher=@IdTeacher";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", teacherModel.IdUser);
                    sqlCommand.Parameters.AddWithValue("LastNameTeacher", teacherModel.LastNameTeacher);
                    sqlCommand.Parameters.AddWithValue("FirstNameTeacher", teacherModel.FirstNameTeacher);
                    sqlCommand.Parameters.AddWithValue("MiddleNameTeacher", teacherModel.MiddleNameTeacher);
                    sqlCommand.Parameters.AddWithValue("DateOfBirthTeacher", teacherModel.DateOfBirthTeacher);
                    sqlCommand.Parameters.AddWithValue("NumberPhoneTeacher", teacherModel.NumberPhoneTeacher);
                    sqlCommand.Parameters.AddWithValue("IdTeacher", teacherModel.IdTeacher);
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

        public bool DeleteTeacher(int idUser)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    const string sqlQuery = "DELETE FROM  dbo.[Teacher] WHERE IdUser=@IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", idUser);
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

        #endregion


        #region StudentAccess
        public List<StudentModel> GetStudentList()
        {
            var tempStudentList = new List<StudentModel>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdStudent, LastNameStudent, "
                                   + "FirstNameStudent,MiddleNameStudent,DateOfBirthStudent,NumberPhoneStudent,IdUser";
                    sqlQuery += " FROM [dbo].[Student]";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var items = new List<StudentModel>();
                        while (reader.Read())
                        {
                            var u = new StudentModel
                            {
                                IdStudent = reader.GetInt32(0),
                                LastNameStudent = reader.GetString(1),
                                FirstNameStudent = reader.GetString(2),
                                MiddleNameStudent = reader.GetString(3),
                                DateOfBirthStudent = reader.GetDateTime(4),
                                NumberPhoneStudent = reader.GetString(5),
                                IdUser = reader.GetInt32(6)
                            };
                            items.Add(u);
                        }
                        tempStudentList = items;
                    }


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
            return tempStudentList;
        }

        public StudentModel GetStudent(int idUser)
        {
            var tempStudentModel = new StudentModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdUser, IdStudent, LastNameStudent, "
                                   + "FirstNameStudent, MiddleNameStudent, DateOfBirthStudent, NumberPhoneStudent";
                    sqlQuery += " FROM [dbo].[Student]";
                    sqlQuery += " WHERE [Student].IdUser = @IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdUser", idUser);
                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<StudentModel>();
                    while (reader.Read())
                    {
                        var u = new StudentModel
                        {
                            IdStudent = (int) reader["IdStudent"],
                            IdUser = (int) reader["IdUser"],
                            LastNameStudent = (string) reader["LastNameStudent"],
                            FirstNameStudent = (string) reader["FirstNameStudent"],
                            MiddleNameStudent = (string) reader["MiddleNameStudent"],
                            DateOfBirthStudent = (DateTime) reader["DateOfBirthStudent"],
                            NumberPhoneStudent = (string) reader["NumberPhoneStudent"]
                        };
                        items.Add(u);
                    }
                    if (items.Count>0) tempStudentModel = items[0];

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
            return tempStudentModel;
        }
        public bool InsertStudent(StudentModel studentModel)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = "INSERT INTO dbo.[Student] (IdUser,LastNameStudent, " 
                                            + "FirstNameStudent, MiddleNameStudent, DateOfBirthStudent, NumberPhoneStudent)"
                                            + " VALUES (@IdUser, @LastNameStudent, @FirstNameStudent, @MiddleNameStudent, @DateOfBirthStudent, @NumberPhoneStudent)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", studentModel.IdUser);
                    sqlCommand.Parameters.AddWithValue("LastNameStudent", studentModel.LastNameStudent);
                    sqlCommand.Parameters.AddWithValue("FirstNameStudent", studentModel.FirstNameStudent);
                    sqlCommand.Parameters.AddWithValue("MiddleNameStudent", studentModel.MiddleNameStudent);
                    sqlCommand.Parameters.AddWithValue("DateOfBirthStudent", studentModel.DateOfBirthStudent);
                    sqlCommand.Parameters.AddWithValue("NumberPhoneStudent", studentModel.NumberPhoneStudent);
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


        public bool UpdateStudent(StudentModel studentModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    const string sqlQuery = "UPDATE dbo.[Student] set IdUser=@IdUser, "
                                            + "LastNameStudent=@LastNameStudent, FirstNameStudent=@FirstNameStudent,MiddleNameStudent=@MiddleNameStudent, DateOfBirthStudent=@DateOfBirthStudent, NumberPhoneStudent=@NumberPhoneStudent WHERE IdStudent=@IdStudent";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", studentModel.IdUser);
                    sqlCommand.Parameters.AddWithValue("LastNameStudent", studentModel.LastNameStudent);
                    sqlCommand.Parameters.AddWithValue("FirstNameStudent", studentModel.FirstNameStudent);
                    sqlCommand.Parameters.AddWithValue("MiddleNameStudent", studentModel.MiddleNameStudent);
                    sqlCommand.Parameters.AddWithValue("DateOfBirthStudent", studentModel.DateOfBirthStudent);
                    sqlCommand.Parameters.AddWithValue("NumberPhoneStudent", studentModel.NumberPhoneStudent);
                    sqlCommand.Parameters.AddWithValue("IdStudent", studentModel.IdStudent);
                    sqlConnection.Open();
                    var noOfRowsAffected = sqlCommand.ExecuteNonQuery();
                    isUpdated = noOfRowsAffected > 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return isUpdated;
        }

        public bool DeleteStudent(int idUser)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    const string sqlQuery = "DELETE FROM  dbo.[Student] WHERE IdUser=@IdUser";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", idUser);
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

        #endregion

        #region RoleAccess
        public List<RoleModel> GetRoleList()
        {
            var tempRoleList = new List<RoleModel>();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdRole, NameRole";
                    sqlQuery += " FROM [dbo].[Role]";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        var Roles = new List<RoleModel>();
                        while (reader.Read())
                        {
                            var u = new RoleModel();
                            u.IdRole = reader.GetInt32(0);
                            u.NameRole = reader.GetString(1);
                            Roles.Add(u);
                        }
                        tempRoleList = Roles;
                    }


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
            return tempRoleList;
        }

        public RoleModel GetRole(int idRole)
        {
            var tempRole = new RoleModel();
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "SELECT IdRole, NameRole";
                    sqlQuery += " FROM [dbo].[Role]";
                    sqlQuery += " WHERE [Role].IdRole = @IdRole";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("IdRole", idRole);

                    var reader = sqlCommand.ExecuteReader();
                    var items = new List<RoleModel>();
                    while (reader.Read())
                    {
                        var u = new RoleModel();
                        u.IdRole = (int)reader["IdRole"];
                        u.NameRole = (string)reader["NameRole"];
                        items.Add(u);
                    }
                    if (items.Count > 0) tempRole = items[0];

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
            return tempRole;
        }
        public bool InsertRole(RoleModel roleModel)
        {
            var isInserted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "INSERT INTO dbo.[Role] (IdRole,NameRole)"
                                   + " VALUES (@IdRole, @NameRole)";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdRole", roleModel.IdRole);
                    sqlCommand.Parameters.AddWithValue("NameRole", roleModel.NameRole);
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


        public bool UpdateRole(RoleModel roleModel)
        {
            var isUpdated = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {
                try
                {
                    var sqlQuery = "UPDATE dbo.[Role] set NameRole=@NameRole "
                                   + "WHERE IdRole=@IdRole";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameRole", roleModel.NameRole);
                    sqlCommand.Parameters.AddWithValue("IdRole", roleModel.IdRole);
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

        public bool DeleteRole(int idRole)
        {
            var isDeleted = false;
            using (var sqlConnection = new SqlConnection(CSqlConfig.DefaultCnnVal()))
            {

                try
                {
                    var sqlQuery = "DELETE FROM  dbo.[Role] WHERE IdRole=@IdRole";
                    var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdRole", idRole);
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

        #endregion

    }
}
