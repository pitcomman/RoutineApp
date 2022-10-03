using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoutineApp.Process
{
    public class MCR_AddOperator{

        // private readonly string strConn = "Server=RTHSRVTR01;Database=TRProcessControl;User Id=sa;Password=pwpolicy;MultipleActiveResultSets=true";
        private readonly string strConn = "Server=RTHSRVTR01;Database=TRProcessControl;Trusted_Connection=True";
        private SqlConnection objConn;

        public MCR_AddOperator(){
            objConn = new SqlConnection(strConn);
            objConn.Open();
        }

        public DataSet MCR_AddOperator_ProcessControl(String opID, String opName, String opRole, String opLevel)
        {
            if (objConn == null | objConn.State == ConnectionState.Closed)
            {
                objConn = new SqlConnection(strConn);
                objConn.Open();
                Console.WriteLine("Connected");
            }

            try
            {
                
                string strSql = "sprAddOperatorNCIM";
                SqlCommand cmd = new SqlCommand(strSql,objConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OPID", SqlDbType.VarChar).Value = opID;
                cmd.Parameters.Add("@OPName", SqlDbType.VarChar).Value = opName;
                cmd.Parameters.Add("@OPRole", SqlDbType.VarChar).Value = opRole;
                cmd.Parameters.Add("@OPLevel", SqlDbType.VarChar).Value = opLevel;

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(cmd);

                DataSet myDataset = new DataSet();
                mySqlAdapter.Fill(myDataset, "Result");
                if (myDataset.Tables["Result"].Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine(myDataset.Tables["Result"].Rows[0]["AddOperator"]);
                    Console.WriteLine(myDataset.Tables["Result"].Rows[0]["AddOperatorRole"]);
                    return myDataset;
                } 

                // strSql = "EXEC [dbo].[sprAddOperatorNCIM]" + opID  + "," + opName + "," + opRole + "," + opLevel;
                

                // DataSet myDataset = new DataSet();
                // DataTable myDataTable;
                // mySqlAdapter.Fill(myDataset, "EmployeeDetail");
                // if ((myDataset.Tables["EmployeeDetail"].Rows.Count == 0))
                // {
                //     return null;
                // }
                // else
                // {
                //     return myDataset;
                // } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objConn.Close();
                objConn = null;
            }

        }

        public DataSet GetRole()
        {
            if (objConn == null | objConn.State == ConnectionState.Closed)
            {
                objConn = new SqlConnection(strConn);
                objConn.Open();
                Console.WriteLine("Connected");
            }

            try
            {
                string strSql = "SELECT [RoleID] FROM [Role]";
                SqlCommand cmd = new SqlCommand(strSql,objConn);
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(cmd);

                DataSet myDataset = new DataSet();
                mySqlAdapter.Fill(myDataset, "Role");

                if (myDataset.Tables["Role"].Rows.Count > 0)
                {
                    return myDataset;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                objConn.Close();
                objConn = null;
            }
        }
        
    }

}