﻿using System;
using System.Data;
using System.Data.SqlClient;
using IchiPaint.Common;
using IchiPaint.Models;

namespace IchiPaint.DataAccess
{
    public class PageDA
    {
        public decimal Create(NewsRequest request)
        {
            try
            {
                var spParameter = new SqlParameter[10];

                #region Set param

                var parameter = new SqlParameter("@P_Title", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.Title
                };
                spParameter[0] = parameter;

                parameter = new SqlParameter("@P_Content", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.Content
                };
                spParameter[1] = parameter;

                parameter = new SqlParameter("@P_Description", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.Description
                };
                spParameter[2] = parameter;

                parameter = new SqlParameter("@P_FeatureImage", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.FeatureImage
                };
                spParameter[3] = parameter;

                parameter = new SqlParameter("@P_Tag", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.Tag
                };
                spParameter[4] = parameter;

                parameter = new SqlParameter("@P_CategoryType", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = 0
                };
                spParameter[5] = parameter;

                parameter = new SqlParameter("@P_CreateDate", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                };
                spParameter[6] = parameter;

                parameter = new SqlParameter("@P_CreateBy", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.CreateBy
                };
                spParameter[7] = parameter;

                parameter = new SqlParameter("@P_Special", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = request.Special
                };
                spParameter[8] = parameter;

                parameter = new SqlParameter("@P_Return", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                    Value = -1
                };
                spParameter[9] = parameter;

                #endregion

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectString, CommandType.StoredProcedure, "PROC_PAGE_INSERT",
                    spParameter);

                return Convert.ToDecimal(spParameter[9].Value);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Delete(int id)
        {
            try
            {
                var spParameter = new SqlParameter[1];

                #region Set param

                var parameter = new SqlParameter("@P_Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = id
                };
                spParameter[0] = parameter;

                #endregion

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectString, CommandType.StoredProcedure, "PROC_PAGE_DELETE",
                    spParameter);

                return 1;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Edit(News model)
        {
            try
            {
                var spParameter = new SqlParameter[9];

                #region Set param

                var parameter = new SqlParameter("@P_Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Id
                };
                spParameter[0] = parameter;

                parameter = new SqlParameter("@P_Title", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Title
                };
                spParameter[1] = parameter;

                parameter = new SqlParameter("@P_Content", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Content
                };
                spParameter[2] = parameter;

                parameter = new SqlParameter("@P_Description", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Description
                };
                spParameter[3] = parameter;

                parameter = new SqlParameter("@P_FeatureImage", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.FeatureImage
                };
                spParameter[4] = parameter;

                parameter = new SqlParameter("@P_Tag", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Tag
                };
                spParameter[5] = parameter;

                parameter = new SqlParameter("@P_CategoryType", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.CategoryType
                };
                spParameter[6] = parameter;

                parameter = new SqlParameter("@P_Special", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Special
                };
                spParameter[7] = parameter;

                parameter = new SqlParameter("@P_Return", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                    Value = -1
                };
                spParameter[8] = parameter;

                #endregion

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectString, CommandType.StoredProcedure, "PROC_PAGE_EDIT",
                    spParameter);

                return Convert.ToDecimal(spParameter[8].Value);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Search(SearchNewsRequest model, ref int pTotal)
        {
            try
            {
                var spParameter = new SqlParameter[6];

                #region Set param

                var parameter = new SqlParameter("@P_ORDER_BY", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.OrderBy
                };
                spParameter[0] = parameter;

                parameter = new SqlParameter("@P_ORDER_TYPE", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.OrderByType
                };
                spParameter[1] = parameter;

                parameter = new SqlParameter("@P_START", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.Start
                };
                spParameter[2] = parameter;

                parameter = new SqlParameter("@P_END", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.End
                };
                spParameter[3] = parameter;

                parameter = new SqlParameter("@P_CREATE_DATE", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = model.CreateDate
                };
                spParameter[4] = parameter;

                parameter = new SqlParameter("@P_TOTAL", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                    Value = -1
                };
                spParameter[5] = parameter;

                #endregion

                var ds = SqlHelper.ExecuteDataset(ConfigInfo.ConnectString, CommandType.StoredProcedure,
                    "PROC_PAGE_SEARCH", spParameter);

                pTotal = Convert.ToInt32(spParameter[5].Value);

                return ds;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet GetById(int id)
        {
            try
            {
                var spParameter = new SqlParameter[1];

                var parameter = new SqlParameter("@P_Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = id
                };
                spParameter[0] = parameter;


                var ds = SqlHelper.ExecuteDataset(ConfigInfo.ConnectString, CommandType.StoredProcedure,
                    "PROC_PAGE_GET_BY_ID", spParameter);

                return ds;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}