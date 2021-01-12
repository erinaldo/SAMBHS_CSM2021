﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAMBHS.Windows.SigesoftIntegration.UI.Reports
{
    public class ConexionSAM
    {
        string cadena = GetApplicationConfigValue("ConexionSAM").ToString();

        public static object GetApplicationConfigValue(string appkey)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[appkey]);
        }
        public SqlConnection conectarsam = new SqlConnection();
        public ConexionSAM()
        {
            conectarsam.ConnectionString = cadena;
        }
        public void opensam()
        {
            try
            {
                conectarsam.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la BD SAMBHS " + ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
       }
        public void closesam()
       {
           conectarsam.Close();
       }
    }
}