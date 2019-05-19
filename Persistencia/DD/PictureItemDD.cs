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
    public class PictureItemDD
    {
        public static void InsertPictureItem(ref ItemOrder itemOderTarget)
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

        public static bool updateCicloAtualAtividade(int novo_ciclo, int id_atividade)
        {
            IDbConnection conexao = null;
            IDbTransaction transacao = null;

            try
            {
                string sql = "UPDATE Atividade " +
                    "SET ciclo_atual = @ciclo_atual " +
                    "WHERE id_atividade = @id_atividade";

                conexao = DataBase.getConection();
                IDbCommand command = DataBase.getCommand(sql, conexao);

                IDbDataParameter parametro = command.CreateParameter();
                DataBase.getParametroCampo(ref parametro, "@ciclo_atual", novo_ciclo, tipoDadoBD.Integer);
                command.Parameters.Add(parametro);

                parametro = command.CreateParameter();
                DataBase.getParametroCampo(ref parametro, "@id_atividade", id_atividade, tipoDadoBD.Integer);
                command.Parameters.Add(parametro);

                conexao.Open();
                transacao = conexao.BeginTransaction();
                command.Transaction = transacao;

                command.ExecuteNonQuery();

                if (transacao != null) transacao.Commit();


                return true;
            }
            catch (Exception exp)
            {
                throw new Exception("[AtividadeDD.updateCicloAtualAtividade()]: " + exp.Message);
            }
            finally
            {
                if (transacao != null) transacao.Dispose();
                if (conexao != null) conexao.Close();
            }
        }
    }
}
