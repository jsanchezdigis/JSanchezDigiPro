using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class AlumnoMateria
    {
        public static Result Add(ML.AlumnoMateria alumnoMateria)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoMateriaAdd";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar)
                        {
                            Value = alumnoMateria.Alumno.IdAlumno
                        };
                        collection[1] = new SqlParameter("IdMateria", SqlDbType.VarChar)
                        {
                            Value = alumnoMateria.Materia.IdMateria
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

        public static Result Delete(ML.AlumnoMateria alumnoMateria)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoMateriaDelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumnoMateria", SqlDbType.VarChar)
                        {
                            Value = alumnoMateria.IdAlumnoMateria
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

        public static Result GetAll(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoMateriaGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar)
                        {
                            Value = IdAlumno
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();

                        DataTable tablaAlumnoMateria = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAlumnoMateria);

                        if (tablaAlumnoMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tablaAlumnoMateria.Rows)
                            {
                                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                                alumnoMateria.IdAlumnoMateria = (int)row[0];
                                alumnoMateria.Alumno = new ML.Alumno();
                                alumnoMateria.Alumno.IdAlumno = (int)row[1];
                                alumnoMateria.Alumno.Nombre = row[2].ToString();
                                alumnoMateria.Alumno.ApellidoPaterno = row[3].ToString();
                                alumnoMateria.Alumno.ApellidoMaterno = row[4].ToString();
                                alumnoMateria.Materia = new ML.Materia();
                                alumnoMateria.Materia.IdMateria = (int)row[5];
                                alumnoMateria.Materia.Nombre = row[6].ToString();
                                alumnoMateria.Materia.Costo = (decimal)row[7];

                                result.Objects.Add(alumnoMateria);
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

        public static Result GetById(int IdAlumnoMateria)
        {
            Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoMateriaGetById";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumnoMateria", SqlDbType.VarChar)
                        {
                            Value = IdAlumnoMateria
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();
                        DataTable tablaAlumnoMateria = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAlumnoMateria);

                        if (tablaAlumnoMateria.Rows.Count > 0)
                        {
                            result.Object = tablaAlumnoMateria.Rows[0];
                            foreach (DataRow row in tablaAlumnoMateria.Rows)
                            {
                                ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                                alumnoMateria.IdAlumnoMateria = (int)row[0];
                                alumnoMateria.Alumno.IdAlumno = (int)row[1];
                                alumnoMateria.Materia.IdMateria = (int)row[2];

                                result.Object = alumnoMateria;
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

        public static ML.Result AlumnoMateriasDisponibles(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AlumnoMateriasDisponibles";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int)
                        {
                            Value = IdAlumno
                        };
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowAffected = cmd.ExecuteNonQuery();

                        DataTable tablaAlumnoMateria = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAlumnoMateria);

                        result.Objects = new List<object>();
                        foreach (DataRow row in tablaAlumnoMateria.Rows)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = (int)row[0];
                            alumnoMateria.Materia.Nombre = row[1].ToString();
                            alumnoMateria.Materia.Costo = (decimal)row[2];

                            result.Objects.Add(alumnoMateria);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
