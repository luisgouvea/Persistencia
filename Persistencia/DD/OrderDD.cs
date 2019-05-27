using FirebirdSql.Data.FirebirdClient;
using LibraryDBFirebird;
using Persistencia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DD
{
    public class OrderDD
    {
        public static List<ItemOrder> GetOrderByNumber(string numberOrder)
        {
            FbConnection conexao = null;
            IDataReader dReader = null;
            List<ItemOrder> listItens = new List<ItemOrder>();
            try
            {
                string sql = "SELECT * from TB_PED_VENDA_ITEM r WHERE r.ID_PEDIDO = " + numberOrder;

                conexao = daoFireBird.getConexao();
                FbCommand fbCmd = new FbCommand(sql, conexao);

                conexao.Open();
                dReader = fbCmd.ExecuteReader();

                if (dReader != null)
                {
                    try
                    {
                        while (dReader.Read())
                        {
                            ItemOrder itemTarget = new ItemOrder();
                            itemTarget.identifier = dReader["ID_IDENTIFICADOR"] != DBNull.Value ? dReader["ID_IDENTIFICADOR"].ToString() : string.Empty;
                            itemTarget.qtd = dReader["QTD_ITEM"] != DBNull.Value ? dReader["QTD_ITEM"].ToString() : string.Empty;
                            listItens.Add(itemTarget);
                        }

                        conexao.Close();
                        dReader.Close();
                    }
                    catch (Exception exp)
                    {
                        throw new Exception("Ocorreu um erro: " + exp.Message);
                    }
                }
                return listItens;
            }
            catch (Exception exp)
            {
                throw new Exception("[OrderDD.GetOrderByNumber()]: " + exp.Message);
            }
            finally
            {
                if (dReader != null) dReader.Close();
                if (conexao != null) conexao.Close();
            }
        }

        public static void GetItemBarcode(ref ItemOrder itemOderTarget)
        {
            FbConnection conexao = null;
            IDataReader dReader = null;
            try
            {
                string sql = "SELECT COD_BARRA from TB_EST_PRODUTO WHERE ID_IDENTIFICADOR = " + itemOderTarget.identifier;

                conexao = daoFireBird.getConexao();
                FbCommand fbCmd = new FbCommand(sql, conexao);

                conexao.Open();
                dReader = fbCmd.ExecuteReader();

                if (dReader != null)
                {
                    try
                    {
                        while (dReader.Read())
                        {
                            itemOderTarget.barcode = dReader["COD_BARRA"] != DBNull.Value ? dReader["COD_BARRA"].ToString() : string.Empty;
                        }

                        conexao.Close();
                        dReader.Close();
                    }
                    catch (Exception exp)
                    {
                        throw new Exception("Ocorreu um erro: " + exp.Message);
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("[OrderDD.GetItemBarcode()]: " + exp.Message);
            }
            finally
            {
                if (dReader != null) dReader.Close();
                if (conexao != null) conexao.Close();
            }
        }

        public static void GetItemDescription(ref ItemOrder itemOderTarget)
        {
            FbConnection conexao = null;
            IDataReader dReader = null;
            try
            {
                string sql = "SELECT DESCRICAO from TB_ESTOQUE WHERE ID_ESTOQUE = " + itemOderTarget.identifier;

                conexao = daoFireBird.getConexao();
                FbCommand fbCmd = new FbCommand(sql, conexao);

                conexao.Open();
                dReader = fbCmd.ExecuteReader();

                if (dReader != null)
                {
                    try
                    {
                        while (dReader.Read())
                        {
                            itemOderTarget.description = dReader["DESCRICAO"] != DBNull.Value ? dReader["DESCRICAO"].ToString() : string.Empty;
                        }

                        conexao.Close();
                        dReader.Close();
                    }
                    catch (Exception exp)
                    {
                        throw new Exception("Ocorreu um erro: " + exp.Message);
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("[OrderDD.GetItemDescription()]: " + exp.Message);
            }
            finally
            {
                if (dReader != null) dReader.Close();
                if (conexao != null) conexao.Close();
            }
        }
    }
}
