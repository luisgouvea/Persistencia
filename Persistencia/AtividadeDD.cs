using FirebirdSql.Data.FirebirdClient;
using LibraryDBFirebird;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class AtividadeDD
    {
        public static void GetAllAtividades()
        {
            IDbConnection conexao = null;
            IDataReader dReader = null;

            try
            {  
                string sql = "SELECT r.ID_ITEMPED, r.QTD_ITEM, r.QTD_IMPORT, r.VLR_TOTAL, r.PRC_CUSTO,r.PRC_LISTA, r.VLR_DESC, r.ID_IDENTIFICADOR, r.ID_PEDIDO, r.ITEM_CANCEL,r.DT_LACTO, r.CASAS_QTD, r.CASAS_VLR, r.ST, r.ALIQUOTA, r.CHAVE,r.COD_BARRA, r.DT_ITEM, r.HR_ITEM, r.VLR_UNITFROM TB_PED_VENDA_ITEM r WHERE r.ID_PEDIDO = 4009";

                //conexao = DataBase.getConection();
                conexao = daoFireBird.getConexao();
                IDbCommand command = DataBase.getCommand(sql, conexao);

                conexao.Open();
                dReader = command.ExecuteReader();

                if (dReader != null)
                {
                    try
                    {
                        while (dReader.Read())
                        {
                            string gg = dReader["nome"] != DBNull.Value ? dReader["nome"].ToString() : string.Empty;
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
                throw new Exception("[AtividadeDD.GetAllAtividades()]: " + exp.Message);
            }
            finally
            {
                if (dReader != null) dReader.Close();
                if (conexao != null) conexao.Close();
            }
        }

        public static void executeSQL()
        {
            IDbConnection conexao = null;
            IDataReader dReader = null;

            try
            {
                //string sql = "SELECT r.ID_ITEMPED, r.QTD_ITEM, r.QTD_IMPORT, r.VLR_TOTAL, r.PRC_CUSTO,r.PRC_LISTA, r.VLR_DESC, r.ID_IDENTIFICADOR, r.ID_PEDIDO, r.ITEM_CANCEL,r.DT_LACTO, r.CASAS_QTD, r.CASAS_VLR, r.ST, r.ALIQUOTA, r.CHAVE,r.COD_BARRA, r.DT_ITEM, r.HR_ITEM, r.VLR_UNITFROM TB_PED_VENDA_ITEM r WHERE r.ID_PEDIDO = 4009";
                string sql = "SELECT * from TB_PED_VENDA_ITEM r WHERE r.ID_PEDIDO = 4009";
                
                //conexao = DataBase.getConection();
                FbConnection conexao2 = daoFireBird.getConexao();
                //IDbCommand command = DataBase.getCommand(sql, conexao);
                FbCommand fbCmd = new FbCommand(sql, conexao2);

                conexao2.Open();
                //dReader = command.ExecuteReader();
                dReader = fbCmd.ExecuteReader();

                if (dReader != null)
                {
                    try
                    {
                        while (dReader.Read())
                        {
                            string gg = dReader["VLR_TOTAL"] != DBNull.Value ? dReader["VLR_TOTAL"].ToString() : string.Empty;
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
                throw new Exception("[AtividadeDD.GetAllAtividades()]: " + exp.Message);
            }
            finally
            {
                if (dReader != null) dReader.Close();
                if (conexao != null) conexao.Close();
            }
        }
    }
}
