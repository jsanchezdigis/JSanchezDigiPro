using ML;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace BL
{
    public class Materia
    {
        public static Result Add(ML.Materia materia)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "MateriaAdd";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar)
                        {
                            Value = materia.Nombre
                        };
                        collection[1] = new SqlParameter("Costo", SqlDbType.VarChar)
                        {
                            Value = materia.Costo
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se inserto correctamente el registro";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }

        public static Result Update(ML.Materia materia)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "MateriaUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar)
                        {
                            Value = materia.IdMateria
                        };
                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar)
                        {
                            Value = materia.Nombre
                        };
                        collection[2] = new SqlParameter("Costo", SqlDbType.VarChar)
                        {
                            Value = materia.Costo
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se actualizo correctamente el registro";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }

        public static Result Delete(ML.Materia materia)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "MateriaDelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar)
                        {
                            Value = materia.IdMateria
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se inactivo correctamente el registro";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }

        public static Result GetById(int IdMateria)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "MateriaGetById";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar)
                        {
                            Value = IdMateria
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();
                        DataTable tablaMateria = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaMateria);

                        if (tablaMateria.Rows.Count > 0)
                        {
                            result.Object = tablaMateria.Rows[0];
                            foreach (DataRow row in tablaMateria.Rows)
                            {
                                ML.Materia materia = new ML.Materia();

                                materia.IdMateria = (int)row[0];
                                materia.Nombre = row[1].ToString();
                                materia.Costo = (decimal)row[2];

                                result.Object = materia;
                            }
                            result.Correct = true;
                        }
                        else { result.Correct = false; }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "MateriaGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tablaMateria = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaMateria);

                        if (tablaMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablaMateria.Rows)
                            {
                                ML.Materia materia = new ML.Materia
                                {
                                    IdMateria = (int)row[0],
                                    Nombre = row[1].ToString(),
                                    Costo = (decimal)row[2]
                                };

                                result.Objects.Add(materia);
                            }
                            result.Correct = true;
                        }
                        else { result.Correct = false; }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }
    }
}
