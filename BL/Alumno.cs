using ML;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Alumno
    {
        public static Result Add(ML.Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoAdd";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar)
                        {
                            Value = alumno.Nombre
                        };
                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar)
                        {
                            Value = alumno.ApellidoPaterno
                        };
                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar)
                        {
                            Value = alumno.ApellidoMaterno
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

        public static Result Update(ML.Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar)
                        {
                            Value = alumno.IdAlumno
                        };
                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar)
                        {
                            Value = alumno.Nombre
                        };
                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar)
                        {
                            Value = alumno.ApellidoPaterno
                        };
                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar)
                        {
                            Value = alumno.ApellidoMaterno
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

        public static Result Delete(ML.Alumno alumno)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoDelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar)
                        {
                            Value = alumno.IdAlumno
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

        public static Result GetById(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoGetById";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar)
                        {
                            Value = IdAlumno
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();
                        DataTable tablaAlumno = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAlumno);

                        if (tablaAlumno.Rows.Count > 0)
                        {
                            result.Object = tablaAlumno.Rows[0];
                            foreach (DataRow row in tablaAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();

                                alumno.IdAlumno = (int)row[0];
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();

                                result.Object = alumno;
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
                        cmd.CommandText = "AlumnoGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tablaAlumno = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAlumno);

                        if (tablaAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablaAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno
                                {
                                    IdAlumno = (int)row[0],
                                    Nombre = row[1].ToString(),
                                    ApellidoPaterno = row[2].ToString(),
                                    ApellidoMaterno = row[3].ToString()
                                };

                                result.Objects.Add(alumno);
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
